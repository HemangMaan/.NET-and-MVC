using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeTaskSystem
{
    internal class Program
    {
        public enum Rating
        {
            POOR=1,
            GOOD=2,
            AVERAGE=3,
            EXCELLENT=4,
        }
        public enum Attendance_Types
        {
            ABSENT=0,
            PRESENT=1,
            LEAVE=2,
            NOT_MARKED=3
        }
        public class Task
        {
            int taskid;
            string name;
            string description;
            DateTime dateOfAllocation;
            DateTime deadline;
            Employee allocatedTo;
        }

        public class Attendance
        {
            int attendanceId;
            DateTime date;

        }

        public class Employee_Rating
        {
            Task task;
            Rating rating;
        }
        public class Employee
        {
            int employeeId;
            string name;
            string department;
            string designation;
            string password;
            Employee superior;
            List<Task> tasks;
            List<Attendance> attendances;
            Rating rating;
        }
        public static bool Login()
        {
            Console.WriteLine("Enter Emp_id");
            int employee_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Password");
            string pass = Console.ReadLine();
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hemang\Documents\DatabaseSQLDemo.mdf;Integrated Security=True;Connect Timeout=30");
            try
            {
                sqlcon.Open();
                string query = "select emp_id,password from employee";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if((int)reader[0]==employee_id && (string)reader[4] == pass)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                sqlcon.Close();
            }
            return false;
        }

        public class Admin
        {
            SqlConnection sqlcon;
            public Admin(SqlConnection sqlcon)
            {
                this.sqlcon = sqlcon;
            }

            public void RegisterEmployee()
            {
                Console.WriteLine("Enter Employee id");
                int empid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Department");
                string dept = Console.ReadLine();
                Console.WriteLine("Enter designation");
                string desg = Console.ReadLine();
                Console.WriteLine("Enter Password");
                string pass = Console.ReadLine();
                Console.WriteLine("Enter Superior Employee id");
                int su_id = Convert.ToInt32(Console.ReadLine());
                try
                {
                    string query = "Insert into employee values(" + empid + ",'" + name + "','" + dept + "','"+desg+"','"+pass+"',"+su_id +")";
                    sqlcon.Open();
                    if (sqlcon.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand(query, sqlcon);
                        int i = cmd.ExecuteNonQuery();
                        Console.WriteLine("No of rows affected: " + i);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlcon?.Close();
                }
            }

            public void createTask()
            {
                Console.WriteLine("Enter Task");
                string task = Console.ReadLine();
                Console.Write("Enter a deadline (e.g. 2022-01-27): ");
                DateTime inputtedDate = DateTime.Parse(Console.ReadLine());
                try
                {
                    sqlcon.Open();
                    string query = "Insert into TaskList values(@task,@deadline)";
                    SqlCommand command = new SqlCommand(query,sqlcon);
                    command.Parameters.Add("@task", System.Data.SqlDbType.NVarChar);
                    command.Parameters.Add("@deadline", System.Data.SqlDbType.DateTime);
                    command.Parameters["@task"].Value = task;
                    command.Parameters["@deadline"].Value= inputtedDate;
                    int i = command.ExecuteNonQuery();
                    Console.WriteLine("Rows affected: " + i);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { sqlcon?.Close(); }
            }

            public void executegivenQuery(string query)
            {
                try
                {
                    sqlcon.Open();
                    SqlCommand command = new SqlCommand(query, sqlcon);
                    int i = command.ExecuteNonQuery();
                    Console.WriteLine("Rows Affected: " + i);
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally { sqlcon?.Close(); }
            }

            public void MapEmployeeToTask(int task_id)
            {
                Console.WriteLine("Enter the employee id to assign task.");
                int emp_id = Convert.ToInt32(Console.ReadLine());
                string query = "update TaskList set emp_id=" + emp_id + " where task_id=" + task_id;
                executegivenQuery(query);  
            }

            public void UpdateTask(int task_id)
            {
                Console.WriteLine("Enter the New Task to Update.");
                string task = Console.ReadLine();
                string query = "update TaskList set task='"+task+"' where task_id="+task_id;
                executegivenQuery(query);
            }

            public void DeleteTask(int task_id)
            {
                string query = "delete from TaskList where task_id=" + task_id;
                executegivenQuery(query);
            }

            public void RateEmployee(int task_id)
            {
                Console.WriteLine("Rate the task Completed by the employee From 1 to 4.");
                int r = Convert.ToInt32(Console.ReadLine());
                string query = "update TaskList set rating=" + r + "where task_id=" + task_id;
                executegivenQuery(query);
            }

            public void ChangeTaskDeadline(int task_id)
            {
                Console.WriteLine("Enter new Deadline.");
                DateTime inputtedDate = DateTime.Parse(Console.ReadLine());
                string query = "update TaskList set deadline=@deadline where task_id="+task_id;
                try
                {
                    sqlcon.Open();
                    SqlCommand command = new SqlCommand(query, sqlcon);
                    command.Parameters.Add("@deadline", System.Data.SqlDbType.DateTime);
                    command.Parameters["@deadline"].Value = inputtedDate;
                    int i = command.ExecuteNonQuery();
                    Console.WriteLine("Rows affected: " + i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { sqlcon?.Close(); }
            }

            public void viewTasks()
            {
                string query = "select * from TaskList";
                try
                {
                    sqlcon.Open();
                    if (sqlcon.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand(query, sqlcon);
                        SqlDataReader reader = cmd.ExecuteReader();
                        Console.WriteLine("Task_id\t Emp_id\t Deadline\t Task");
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0] + "\t " + reader[3] + "\t " + reader[2]+"\t"+reader[1]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { sqlcon?.Close(); }
            }

            public void viewEmployee()
            {
                string query = "select * from employee";
                try
                {
                    sqlcon.Open();
                    if (sqlcon.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand(query, sqlcon);
                        SqlDataReader reader = cmd.ExecuteReader();
                        Console.WriteLine("emp_id\t Name\t Department\t Designation\t password \t superior");
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0] + "\t " + reader[1] + "\t " + reader[2] + "\t" + reader[3]+"\t " + reader[4] + "\t" + reader[5]);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { sqlcon?.Close(); }
            }
        }


        public class SqlConn
        {
            SqlConnection sqlcon;
            public SqlConn(SqlConnection sqlcon)
            {
                this.sqlcon = sqlcon;
            }
            public void createEmployeeTable()
            {
                try
                {
                    sqlcon.Open();
                    string query = "create table employee(emp_id int primary key,name varchar(20),department varchar(20),designation varchar(20),password varchar(20),superior int)";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    int i = cmd.ExecuteNonQuery();
                    Console.WriteLine("No of rows affected: " + i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlcon.Close();
                }
            }
            public void createTaskListTable()
            {
                try
                {
                    sqlcon.Open();
                    string query = "create table TaskList(task_id int primary key IDENTITY(1,1),task varchar(50),deadline DATE,emp_id int,rating int,remark varchar(50))";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    int i = cmd.ExecuteNonQuery();
                    Console.WriteLine("No of rows affected: " + i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlcon.Close();
                }
            }
            public void createAttendanceTable()
            {
                try
                {
                    sqlcon.Open();
                    string query = "create table Attendance(attendance_id int primary key IDENTITY(1,1),date DATE, status varchar(50),emp_id int)";
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    int i = cmd.ExecuteNonQuery();
                    Console.WriteLine("No of rows affected: " + i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlcon.Close();
                }
            }
            
        }
        static void Main(string[] args)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hemang\Documents\DatabaseSQLDemo.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConn conn = new SqlConn(sqlcon);
            conn.createEmployeeTable();
            conn.createTaskListTable();
            conn.createAttendanceTable();
            Console.WriteLine("Are you the Admin?\n Press 1. For Yes 2. For No.");
            int a = Convert.ToInt32(Console.ReadLine());
            if(a == 1)
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
            
        }
    }
}
