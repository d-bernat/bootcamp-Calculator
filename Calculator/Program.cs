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
            SimpleCalculator calc = new SimpleCalculator();
            String result = calc.add(3, 4) + "\n";
            Console.Write(result);
            Console.Read();
        }
    }


    class SimpleCalculator
    {
        public long add(int x, int y)
        {
            return x + y;
        }
    }
}
