using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp
{
    class Calculator
    {
        public static void Main(string[] args)
        {
            IProcessor[] p = {
                new PreProcessor(),
                new CoProcessor(),
                new MainProcessor(),
                new PostProcessor()
            };

            var i = 0;
            while(i < p.Length - 1)
                p[i].SetSuccessor(p[++i]);
            p[0].Process();

            Console.Read();
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
