using System;
using System.Collections;
using System.Collections.Generic;
namespace TrainingJan21
{
    /*class Data<T>
    {
        T userdata;
        public T Userdata
        {
            get { return userdata; }
            set { userdata = value; }
        }
    }
    class Calculator
    {
        public void Calculate<T>(T t1,T t2)
        {
            Console.WriteLine("Processing {0},{1}",t1, t2);
        }
    }

    class Employee
    {
        string employeename;
        string department;
        public string Employeeloyeename
        {
            get { return employeename; }
            set { employeename = value; }
        }
        public string Department
        {
            get { return department; }
            set { department = value; }
        }
        public override string ToString()
        {
            return "{" + employeename + "," + department + "}";
        }
    }
    class InfoData<T, E>
    {
        T t;
        E e;

        public InfoData(T t, E e)
        {
            this.t = t;
            this.e = e;
        }
        public void PrintInfo()
        {
            Console.WriteLine("[{0},{1}]", t, e);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Data<string> stringdata = new Data<string>();
            Data<int> intdata = new Data<int>();
            Data<float> floatdata = new Data<float>();
            stringdata.Userdata = "Hello";
            floatdata.Userdata = 234.543f;
            intdata.Userdata = 234;
            Console.WriteLine(stringdata.Userdata);
            Console.WriteLine(intdata.Userdata);
            Console.WriteLine(floatdata.Userdata);
            Calculator calculator = new Calculator();
            calculator.Calculate(12, 13);
            calculator.Calculate("Hello", "World");
            Employee employee = new Employee();
            employee.Employeeloyeename = "Peter Jones";
            employee.Department = "Sales";
            InfoData<int, Employee> infoData = new InfoData<int, Employee>(1, employee);
            infoData.PrintInfo();
        }
    }*/

    /*class EmployeeInfo<T>
    {
        T[] employee;
        T[] department;
        int size;
        public EmployeeInfo(int size)
        {
            this.size = size;
            employee = new T[size];
            department = new T[size];
        }
        public void PrintDetails()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(employee[i] + "," + department[i]);
            }

        }
        public void addEmployee(T employeename, int position)
        {
            employee[position] = employeename;
        }
        public void addDepartment(T departmentname, int position)
        {
            department[position] = departmentname;
        }

    }
    class ProductInfo<T>
    {
        T[] product;
        T[] producttype;
        int size;
        public ProductInfo(int size)
        {
            this.size = size;
            product = new T[size];
            producttype = new T[size];
        }
        public void PrintDetails()
        {
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(product[i] + "," + producttype[i]);
            }

        }
        public void addProduct(T employeename, int position)
        {
            product[position] = employeename;
        }
        public void addProductDetails(T departmentname, int position)
        {
            producttype[position] = departmentname;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {

            ProductInfo<string> info = new ProductInfo<string>(3);
            info.addProduct("shirt", 0);
            info.addProduct("hoodie", 1);
            info.addProduct("cap", 2);
            info.addProductDetails("On sale", 0);
            info.addProductDetails("50% off", 1);
            info.addProductDetails("buy 1 get 1 ", 2);
            info.PrintDetails();
            Console.ReadKey();
        }
    }*/

    public class Items
    {
        string itemname;
        float price;

        public Items(string name, float price)
        {
            this.itemname = name;
            this.price = price;
        }
        public String ItemName { get => itemname; set => itemname = value; }
        public float Price { get => price; set => price = value; }

        public override string ToString()
        {
            return $"The itemname is {this.itemname} and the price is {this.price}";
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            /*Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            foreach(int i in stack)
            {
                Console.WriteLine(i);
            }*/

            /*ArrayList arrayList = new ArrayList();
            arrayList.Add(1);
            arrayList.Add(2);
            arrayList.Add(3);
            arrayList.Add(4);
            arrayList.Add(5);
            Array arr = arrayList.ToArray();
            Console.WriteLine(arrayList.Count);
            
            arrayList.Reverse();
            arrayList.RemoveAt(0);
            foreach (int i in arrayList)
            {
                Console.WriteLine(i);
            }
            BitArray bitArray = new BitArray(5);
            BitArray bitArray2 = new BitArray(5);
            bitArray[0] = true;
            bitArray[1] = false;
            bitArray2[0] = true;
            bitArray2[1]= true;
            
            BitArray bitArray3 = bitArray.Not();
            foreach (bool i in bitArray3)
            {
                Console.WriteLine(i);
            }*/

            /*Hashtable ht = new Hashtable();
            ht.Add(1, "h");
            ht.Add(2, "e");
            ht.Add(3, "m");
            ht.Add(4, "a");
            ht.Add(5, "n");
            ht.Add(6, "g");
            foreach(var key in ht.Keys)
            {
                Console.WriteLine(ht[key]);
            }*/

            ArrayList arr = new ArrayList();
            Stack<Items> st = new Stack<Items>();

            arr.Add(new Items("burger", 55f));
            arr.Add(new Items("Fries", 80f));
            arr.Add(new Items("Pizza", 150f));
            arr.Add(new Items("Wraps", 65f));
            arr.Add(new Items("cola", 60f));

            foreach (Items item in arr)
            {
                Console.WriteLine(item.ToString());
                st.Push(item);
            }

            Console.WriteLine("LIFO");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(st.Pop());
            }
        }
    }
}
