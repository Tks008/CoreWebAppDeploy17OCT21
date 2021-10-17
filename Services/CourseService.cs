using CoreWebAppDeploy1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebAppDeploy1.Services
{
    public class CourseService
    {
        private static string db_source = "tkssqlserver.database.windows.net";
        private static string db_user = "tks007";
        private static string db_password = "Tksantra@123";
        private static string db_database = "tksDatabase";

        private SqlConnection GetConnection()
        {
            // Here we are creating the SQL connection
            var _builder = new SqlConnectionStringBuilder();
            _builder.DataSource = db_source;
            _builder.UserID = db_user;
            _builder.Password = db_password;
            _builder.InitialCatalog = db_database;
            return new SqlConnection(_builder.ConnectionString);
        }
        public IEnumerable<Models.Course> GetCourses(SqlConnection sqlConnection)
        {
            List<Course> _lst = new List<Course>();
            string _statement = "SELECT Id,Name,rating from Course";
            SqlConnection _connection = GetConnection();
            // Let's open the connection
            _connection.Open();
            // We then construct the statement of getting the data from the Course table
            SqlCommand _sqlcommand = new SqlCommand(_statement, sqlConnection);
            // Using the SqlDataReader class , we will read all the data from the Course table
            using (SqlDataReader _reader = _sqlcommand.ExecuteReader())
            {
                while (_reader.Read())
                {
                    Course _course = new Course()
                    {
                        ID = _reader.GetInt32(0),
                        Name = _reader.GetString(1),
                        Rating = _reader.GetDecimal(2)
                    };

                    _lst.Add(_course);
                }
            }
            _connection.Close();
            return _lst;
        }
    }
}
