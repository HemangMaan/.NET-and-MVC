using System;
using System.Collections.Generic;
using System.Linq;

namespace CaseStudyLinQ
{
    internal class Program
    {
        public class Employee
        {
            public string name;
            public string department;
            public float salary;
            public Employee(string name, string department, float salary)
            {
                this.name = name;
                this.department = department;
                this.salary = salary;
            }
        }
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("Hemang", "Sales", 30000));
            employees.Add(new Employee("Maan", "Technical", 50000));
            employees.Add(new Employee("hrt", "IT", 12000));
            employees.Add(new Employee("fg", "Sales", 35000));
            employees.Add(new Employee("nhgersfb", "Sales", 40000));

            var l = from emp in employees
                    where emp.salary > 15000
                    select emp;
            foreach(Employee emp in l)
            {
                Console.WriteLine(emp.name+" "+emp.department+" "+emp.salary);
            }

            var len = from em in employees
                      where em.name.Length < 4
                      select em;
            foreach (Employee emp in len)
            {
                Console.WriteLine(emp.name + " " + emp.department + " " + emp.salary);
            }
        }
    }
}
