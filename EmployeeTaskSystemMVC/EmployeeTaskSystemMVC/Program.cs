using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using EmployeeTaskSystemMVC.Model;

namespace EmployeeTaskSystemMVC
{
    internal class Program
    {
        public enum Rating
        {
            POOR = 1,
            GOOD = 2,
            AVERAGE = 3,
            EXCELLENT = 4,
        }
        public enum Attendance_Types
        {
            ABSENT = 0,
            PRESENT = 1,
            LEAVE = 2,
            NOT_MARKED = 3
        }

        static void Main(string[] args)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hemang\Documents\DatabaseSQLDemo.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConn conn = new SqlConn(sqlcon);
            conn.createEmployeeTable();
            conn.createTaskListTable();
            conn.createAttendanceTable();
            bool m = true;
            while (m)
            {
                Console.WriteLine("Who are you?\n Press 1. For Admin 2. For Employee.\n 3. Exit");
                int a = Convert.ToInt32(Console.ReadLine());
                if (a == 1)
                {
                    Admin admin = new Admin(sqlcon);
                    bool flag = true;
                    while (flag)
                    {
                        Console.WriteLine("Enter the Operation You want to Perform.\n" +
                            "1. To Add the Employee.\n" +
                            "2. To Add the Task.\n" +
                            "3. View Tasks.\n" +
                            "4. Assign Task to Employee.\n" +
                            "5. Update Task.\n" +
                            "6. Change Task Deadline.\n" +
                            "7. Rate employee based on task completion status.\n" +
                            "8. Delete Task.\n" +
                            "9. View Employees.\n" +
                            "10. Any Other Number to Exit.");
                        int n = Convert.ToInt32(Console.ReadLine());
                        int t;
                        switch (n)
                        {
                            case 1:
                                admin.RegisterEmployee();
                                break;
                            case 2:
                                admin.createTask();
                                break;
                            case 3:
                                admin.viewTasks();
                                break;
                            case 4:
                                Console.WriteLine("Enter Task id which you want to assign.");
                                t = Convert.ToInt32(Console.ReadLine());
                                admin.MapEmployeeToTask(t);
                                break;
                            case 5:
                                Console.WriteLine("Enter Task id which you want to assign.");
                                t = Convert.ToInt32(Console.ReadLine());
                                admin.UpdateTask(t);
                                break;
                            case 6:
                                Console.WriteLine("Enter Task id which you want to change deadline.");
                                t = Convert.ToInt32(Console.ReadLine());
                                admin.ChangeTaskDeadline(t);
                                break;
                            case 7:
                                Console.WriteLine("Enter Task id which you want to Rate.");
                                t = Convert.ToInt32(Console.ReadLine());
                                admin.RateEmployee(t);
                                break;
                            case 8:
                                Console.WriteLine("Enter Task id which you want to Delete.");
                                t = Convert.ToInt32(Console.ReadLine());
                                admin.DeleteTask(t);
                                break;
                            case 9:
                                admin.viewEmployee();
                                break;
                            default:
                                flag = false;
                                break;
                        }
                    }
                }
                else if (a == 2)
                {
                    Employee employee = new Employee(sqlcon);
                    if (employee.Login())
                    {
                        bool flag = true;
                        while (flag)
                        {
                            Console.WriteLine("Enter the Operation You want to Perform.\n" +
                                "1. Mark Attendance\n" +
                                "2. View Tasks\n" +
                                "3. Add Remarks\n" +
                                "4. Request for deadline review");
                            int n = Convert.ToInt32(Console.ReadLine());
                            switch (n)
                            {
                                case 1:
                                    employee.MarkAttendance();
                                    break;
                                case 2:
                                    employee.ViewTasks();
                                    break;
                                case 3:
                                    employee.AddRemarks();
                                    break;
                                case 4:
                                    break;
                                default:
                                    flag = false;
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Employee Not Found. Register Employee.");
                    }
                }
                else
                {
                    m = false;
                }
            }
        }
    }
}
