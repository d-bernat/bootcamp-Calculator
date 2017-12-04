using Calculator.tools;
using Calculator.tools.courier;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp
{

    

    class Calculator
    {
        public delegate void Send(string message);
        public delegate void Process(StringBuilder message);

        public static void Main(string[] args)
        {
            GetProcessorPipeline().First().Process();
            StringBuilder result = new StringBuilder();
            result.Append("init message");
            GetXProcessorPipeline()(result);
            Console.WriteLine(result);
            ICourier Courier = new PlainQueueCourier();
            ICourier anotherCourier = new PlainQueueCourier();
            Courier.Send("send this message");
            Courier.Receive("this is selector", 1000L);
            new Send(Courier.Send)("message");
            Send s = new Send(Courier.Send) + new Send(anotherCourier.Send);
            s("send another message");
            A a = new B();
            a.message = "bbb";
            Console.WriteLine(a.message);

            Button button = new Button();
            button.name = "main";
            button.Click += button_Click;
            button.Click += new Button.EventHandler(button_XClick);
            button.Click += delegate (object sender, int arg)
            {
                Console.WriteLine((sender as Button).name + " : from delegate");

            };
            button.Click += (sender, arg) => { Console.WriteLine((sender as Button).name); };
            button.Click += (sender, arg) => { Console.WriteLine((sender as Button).name + " from lambda"); };

            button.OnClick();
            Console.Read();
        }

        private static void button_Click(object sender, int arg)
        {
            Button b = sender as Button;
            Console.WriteLine(b.name);
        }

        private static void button_XClick(object sender, int arg)
        {
            Button b = sender as Button;
            Console.WriteLine(b.name + " from another event handler");
        }

        private static IList<IProcessor> GetProcessorPipeline()
        {
            IList<IProcessor> list = new List<IProcessor>();
            list.Add(new PreProcessor());
            list.Add(new CoProcessor());
            list.Add(new MainProcessor());
            list.Add(new PostProcessor());

            /*IProcessor[] p = {
                new PreProcessor(),
                new CoProcessor(),
                new MainProcessor(),
                new PostProcessor()
            };*/
            var i = 0;
            while (i < list.Count - 1)
                list[i].SetSuccessor(list[++i]);

            return list;
        }



        private static Process GetXProcessorPipeline()
        {
            return
                new Process((new XPreProcessor()).Process) +
                new Process((new XCoProcessor()).Process) +
                new Process((new XProcessor()).Process) +
                new Process((new XPostProcessor()).Process);
        }
    }


    class Button
    {
        public delegate void EventHandler(object sender, int arg);
        public event EventHandler Click;
        public string name { get; set; }
        public void OnClick()
        {
            Click?.Invoke(this, 1);
        }

    }

    class A
    {
        public virtual string message { get; set; }
    }

    class B: A
    {
        public override string message
        {
            get
            {
                return "aaa " + base.message;
            }
        }

    }


    interface IXProcessor
    {
        void Process(StringBuilder message);
    }

    class XPreProcessor : IXProcessor
    {
        public void Process(StringBuilder message)
        {
            message.Append(" :preprocessor ");
        }
    }

    class XCoProcessor : IXProcessor
    {
        public void Process(StringBuilder message)
        {
            message.Append(" :coprocessor ");
        }
    }

    class XProcessor : IXProcessor
    {
        public void Process(StringBuilder message)
        {
            message.Append(" :processor ");
        }
    }

    class XPostProcessor : IXProcessor
    {
        public void Process(StringBuilder message)
        {
            message.Append(" :postprocessor ");
        }
    }

    interface IProcessor
    {
        void Process();
        void SetSuccessor(IProcessor successor);
    }

    abstract class AbstractProcessor : IProcessor
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

    class PreProcessor : AbstractProcessor
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
    class MainProcessor : AbstractProcessor
    {
        public override void Process()
        {
            Console.WriteLine("main processing");
            base.Process();
        }
    }

    class PostProcessor : AbstractProcessor
    {
        public override void Process()
        {
            Console.WriteLine("post processing");
            base.Process();
        }
    }

}
