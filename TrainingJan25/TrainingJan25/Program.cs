using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

namespace TrainingJan25
{
    internal class Program
    {
        public static DataSet GetDataSet()
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hemang\Documents\DatabaseSQLDemo.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("select * from Items", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }

        class Customer
        {
            public string Name { get; set; }
            public string city { get; set; }
        }

        class Student
        {
            public string name;
            public int age;
            public int marks;
            public Student(string name,int age,int marks)
            {
                this.name = name;
                this.age = age;
                this.marks = marks;
            }
        }

        static void Main(string[] args)
        {
            /*int[] arr = { 6, 7, 8, 1, 5, 9, 10, 11, 2, 3, 4, 12, };
            int[,] arr2 = new int[2, 3];
            arr2[0,0] = 1;
            arr2[0,1] = 4;
            arr2[0,2] = 5;
            arr2[1,0] = 2;
            arr2[1,1] = 6;
            arr2[1,2] = 9;
            var num = from n in arr
                      select n;
            var query = from int a in arr2
                        orderby a
                        select a;*/
            /*List<Int32> numlist = new List<Int32>();
            numlist.Add(32);
            numlist.Add(54);
            numlist.Add(53);
            numlist.Add(12);
            numlist.Add(13);
            numlist.Add(14);
            numlist.Add(15);
            var number = from n in numlist
                         orderby n
                         select n;*/

            /*XElement element = new XElement("Productsdata",
                new XElement("Product",
                new XElement("Name","LordofRings"),
                new XElement("Price",125),
                new XElement("Quantity",54)
                ),
                new XElement("Product",
                new XElement("Name", "Bookl"),
                new XElement("Price", 150),
                new XElement("Quantity", 5)
                )
            );

            var elements = from s in element.Elements()
                           select s;
    
            foreach(var i in elements)
            {
                Console.WriteLine(i.Value);
            }*/


            /*DataSet ds = GetDataSet();

            var data = from s in ds.Tables[0].AsEnumerable() 
                       select s;

            foreach(var dr in data)
            {
                Console.WriteLine(dr[0] + " " + dr[1] + " " + dr[2] + " " + dr[3]);
            }*/

            /*List<Customer> list = new List<Customer>();
            Customer c = new Customer();
            c.Name = "hemang";
            c.city = "Delhi";
            list.Add(c);
            Customer c1 = new Customer();
            c1.Name = "maan";
            c1.city = "Mumbai";
            list.Add(c1);

            var cus = from cust in list 
                      where cust.city == "Mumbai"
                      select cust;

            foreach(Customer co in cus)
            {
                Console.WriteLine(co.Name);
            }*/

            /*List<Student> students = new List<Student>();
            students.Add(new Student("Hemang", 21, 67));
            students.Add(new Student("Ashish", 22, 87));
            students.Add(new Student("dfgd", 28, 75));
            students.Add(new Student("kjhgf", 30, 97));

            var stu = from s in students
                      where s.marks>70 && s.age<29
                      select s;
            foreach(Student student in stu)
            {
                Console.WriteLine(student.name+" "+student.age+" "+student.marks);
            }*/



        }
    }
}
