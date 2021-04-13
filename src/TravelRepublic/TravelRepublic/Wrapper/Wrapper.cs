using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRepublic.Wrapper
{
    public class Wrapper:IWrapper
    {
        public void WriteLine(string value)
        {
            Console.Write(value);
        }

        public void WriteLine()
        {
            Console.WriteLine();
        }

        public void Write(string value)
        {
            Console.Write(value);
        }
    }
}
