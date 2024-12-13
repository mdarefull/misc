using MyMessengerPattern;
using System;

namespace Samples.MyMessengerPattern
{
    public class Sampler : ISampler
    {
        public void ExecuteSample()
        {
            // Register the StringMessage. I will be the publisher.
            IMyMessengerContainer container = MySampleMessengerContainer.Instance;
            container.RegisterMessage<StringMessage, StringMessageEventArgs>(new StringMessage(), this.GetType());

            // Now subscribe to the message. I will be the subscriber too:
            container.SubscribeToMessage<StringMessage, StringMessageEventArgs>(this, OnStringMessageHandler);

            // Now I will publish the message:
            var args = new StringMessageEventArgs("Hello MessengerContainer");
            container.PublishMessage<StringMessage, StringMessageEventArgs>(this, args);
        }
        public void OnStringMessageHandler(StringMessageEventArgs args)
        {
            Console.WriteLine(args.message);
        }
    }
}