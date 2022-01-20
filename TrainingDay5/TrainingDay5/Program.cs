using System;

namespace TrainingDay5
{
    /*public interface Person
    {
        public void setDetail();
        public Person getDetails();
    }
    public class Engineer : Person
    {
        string fn, ln, desg;
        public void setDetail()
        {
            Console.WriteLine("Enter first Name");
            this.fn = Console.ReadLine();
            Console.WriteLine("Enter last Name");
            this.ln = Console.ReadLine();
            Console.WriteLine("Enter designation");
            this.desg = Console.ReadLine();
        }
        public Person getDetails()
        {
            return this;
        }
    }
    public class Trainee : Person
    {
        string fn, ln, desg;
        public void setDetail()
        {
            Console.WriteLine("Enter first Name");
            this.fn = Console.ReadLine();
            Console.WriteLine("Enter last Name");
            this.ln = Console.ReadLine();
            Console.WriteLine("Enter designation");
            this.desg = Console.ReadLine();
        }
        public Person getDetails()
        {
            return this;
        }
    }
    public class Worker : Person
    {
        string fn, ln, desg;
        public void setDetail()
        {
            Console.WriteLine("Enter first Name");
            this.fn = Console.ReadLine();
            Console.WriteLine("Enter last Name");
            this.ln = Console.ReadLine();
            Console.WriteLine("Enter designation");
            this.desg = Console.ReadLine();
        }
        public Person getDetails()
        {
            return this;
        }
    }
    public class Salary
    {
        public void CalculateSalary(Person p)
        {
            if (p is Engineer)
            {
                Console.WriteLine("Salary for Engineer");
            }
            else if (p is Trainee)
            {
                Console.WriteLine("Salary for Trainee");
            }
            else if (p is Worker)
            {
                Console.WriteLine("Salary for Worker");
            }
        }
    }*/

    public class Item
    {
        public string itemname;
        public float price;
        public int quantity;
    }

    public class Order
    {
        int ordno;
        Item[] itemlist;
        string ordDate;
        int i = 0;
        public Order(int n)
        {
            itemlist = new Item[n];
        }
        public void addOrderDetails()
        {
            Console.WriteLine("Enter order no.");
            ordno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter order Date ");
            ordDate = Console.ReadLine();
        }
        public void AddItem()
        {
            Console.WriteLine("Enter item name");
            Item it = new Item();
            it.itemname = Console.ReadLine();
            Console.WriteLine("Enter item price");
            it.price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter item quantity");
            it.quantity = Convert.ToInt32(Console.ReadLine());
            itemlist[i++] = it;
        }

        public Item[] GetItems()
        {
            return itemlist;
        }
    }

    public class Sales
    {
        Order order;
        float totalamount=0;
        Item[] itemlist;

        public Sales(Order o)
        {
            order = o;
        }
        public void calculateTotalAmount()
        {
            itemlist = order.GetItems();
            foreach(Item it in itemlist)
            {
                totalamount += it.price * it.quantity;
            }
            Console.WriteLine("Total amount: "+totalamount);
        }
        public void correctStock(Stock s)
        {
            Item[] it = s.getStockDetails();
            foreach(Item it2 in it)
            {
                Console.WriteLine("Item name: " + it2.itemname + "Item price: " + it2.price + "Item quantity: " + it2.quantity);
            }
        }
    }
    public class Purchases
    {
        Order purchaseorder;
        float totalamount = 0;
        Item[] itemlist;

        public Purchases(Order o)
        {
            purchaseorder = o;
        }
        public void calculateTotalAmount()
        {
            itemlist = purchaseorder.GetItems();
            foreach (Item it in itemlist)
            {
                totalamount += it.price * it.quantity;
            }
            Console.WriteLine("Total amount: " + totalamount);
        }
        public void correctStock(Stock s)
        {
            Item[] it = s.getStockDetails();
            foreach (Item it2 in it)
            {
                Console.WriteLine("Item name: " + it2.itemname + "Item price: " + it2.price + "Item quantity: " + it2.quantity);
            }
        }
    }

    public class Stock
    {
        Item[] items_in_stock;
        public Item[] getStockDetails()
        {
            return items_in_stock;
        }
        public void setStock(Item[] i)
        {
            items_in_stock = i;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Enter the total no. of items in your order");
            int n = Convert.ToInt32(Console.ReadLine());
            Order o = new Order(n);
            o.addOrderDetails();
            for(int i = 0; i < n; i++)
                o.AddItem();
            Sales s = new Sales(o);
            s.calculateTotalAmount();


        }
    }
    /*internal class Student
    {
        public string name { get; set; }
        public int weight { get; set; }
        public static bool operator >(Student a, Student b)
        {
            return a.weight > b.weight;
        }
        public static bool operator <(Student a, Student b)
        {
            return a.weight > b.weight;
        }
    }*/
    /*public class employee
    {
        string name, desg;
        int salary;
        public void getDetails(string name,string desg,int salary)
        {
            this.name = name;
            this.desg = desg;
            this.salary = salary;
        }
        public void printDetails()
        {
            System.Console.WriteLine("name:" + this.name);
            System.Console.WriteLine("designation: "+this.desg);
            System.Console.WriteLine("salary: "+this.salary);
        }
    }

    public class Intrest
    {
        public Intrest(float amount, float rate)
        {

        }
    }
    public class LoanRate : Intrest
    {
        public LoanRate(float amount, float rate) : base(amount, rate)
        {

        }
    }

    class Exam
    {
        string stu_name, semester;
        static string exam_details;

        static Exam()
        {
            exam_details = "Final Exam";
        }
    }*/


    /*internal class Program
    {
        static void Main(string[] args)
        {
            *//*Student a = new Student();
            Student b = new Student();
            a.name = "hemang";
            a.weight = 70;
            b.name = "ashish";
            b.weight = 72;
            Console.WriteLine(a>b);
            Console.WriteLine(a<b);*//*
            employee e = new employee();
            e.getDetails("hemang", "SDE", 67000);
            e.printDetails();
        }
    }*/
}
