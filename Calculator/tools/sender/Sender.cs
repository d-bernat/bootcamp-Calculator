using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.tools.sender
{
    class PlainQueueSender : ISender
    {
        public string Call(string message)
        {
            throw new NotImplementedException();
        }

        public void Send(string message)
        {
            Console.WriteLine("Send: {0}", message);
        }
    }
}
