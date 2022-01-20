using System;

namespace CaseStudyEmployee
{
    public class Department
    {
        protected string deptName;
        Manager manager;
        public void setDetails()
        {
            Console.WriteLine("Enter Department Name.");
            deptName = Console.ReadLine();
            manager = new Manager();
            manager.setName();
        }

        public void findEmpByid(int id)
        {
            Employee[] e = manager.getEmployees();
            foreach(Employee employee in e)
            {
                if (employee.empid == id)
                {
                    employee.printEmployeeDetails();
                }
            }
        }

        public void printDetail()
        {
            Console.WriteLine("The Department Name is " + deptName +
                " \n The Manage of this department is: " + manager.getName());
        }

    }
    public class Manager:Department
    {
        protected string name;
        protected string dept;
        Employee[] employees;
        int i = 0,n;
        public Manager()
        {
            dept = deptName;
        }
        public void setName()
        {
            Console.WriteLine("Enter Manager Name. ");
            name = Console.ReadLine();
            Console.WriteLine("Enter the no.of employees of the department.");
            n = Convert.ToInt32(Console.ReadLine());
            employees = new Employee[n];
            for(int j = 0; j < n; j++)
            {
                enterEmployee();
            }
        }
        public string getName()
        {
            return name;
        }
        public void enterEmployee()
        {
            employees[i] = new Employee();
            employees[i].setEmpDetails();
            i++;
        }
        public Employee[] getEmployees()
        {
            return employees;
        }
    }
    public class Employee : Manager
    {
        public int empid;
        string empName, desg;
        Attendance attendance;
        Salary salary;
        string managerName;
        public Employee()
        {
            managerName = name;
        }
        public void setEmpDetails()
        {
            Console.WriteLine("Enter employee id");
            empid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter employee Name");
            empName = Console.ReadLine();
            Console.WriteLine("Enter Designation");
            desg = Console.ReadLine();
            salary = new Salary();
            salary.setDetails();
        }
        public void getLeavesofAbsents()
        {
            attendance = new Attendance();
            attendance.getLeavesOrAbsents();
        }
        public void printEmployeeDetails()
        {
            Console.WriteLine("Employee id: "+ empid);
            Console.WriteLine("Name: " + empName);
            Console.WriteLine("Manager: " + managerName);
            Console.WriteLine("Designation: " + desg);
            Console.WriteLine("Salary: " + salary.getSalary());
        }
    }

    public class Attendance
    {
        int leaves=0,absents=0,noOfPresentsInMonth=31;
        public void getLeavesOrAbsents()
        {
            Console.WriteLine("What do you want to take. 1. for leaves, 2. for Absents");
            int n = Convert.ToInt32(Console.ReadLine());
            if (n == 1)
            {
                leaves += 1;
                Console.WriteLine("Leave given");
            }
            if(n == 2)
            {
                absents += 1;
                Console.WriteLine("Absent Given");
            }
        }
        public int TotalPresentDays()
        {
            return noOfPresentsInMonth - leaves - absents;
        }
    }

    public class Salary
    {
        int basic, da, hra, pf, gross, net;
        public int getSalary()
        {
            gross = basic + hra + da;
            net = gross - pf;
            return net;
        }
        public void setDetails()
        {
            Console.WriteLine("Enter basic");
            basic = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter da");
            da = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter hra");
            hra = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter pf");
            pf = Convert.ToInt32(Console.ReadLine());
        }
        public void printdetails()
        {
            Console.WriteLine("gross: " + gross + " net: " + net);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Department technical = new Department();
            technical.setDetails();
            Console.WriteLine("Enter employee id to find");
            int n = Convert.ToInt32(Console.ReadLine());
            technical.findEmpByid(n);
        }
    }
}
