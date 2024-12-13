using MyMessengerPattern;
using System;

namespace Samples.MyMessengerPattern
{
    public sealed class StringMessage : MessageGenericBase<StringMessageEventArgs> { }
    public sealed class StringMessageEventArgs : EventArgs
    {
        public string message;

        public StringMessageEventArgs(string expirationMsg)
        {
            message = expirationMsg;
        }
    }
}
