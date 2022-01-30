using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeTaskSystem
{
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
                string query = "Insert into employee values(" + empid + ",'" + name + "','" + dept + "','" + desg + "','" + pass + "'," + su_id + ")";
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
                string query = "Insert into TaskList(task,deadline) values(@task,@deadline)";
                SqlCommand command = new SqlCommand(query, sqlcon);
                command.Parameters.Add("@task", System.Data.SqlDbType.NVarChar);
                command.Parameters.Add("@deadline", System.Data.SqlDbType.DateTime);
                command.Parameters["@task"].Value = task;
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
            string query = "update TaskList set task='" + task + "' where task_id=" + task_id;
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
            string query = "update TaskList set deadline=@deadline where task_id=" + task_id;
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

        public void viewDeadlineRequestTasks()
        {
            string query = "select * from TaskList where extension=1";
            try
            {
                sqlcon.Open();
                if (sqlcon.State == ConnectionState.Open)
                {
                    SqlCommand cmd = new SqlCommand(query, sqlcon);
                    SqlDataReader reader = cmd.ExecuteReader();
                    Console.WriteLine("Task_id\t Emp_id\t Deadline\t Task\t Remark\t Extension Required");
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0] + "\t " + reader[3] + "\t " + reader[2] + "\t" + reader[1] + "\t" + reader[5]+"\t Yes");
                    }
                }
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
                    Console.WriteLine("Task_id\t Emp_id\t Deadline\t Task\t Remark\t Rating");
                    while (reader.Read())
                    {
                        Console.WriteLine(reader[0] + "\t " + reader[3] + "\t " + reader[2] + "\t" + reader[1] + "\t" + reader[5]+"\t"+reader[4]);
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
                        Console.WriteLine(reader[0] + "\t " + reader[1] + "\t " + reader[2] + "\t" + reader[3] + "\t " + reader[4] + "\t" + reader[5]);
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
