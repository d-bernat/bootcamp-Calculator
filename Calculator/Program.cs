using Calculator.tools;
using Calculator.tools.courier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp
{

    public delegate void Send(string message);

    class Calculator
    {
        

        public static void Main(string[] args)
        {
            GetProcessorPipeline().First().Process();
            ICourier Courier = new PlainQueueCourier();
            ICourier anotherCourier = new PlainQueueCourier();
            Courier.Send("send this message");
            Courier.Receive("this is selector", 1000L);
            new Send(Courier.Send)("message");
            Send s = new Send(Courier.Send) + new Send(anotherCourier.Send);
            s("send another message");
            Console.Read();
        }


        private static IProcessor[] GetProcessorPipeline()
        {
            IProcessor[] p = {
                new PreProcessor(),
                new CoProcessor(),
                new MainProcessor(),
                new PostProcessor()
            };
            var i = 0;
            while (i < p.Length - 1)
                p[i].SetSuccessor(p[++i]);
            return p;
        }
    }


    interface IProcessor
    {
        void Process();
        void SetSuccessor(IProcessor successor);
    }

    abstract class AbstractProcessor: IProcessor
    {
        private IProcessor successor;

        public virtual void Process()
        {
            successor?.Process();
        }

        public void SetSuccessor(IProcessor successor)
        {
            this.successor = successor;
        }
    }

    class PreProcessor: AbstractProcessor
    {
        public override void Process()
        {
            Console.WriteLine("pre processing");
            base.Process();
        }
    }

    class CoProcessor : AbstractProcessor
    {
        public override void Process()
        {
            Console.WriteLine("co processing");
            base.Process();
        }
    }
    class MainProcessor: AbstractProcessor
    {
        public override void Process()
        {
            Console.WriteLine("main processing");
            base.Process();
        }
    }

    class PostProcessor: AbstractProcessor
    {
        public override void Process()
        {
            Console.WriteLine("post processing");
            base.Process();
        }
    }

}
