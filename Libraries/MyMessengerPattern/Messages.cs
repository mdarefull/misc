using System;
using System.Collections.Generic;

namespace MyMessengerPattern
{
    public abstract class MessageBase
    {
        private readonly SortedSet<Type> _allowedPublishers;
        internal SortedSet<Type> AllowedPublishers { get { return _allowedPublishers; } }

        private Dictionary<object, Action<EventArgs>> _registeredListeners;
        internal Dictionary<object, Action<EventArgs>> RegisteredListeners { get { return _registeredListeners; } }

        public MessageBase()
        {
            _allowedPublishers = new SortedSet<Type>();
            _registeredListeners = new Dictionary<object, Action<EventArgs>>();
        }
    }
    public abstract class MessageGenericBase<MessageEventArgs> : MessageBase where MessageEventArgs : EventArgs { }
}
