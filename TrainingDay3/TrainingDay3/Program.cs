using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingDay3
{
    /*internal class Program
    {
        public void swapNumbers(ref int a, ref int b)
        {
            int c = a;
            a = b;
            b = c;
        }
        void ArraySum(int[] value, out int sum)
        {
            sum = 0;
            foreach (int i in value)
            {
                sum += i;
            }
        }
        enum calculation : byte
        {
            add = 10,
            subtract = 11,
            multiply = 15,
            divide = 19,
        }
        static void Main(string[] args)
        {
            int a = 10;
            int b = 20;
            int sum = 0;
            int[] arr = { 10, 20, 34, 5, 4, 3, 23, 54, 32 };
            Program p = new Program();
            p.swapNumbers(ref a, ref b);
            Console.WriteLine(a + " " + b);
            p.ArraySum(arr, out sum);
            Console.WriteLine(sum);
            Console.WriteLine(calculation.subtract);
            string[] v = Enum.GetNames(typeof(calculation));
            foreach (string s in v)
            {
                Console.WriteLine(s);
            }
            byte[] bt = (byte[])Enum.GetValues(typeof(calculation));
            foreach (byte t in bt)
            {
                Console.WriteLine(t);
            }
            salarycalculation sc;
            sc.basic = 67000;
            sc.hra = 10000;
            sc.da = 7000;
            sc.pf = 2500;
            sc.printSalary();
        }
    }
    struct salarycalculation
    {
        public int basic, da, hra, pf, gross, net;
        public void printSalary()
        {
            gross = basic + hra + da;
            net = gross - pf;
            Console.WriteLine("gross: " + gross + " net: " + net);
        }
    }*/

    
    public struct user
    {
        public string username;
        public string email;
        public string mobile;

        public void getDetails()
        {
            Console.WriteLine("Enter username, email and mobileno. ");
            username = Console.ReadLine();
            email = Console.ReadLine();
            mobile = Console.ReadLine();
        }
        public void printDetail()
        {
            Console.WriteLine();
            Console.WriteLine("username: "+username + "\t email: " + email+ "\t mobile: " + mobile);
        }

    }
    enum size : int
    {
        small = 50,
        medium = 100,
        big = 200,
        large = 250,
    }
    public struct orderDetails
    {
        string orderdate;
        string[] itemname;
        int[] price;
        int quantity;
        int choice;
        string drinksize;
        int finalprice;
        public void getorderDetail()
        {
            itemname = new string[]{ "Pepsi","Cola", "Mirinda", "slice ", "appy" };
            price = new int[] { 40, 45, 38, 50, 44 };
            orderdate = DateTime.Now.ToString();
            foreach(var item in itemname)
            {
                Console.Write(item + "\t");
            }
            Console.WriteLine();
            foreach(var item in price)
            {
                Console.Write(item+ "\t");
            }
            Console.WriteLine();
            Console.WriteLine("Enter the choice of drink. eg. 1 for pepsi,2 for coca cola");
            choice = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the quantity of drink");
            quantity = Convert.ToInt32(Console.ReadLine());
            finalprice = price[choice - 1];
        }
        public void viewsizeValue()
        {
            string[] v = Enum.GetNames(typeof(size));
            foreach (string s in v)
            {
                Console.Write(s+ "\t");
            }
            Console.WriteLine();
            Console.WriteLine("Enter the size you want. eg: big, small, large");
            drinksize = Console.ReadLine();
            if(drinksize == "small")
            {
                finalprice += size.small.GetHashCode();
            }
            else if(drinksize == "medium")
            {
                finalprice += size.medium.GetHashCode();
            }
            else if (drinksize == "large")
            {
                finalprice += size.large.GetHashCode();
            }
            else if(drinksize == "big")
            {
                finalprice += size.big.GetHashCode();
            }
            else
            {
                Console.WriteLine("wrong Input");
            }
            finalprice = finalprice * quantity;
        }

        public void showDetails()
        {
            Console.WriteLine("Order date: "+orderdate+ "\t ItemName: " + itemname[choice-1]+ "\t quantity: " + quantity+ "\t drinksize: " + drinksize+ "\t Totalprice: " + finalprice);
        }
    }
    /*internal class OopsConcepts
    {
        static void Main(string[] args)
        {
            user u = new user();
            u.getDetails();
            orderDetails od = new orderDetails();
            od.getorderDetail();
            od.viewsizeValue();
            u.printDetail();
            od.showDetails();
        }
    }*/
}
