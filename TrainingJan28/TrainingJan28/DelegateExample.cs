using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingJan28
{
    //Step1: Declaration 
    public delegate int ArithmeticDelegate(int a, int b);
    internal class DelegateExample
    {
        static int Add(int x,int y) => x + y;
        public int Minus(int x, int y) => x - y;
        static int Multiply(int x,int y) => x * y;
        public int Divide(int x, int y) => y > 0 ? x / y : 0;

        internal static void Test()
        {
            DelegateExample de = new DelegateExample();

            ArithmeticDelegate ad = new ArithmeticDelegate(Add);
            var result = ad(100, 200);
/*            Console.WriteLine($"ad(100,200) =>{result}");
            result = ad.Invoke(200, 300);
            Console.WriteLine($"ad.Invoke(200,300) =>{result}");*/

            //Multicaseting
            ad += new ArithmeticDelegate(de.Minus);
            ad+= new ArithmeticDelegate(Add);
            ad+= new ArithmeticDelegate(Multiply);
            ad += new ArithmeticDelegate(de.Divide);
            //result = ad.Invoke(10, 5);
            //Console.WriteLine($"ad(10,5) returns => {result}");
            InvokeSelectiveFunction(ad);
        }

        private static void InvokeSelectiveFunction(ArithmeticDelegate ad)
        {
            foreach(Delegate item in ad.GetInvocationList())
            {
                //if (item.Method.Name.StartsWith("A"))
                //{
                    object res = item.DynamicInvoke(12, 12);
                    Console.WriteLine($"Method: {item.Method.Name} returns: {res}");
                //}
            }
        }
    }
}
