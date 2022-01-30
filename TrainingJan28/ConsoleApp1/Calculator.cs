using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Divide(int a, int b)
        {
            if (b == 0 && a == 0) throw new ArgumentException("Invalid Argument");
            if (b == 0) throw new ArgumentNullException("Denominator cannot be zero");
            return a / b;
        }
        public int Multiply(int a, int b) => a * b;
        public int Subtract(int a, int b) => a - b;

        public int Item { get; set; }
    }
}
