using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataSetExample
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hemang\Documents\DatabaseSQLDemo.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter adapter = new SqlDataAdapter("select * from items", conn);
            itemsdataset ds = new itemsdataset();
            adapter.Fill(ds,"items");
            foreach(DataRow dr in ds.Tables["items"].Rows)
            {
                Console.WriteLine(dr["itemname"] + " " + dr["price"]);
            }
        }
    }
}
