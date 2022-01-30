using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace EmployeeTaskSystem
{
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
                string query = "create table TaskList(task_id int primary key IDENTITY(1,1),task varchar(50),deadline DATE,emp_id int,rating int,remark varchar(70),extension BIT)";
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
}
