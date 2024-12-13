using System;
using System.Collections.Generic;

namespace MyMessengerPattern
{
    public interface IMyMessengerContainer
    {
        #region Register Methods
        bool RegisterMessage<MessageType, MessageEventArgs>(MessageType message, IEnumerable<Type> publishersType)
            where MessageType : MessageGenericBase<MessageEventArgs>
            where MessageEventArgs : EventArgs;
        bool RegisterMessage<MessageType, MessageEventArgs>(MessageType message, params Type[] publishersType)
            where MessageType : MessageGenericBase<MessageEventArgs>
            where MessageEventArgs : EventArgs;
        /// <summary>
        /// A call to this method should guarantee that no futher calls to instance's registration would be allowed.
        /// </summary>
        void EndRegistering();
        #endregion

        #region Publisher's Methods
        bool PublishMessage<MessageType, MessageEventArgs>(object publisher, MessageEventArgs args)
            where MessageType : MessageGenericBase<MessageEventArgs>
            where MessageEventArgs : EventArgs;
        #endregion

        #region Subscriber's Methods
        bool SubscribeToMessage<MessageType, MessageEventArgs>(object subscriberInstance, Action<MessageEventArgs> messageHandler)
            where MessageType : MessageGenericBase<MessageEventArgs>
            where MessageEventArgs : EventArgs;
        bool RemoveSubscription<MessageType>(object subscribedInstance)
            where MessageType : MessageBase;
        #endregion
    }
}
