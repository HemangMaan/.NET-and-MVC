using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeTaskSystem
{
    public class Employee
    {
        SqlConnection sqlcon;
        int employee_id = 0;
        string pass = "";
        public Employee(SqlConnection sqlCon)
        {
            this.sqlcon = sqlCon;
        }
        public bool Login()
        {
            Console.WriteLine("Enter Emp_id");
            employee_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Password");
            pass = Console.ReadLine();
            try
            {
                sqlcon.Open();
                string query = "select emp_id,password from employee where emp_id="+employee_id;
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if ((int)reader[0] == employee_id && (string)reader[1] == pass)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            finally { sqlcon.Close(); }
            return false;
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

        public void MarkAttendance()
        {
            string query = "";
            Console.WriteLine("Press \n1. Present \n2. Absent \n3. Leave\n4. Not Marked. ");
            int x = Convert.ToInt32(Console.ReadLine());
            switch (x)
            {
                case 1:
                    query = "insert into Attendance values(GETDATE(),'Present'," + employee_id + ")";
                    break;
                case 2:
                    query = "insert into Attendance values(GETDATE(),'Absent'," + employee_id + ")";
                    break;
                case 3:
                    query = "insert into Attendance values(GETDATE(),'Leave'," + employee_id + ")";
                    break;
                default:
                    query = "insert into Attendance values(GETDATE(),'Not Marked'," + employee_id + ")";
                    break;
            }
            executegivenQuery(query);
        }

        public void ViewTasks()
        {
            string query = "select task_id,task,deadline from TaskList where emp_id=" + employee_id;
            try
            {
                sqlcon.Open();
                if (sqlcon.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("Task_id\tTask\tDeadline");
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

        public void AddRemarks()
        {
            Console.WriteLine("Enter Task id");
            int task_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Write the Remark.");
            string remark = Console.ReadLine();
            string query = "update TaskList set remark='" + remark + "' where task_id=" + task_id;
            executegivenQuery(query);
        }

        public void DeadlineExtension()
        {
            Console.WriteLine("Enter Task id");
            int task_id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("How many days extension you required.");
            string remark = Console.ReadLine();
            string query = "update TaskList set remark='" + remark + "',extension="+1+" where task_id=" + task_id;
            executegivenQuery(query);
        }

        public void ViewAttendance()
        {
            string query = "select * from Attendance where emp_id=" + employee_id;
            try
            {
                sqlcon.Open();
                if (sqlcon.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("Attendance Id\t Date \t Status");
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

}
