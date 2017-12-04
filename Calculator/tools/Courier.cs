using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.tools
{
    interface ICourier: ISender, IReceiver
    {

    }

    interface ISender
    {
        void Send(string message);
        string Call(string message);
    }

    interface IReceiver
    {
        string Receive(string selector, long timeout);
    }

    abstract class AbstractAsyncCourier : ICourier
    {
        private readonly ISender Sender;
        private readonly IReceiver Receiver;


        public  AbstractAsyncCourier(ISender Sender, IReceiver Receiver)
        {
            this.Sender = Sender;
            this.Receiver = Receiver;
        }

        string ISender.Call(string message)
        {
            throw new NotSupportedException();
        }

        string IReceiver.Receive(string selector, long timeout)
        {
            return Receiver.Receive(selector, timeout);
        }

        void ISender.Send(string message)
        {
            Sender.Send(message);
        }
    }

}
