using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bootcamp
{
    class Calculator
    {
        static void Main(string[] args)
        {
            ICalculator calc = new SciCalculator();
            String result = calc.substr(3, 4) + "\n";
            Console.Write(result);
            Console.Read();
        }
    }


    class SimpleCalculator : ICalculator
    {
        public long add(int x, int y)
        {
            return x + y;
        }

        public long substr(int x, int y)
        {
            return x - y;
        }
    }

    class SciCalculator : ICalculator
    {
        public long add(int x, int y)
        {
            return x + y;
        }

        public long substr(int x, int y)
        {
            return x - y;
        }
    }

    interface ICalculator
    {
        long add(int x, int y);
        long substr(int x, int y);
    }
}
