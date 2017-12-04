using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.tools.receiver
{
    class PlainQueueReceiver : IReceiver
    {
        public string Receive(string selector, long timeout)
        {
            Console.WriteLine("Receive: {0}, {1}", selector, timeout);
            return "receive";
        }
    }
}
