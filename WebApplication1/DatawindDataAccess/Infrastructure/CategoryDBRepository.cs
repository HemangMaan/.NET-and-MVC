using System.Data.SqlClient;
using DatawindDataAccess.Models;

namespace DatawindDataAccess.Infrastructure
{
    public class CategoryDBRepository : BaseRepository, iCategoryRepository<Category, int>
    {
        public void AddNew(Category entity)
        {
            System.Text.StringBuilder sqlbldr = new();
            sqlbldr.Append(" INSERT INTO Categories( ")
                .Append(" CategoryName,Description ")
                .Append(" ) VALUES ( ")
                .Append(" @name, @description ")
                .Append(" ) ");
            SqlParameter name = new SqlParameter("@name", entity.CategoryName);
            SqlParameter desc = new SqlParameter("@description", entity.CategoryDescription);
            try
            {
                ExecuteNonQuery(sqlbldr.ToString(), System.Data.CommandType.Text, name, desc);
            }
            catch (Exception) { throw; }
            finally { CloseConnection(); }
        }

        public void DeleteById(int id)
        {
            System.Text.StringBuilder sqlbldr = new();
            sqlbldr.Append(" Delete from categories ")
                .Append(" where CategoryId = @id ");
            SqlParameter parameterId = new SqlParameter("@id", id);
            try
            {
                ExecuteNonQuery(sqlbldr.ToString(), System.Data.CommandType.Text, parameterId);
            }
            catch (Exception) { throw; }
            finally { CloseConnection(); }
        }

        public IEnumerable<Category> FindAll()
        {
            var sql =
                "SELECT CategoryId, CategoryName, Description from Categories";
            List<Category> category = new List<Category>();
            try
            {
                var reader = ExecuteReader(sql, System.Data.CommandType.Text);
                while (reader.Read())
                {
                    category.Add(new Category
                    {
                        CategoryId = reader.GetInt32(0),
                        CategoryName = reader.GetString(1),
                        CategoryDescription = reader.GetString(2),
                    });
                }
                if (!reader.IsClosed) reader.Close();
            }
            catch (Exception) { throw; }
            finally { CloseConnection(); }
            return category;
        }

        public Category FindById(int id)
        {
            var sql =
                "SELECT CategoryId,CategoryName,Description from categories where CategoryId=@id";
            var parameters = new SqlParameter[] {
                new SqlParameter("@id",id)
            };
            Category category = null;
            try
            {
                var reader = ExecuteReader(sql, System.Data.CommandType.Text, parameters);
                if (reader.HasRows)
                {
                    reader.Read();
                    category = new Category
                    {
                        CategoryId = reader.GetInt32(0),
                        CategoryName = reader.GetString(1),
                        CategoryDescription = reader.GetString(2),
                    };
                }
                if (!reader.IsClosed) reader.Close();
            }
            catch (Exception) { throw; }
            finally { CloseConnection(); }
            return category;
        }

        public void Update(Category entity)
        {
            System.Text.StringBuilder sqlbldr = new();
            sqlbldr.Append(" Update Categories SET ")
                .Append(" CategoryName =@name, ")
                 .Append("Description=@desc ")
                .Append(" where categoryId = @id ");
            SqlParameter name = new SqlParameter("@name", entity.CategoryName);
            SqlParameter desc = new SqlParameter("@desc", entity.CategoryDescription);
            SqlParameter id = new SqlParameter("@id", entity.CategoryId);
            
            try
            {
                ExecuteNonQuery(sqlbldr.ToString(), System.Data.CommandType.Text, name, desc,id);
            }
            catch (SqlException sqlex)
            {
                throw new Exception(sqlex.Message, sqlex);
            }
            catch (Exception) { throw; }
            finally { CloseConnection(); }
        }
    }
}
