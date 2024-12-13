using System;
using System.Collections.Generic;
using System.Linq;

namespace MyMessengerPattern
{
    public sealed class MySampleMessengerContainer : IMyMessengerContainer
    {
        #region Classic Thread-Safe Singleton Pattern
        private readonly static MySampleMessengerContainer _simpleMessengerContainer = new MySampleMessengerContainer();
        private MySampleMessengerContainer()
        {
            _registeredMessages = new Dictionary<Type, MessageBase>();
            _isRegisteringEnable = true;
        }
        public static MySampleMessengerContainer Instance { get { return _simpleMessengerContainer; } }
        #endregion

        private readonly Dictionary<Type, MessageBase> _registeredMessages;
        private bool _isRegisteringEnable;

        private MessageBase GetMessage(Type messageType)
        {
            MessageBase msg;
            _registeredMessages.TryGetValue(messageType, out msg);

            return msg;
        }

        #region Register Methods
        public bool RegisterMessage<MessageType, MessageEventArgs>(MessageType message, IEnumerable<Type> publishersType)
            where MessageType : MessageGenericBase<MessageEventArgs>
            where MessageEventArgs : EventArgs
        {
            bool succesfullRegistration = false;
            if (_isRegisteringEnable)
            {
                var key = message.GetType();
                var currentMsg = GetMessage(key);
                if (currentMsg == null)
                {
                    _registeredMessages.Add(message.GetType(), message);
                    currentMsg = message;
                }

                if (currentMsg.Equals(message))
                {
                    foreach (var publisher in publishersType)
                        currentMsg.AllowedPublishers.Add(publisher);
                    succesfullRegistration = true;
                }
            }
            else
                throw new InvalidOperationException("This method is disabled because the registration period has ended.");

            return succesfullRegistration;
        }
        public bool RegisterMessage<MessageType, MessageEventArgs>(MessageType message, params Type[] publishersType)
            where MessageType : MessageGenericBase<MessageEventArgs>
            where MessageEventArgs : EventArgs
        {
            return RegisterMessage<MessageType, MessageEventArgs>(message, publishersType.AsEnumerable());
        }
        public void EndRegistering()
        {
            _isRegisteringEnable = false;
        }
        #endregion

        #region Publisher's Methods
        public bool PublishMessage<MessageType, MessageEventArgs>(object publisher, MessageEventArgs args)
            where MessageType : MessageGenericBase<MessageEventArgs>
            where MessageEventArgs : EventArgs
        {
            var sucessfullPublished = false;
            var key = typeof(MessageType);
            var msg = GetMessage(key);
            if (msg != null && msg.AllowedPublishers.Contains(publisher.GetType()))
            {
                // I use ToList because when listener(args) is called, the controll will be passed to the listener. And it is possible that the listener removes
                // its subscription in that method causing the enumeration to be modified.
                var msgListeners = msg.RegisteredListeners.Values.ToList();
                foreach (var listener in msgListeners)
                    listener(args);

                sucessfullPublished = true;
            }

            return sucessfullPublished;
        }
        #endregion

        #region Subscriber's Methods
        public bool SubscribeToMessage<MessageType, MessageEventArgs>(object subscriberInstance, Action<MessageEventArgs> messageHandler)
            where MessageType : MessageGenericBase<MessageEventArgs>
            where MessageEventArgs : EventArgs
        {
            var succesfullSubscribed = false;
            var msg = GetMessage(typeof(MessageType));

            if (msg != null && !msg.RegisteredListeners.ContainsKey(subscriberInstance))
            {
                msg.RegisteredListeners.Add(subscriberInstance, args => messageHandler(args as MessageEventArgs));
                succesfullSubscribed = true;
            }

            return succesfullSubscribed;
        }
        public bool RemoveSubscription<MessageType>(object subscribedInstance)
            where MessageType : MessageBase
        {
            var successfullRemoval = false;
            var msg = GetMessage(typeof(MessageType));
            if (msg != null)
                successfullRemoval = msg.RegisteredListeners.Remove(subscribedInstance);

            return successfullRemoval;
        }
        #endregion
    }
}