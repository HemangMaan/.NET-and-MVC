using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace TrainingJan24
{
    internal class Program
    {

        public class ProductData
        {
            DataSet ds;
            public void CreateDataSet()
            {
                ds = new DataSet("ProductDataSet");
                DataTable datatable =  ds.Tables.Add("Product");
                DataColumn dataColumn1 = datatable.Columns.Add("Product_Id");
                DataColumn dataColumn2 = datatable.Columns.Add("Product_Name");
                DataColumn dataColumn3 = datatable.Columns.Add("Price");
                DataColumn dataColumn4 = datatable.Columns.Add("Quantity");

                DataRow row1 = datatable.Rows.Add(1, "Coffee", 50, 2);
                DataRow row2 = datatable.Rows.Add(2, "Tea", 55, 3);
                DataRow row3 = datatable.Rows.Add(3, "Milk", 33, 2);
            }

            public void showDataSet()
            {
                DataTable dt = ds.Tables["Product"];
                foreach(DataRow row in dt.Rows)
                {
                    Console.WriteLine(row["Product_Id"]);
                    Console.WriteLine(row["Product_Name"]);
                    Console.WriteLine(row["Price"]);
                    Console.WriteLine(row["Quantity"]);
                }
                
            }
        }

        public class sqlConn
        {
            SqlConnection sqlcon;
            public sqlConn(SqlConnection sqlcon)
            {
                this.sqlcon = sqlcon;
            }
            public void createTable()
            {
                try
                {
                    sqlcon.Open();
                    string query = "create table employee(customer_id int primary key,customer_name varchar(20),address varchar(20))";
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
            public void insertdata()
            {
                Console.WriteLine("Enter id");
                int empid = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter Name");
                string name = Console.ReadLine();
                Console.WriteLine("Enter address");
                string add = Console.ReadLine();
                try
                {
                    string query = "Insert into employee values(" + empid + ",'" + name + "','" + add + "')";
                    sqlcon.Open();
                    if (sqlcon.State == ConnectionState.Open)
                    {
                        SqlCommand cmd = new SqlCommand(query, sqlcon);
                        int i = cmd.ExecuteNonQuery();
                        Console.WriteLine("No of rows affected: " + i);
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    sqlcon?.Close();
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
            try
            {
                DataSet ds = new DataSet();
                SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\hemang\Documents\DatabaseSQLDemo.mdf; Integrated Security = True; Connect Timeout = 30");
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter("select * from items", conn);
                adapter.Fill(ds,"items");
                DataTable dt = ds.Tables["items"];
                foreach(DataRow dr in dt.Rows)
                {
                    Console.WriteLine(dr[0]);
                }
                conn.Close();
                
                /*sqlConn connection = new sqlConn(conn);

                connection.createTable();
                connection.insertdata();
                connection.insertdata();
                connection.insertdata();
                connection.displaydata();*/
            }
            catch { }
            /* ProductData pd = new ProductData();
             pd.CreateDataSet();
             pd.showDataSet();*/


        }
    }
}
