using Calculator.tools.receiver;
using Calculator.tools.sender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.tools.courier
{
    class PlainQueueCourier: AbstractAsyncCourier
    {
        public PlainQueueCourier(): base(new PlainQueueSender(), new PlainQueueReceiver())
        {

        }
    }
}
