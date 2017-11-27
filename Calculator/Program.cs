using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calc = new Calculator();
            String result = calc.add(3, 4) + "\n";
            Console.Write(result);
            Console.Read();
        }
    }


    class Calculator
    {
        public long add(int x, int y)
        {
            return x + y;
        }
    }
}
