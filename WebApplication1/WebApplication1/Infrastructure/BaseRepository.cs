using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Infrastructure
{
    public abstract class BaseRepository
    {
        private readonly string _connectionString;
        private SqlConnection _connection;

        public BaseRepository()
        {
            _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hemang\Documents\northwind.mdf;Integrated Security=True;Connect Timeout=30";
            
        }
        protected void CreateConnection()
        {
            if (_connection == null)
                _connection = new SqlConnection(_connectionString);
        }

        protected void OpenConnection()
        {
            CreateConnection();
            if(_connection.State!=System.Data.ConnectionState.Open)
                _connection.Open();
        }
        protected void CloseConnection()
        {
            if( _connection != null)
                if (_connection.State != System.Data.ConnectionState.Closed)
                    _connection.Close();
        }
        protected SqlDataReader ExecuteReader(string cmdText,CommandType cmdType)
        {
            return ExecuteReader(cmdText, cmdType, null);
        }
        protected SqlDataReader ExecuteReader(string cmdText,CommandType cmdType,SqlParameter[] parameters)
        {
            OpenConnection();
            SqlCommand cmd = _connection.CreateCommand();
            cmd.CommandText = cmdText;
            cmd.CommandType = cmdType;
            if(parameters?.Length > 0)
            {
                foreach(var parameter in parameters)
                    cmd.Parameters.Add(parameter);
            }
            return cmd.ExecuteReader();
        }

        protected void ExecuteNonQuery(string cmdText,
            CommandType cmdType = CommandType.Text,
            params SqlParameter[] parameters)
        {
            OpenConnection();
            var cmd = new SqlCommand(cmdText, _connection);
            cmd.CommandType = cmdType;
            if(parameters.Length > 0)
                cmd.Parameters.AddRange(parameters);
            cmd.ExecuteNonQuery();
            return;
        }

    }
}
