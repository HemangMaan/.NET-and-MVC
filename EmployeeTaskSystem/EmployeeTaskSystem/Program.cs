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
        /*public class Task
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
        }*/
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

            public void createAndAssignTask()
            {
                Console.WriteLine("Enter the Task id");
                int task_id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Task");
                string task = Console.ReadLine();
                Console.Write("Enter a deadline (e.g. 2022-01-27): ");
                DateTime inputtedDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter the employee id to assign task.");
                int emp_id = Convert.ToInt32(Console.ReadLine());
                try
                {
                    sqlcon.Open();
                    string query = "Insert into TaskList values(@task_id,@task,@deadline,@emp_id)";
                    SqlCommand command = new SqlCommand(query,sqlcon);
                    command.Parameters.Add("@task_id",System.Data.SqlDbType.Int);
                    command.Parameters.Add("@task", System.Data.SqlDbType.NVarChar);
                    command.Parameters.Add("@deadline", System.Data.SqlDbType.DateTime);
                    command.Parameters.Add("@emp_id", System.Data.SqlDbType.Int);
                    command.Parameters["@task_id"].Value = task_id;
                    command.Parameters["@task"].Value = task;
                    command.Parameters["@deadline"].Value= inputtedDate;
                    command.Parameters["@emp_id"].Value= emp_id;
                    int i = command.ExecuteNonQuery();
                    Console.WriteLine("Rows affected: " + i);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { sqlcon?.Close(); }
            }

            public void UpdateTask(int task_id)
            {
                Console.WriteLine("What do you want to update in Task?" +
                    "\nPress 1 to Update Task." +
                    "\nPress 2 to Update Employee Assigned to task.");
                int n = Convert.ToInt32(Console.ReadLine());
                string query = "";
                switch (n)
                {
                    case 1:
                        Console.WriteLine("Enter New Task");
                        string task = Console.ReadLine();
                        query = "update TaskList set task='"+task+"' where task_id="+task_id;
                        break;
                    case 2:
                        Console.WriteLine("Enter Employee id");
                        int emp_id = Convert.ToInt32(Console.ReadLine());
                        query = "update TaskList set emp_id=" + emp_id + " where task_id=" + task_id;
                        break;
                    default:
                        Console.WriteLine("Wrong Input.");
                        break;
                }
                try
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand(query,sqlcon);
                    int i = cmd.ExecuteNonQuery();
                    Console.WriteLine("Rows affected: " + i);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally { sqlcon?.Close(); }
            }

            public void DeleteTask(int task_id)
            {
                try
                {
                    sqlcon?.Open();
                    string query = "delete from TaskList where task_id=" + task_id;
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    int i = cmd.ExecuteNonQuery();
                    Console.WriteLine("Rows Affected: " + i);
                }
                catch(Exception ex) { Console.WriteLine(ex.Message); }
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
                    string query = "create table TaskList(task_id int primary key,task varchar(50),deadline DATE,emp_id int)";
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
            public void createRatingTable()
            {
                try
                {
                    sqlcon.Open();
                    string query = "create table Rating(task_id int, task_id int, Rating int,emp_id int)";
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
            
            public void displaydata()
            {
                string query = "select * from employee";
                try
                {
                    sqlcon.Open();
                    if (sqlcon.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand(query, sqlcon);
                        SqlDataReader reader = cmd.ExecuteReader();
                        Console.WriteLine("EmpId\t Name\t Address");
                        while (reader.Read())
                        {
                            Console.WriteLine(reader[0] + "\t " + reader[1] + "\t " + reader[2]);
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
        static void Main(string[] args)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hemang\Documents\DatabaseSQLDemo.mdf;Integrated Security=True;Connect Timeout=30");
            SqlConn conn = new SqlConn(sqlcon);
            conn.createTaskListTable();
            Admin admin = new Admin(sqlcon);
            admin.createAndAssignTask();
        }
    }
}
