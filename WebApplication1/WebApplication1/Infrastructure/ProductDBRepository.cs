using WebApplication1.Models;
using System.Data.SqlClient;

namespace WebApplication1.Infrastructure
{
    public class ProductDBRepository : BaseRepository, IRepository<Product, int>
    {
        public IEnumerable<Product> FindAll()
        {
            var sql =
                "SELECT ProductId, ProductName, UnitPrice, UnitsInStock, Discontinued from Products";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@id","value"),
                new SqlParameter("@name","value")
            };
            List<Product> products = new List<Product>();
            try
            {
                var reader = ExecuteReader(sql, System.Data.CommandType.Text);
                while (reader.Read())
                {
                    products.Add(new Product
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        UnitPrice = reader.GetDecimal(2),
                        UnitInStock = reader.GetInt16(3),
                        Discontinued = reader.GetBoolean(4),
                    });
                }
                if(!reader.IsClosed) reader.Close();
            }catch (Exception) { throw; }
            finally { CloseConnection(); }
            return products;
        }

        public Product FindById(int id)
        {
            var sql =
                "SELECT ProductId,ProductName,UnitPrice,UnitsInStock" +
                ", Discontinued from Products where ProductId=@id";
            var parameters = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            Product product = null;
            try
            {
                var reader = ExecuteReader(sql, System.Data.CommandType.Text, parameters);
                if (reader.HasRows)
                {
                    reader.Read();
                    product = new Product
                    {
                        ProductId = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        UnitPrice = reader.GetDecimal(2),
                        UnitInStock = reader.GetInt16(3),
                        Discontinued = reader.GetBoolean(4),
                    };
                }
                if (!reader.IsClosed) reader.Close();
            }
            catch (Exception) { throw; }
            finally { CloseConnection(); }
            return product;
        }

        public void AddNew(Product entity)
        {
            System.Text.StringBuilder sqlbldr = new();
            sqlbldr.Append(" INSERT INTO Products( ")
                .Append(" productName,UnitPrice, UnitsInStock, Discontinued ")
                .Append(" ) VALUES ( ")
                .Append(" @name, @price, @stock, @discontinued ")
                .Append(" ) ");
            SqlParameter name = new SqlParameter("@name",entity.ProductName);
            SqlParameter price = new SqlParameter("@price",entity.UnitPrice);
            SqlParameter stock = new SqlParameter("@stock", entity.UnitInStock);
            SqlParameter disc = new SqlParameter("@discontinued",entity.Discontinued);
            try
            {
                ExecuteNonQuery(sqlbldr.ToString(),System.Data.CommandType.Text,name,price,stock,disc);
            }
            catch (Exception) { throw; }
            finally { CloseConnection(); }
        }

        public void DeleteById(int id)
        {
            System.Text.StringBuilder sqlbldr = new();
            sqlbldr.Append(" Delete from Products ")
                .Append(" where ProductId = @id ");
            SqlParameter parameterId = new SqlParameter("@id", id);
            try
            {
                ExecuteNonQuery(sqlbldr.ToString(), System.Data.CommandType.Text, parameterId);
            }
            catch (Exception) { throw; }
            finally { CloseConnection(); }
        }


        public void Update(Product entity)
        {
            System.Text.StringBuilder sqlbldr = new();
            sqlbldr.Append(" Update Products SET ")
                .Append(" productName =@name, ") 
                 .Append("UnitPrice=@price, ")
                 .Append(" UnitsInStock=@stock, ")
                 .Append(" Discontinued=@discontinued ")
                .Append(" where ProductId = @id ");
            SqlParameter name = new SqlParameter("@name", entity.ProductName);
            SqlParameter price = new SqlParameter("@price", entity.UnitPrice);
            SqlParameter stock = new SqlParameter("@stock", entity.UnitInStock);
            SqlParameter disc = new SqlParameter("@discontinued", entity.Discontinued);
            SqlParameter id = new SqlParameter("@id", entity.ProductId);
            try
            {
                ExecuteNonQuery(sqlbldr.ToString(), System.Data.CommandType.Text, name, price, stock, disc,id);
            }
            catch(SqlException sqlex)
            {
                throw new Exception(sqlex.Message,sqlex);
            }
            catch (Exception) { throw; }
            finally { CloseConnection(); }
        }
    }
}
