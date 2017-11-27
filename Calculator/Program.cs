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
            ICalculator calc = new SciCalculator();
            string result = calc.substr(3, 4) + "\n";

            Console.Write(result);
            foreach(string arg in args)
            {
                Console.WriteLine(arg);
            }
            try
            {
                double.Parse("123.452");
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                Console.WriteLine("finally");
            }
            Console.WriteLine(Environment.UserName);

            Console.WriteLine(calc.getDateTime().Date);



            Console.Read();
        }
    }


    class SimpleCalculator : ICalculator
    {
        public long add(int x, int y)
        {
            return x + y;
        }

        public DateTime getDateTime()
        {
            throw new NotImplementedException();
        }

        public TimeSpan getDateTimeSpan()
        {
            throw new NotImplementedException();
        }

        public ulong substr(int x, int y)
        {
            return (ulong)(x - y);
        }
    }

    class SciCalculator : ICalculator
    {
        public long add(int x, int y)
        {
            return x + y;
        }

        public DateTime getDateTime()
        {
            return DateTime.Now;
        }

        public TimeSpan getDateTimeSpan()
        {
            throw new NotImplementedException();
        }

        public ulong substr(int x, int y)
        {
            IList<String> l = new List<String>();
            l.Add("ahoj");
            l.Add("vole");

            foreach (String s in l)
            {
                Console.WriteLine(s);

            }

            foreach(string s in Environment.GetCommandLineArgs())
                Console.WriteLine(s);
            unchecked
            {
                return (ulong)(x - y);
            }
        }
    }

    interface ICalculator : IDateTimeable
    {
        long add(int x, int y);
        ulong substr(int x, int y);
    }

    interface IDateTimeable
    {
        DateTime getDateTime();
        TimeSpan getDateTimeSpan();

    }

}
