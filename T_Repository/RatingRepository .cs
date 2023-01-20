using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T_Repository
{
    public class RatingRepository : IRatingRepository
    {
        private string _connection;


        public RatingRepository(string connectionstring)
        {
            _connection = connectionstring;

        }
        public async Task add_request(Rating rating)
        {
            
              string query = "INSERT INTO [dbo].[RATING]([HOST],[METHOD],[PATH],[Record_Date])" +
                             "values(@HOST,@METHOD,@PATH,@Record_Date)";
                using (SqlConnection sqlconnection = new SqlConnection(_connection))
                using (SqlCommand sqlcommand = new SqlCommand(query, sqlconnection))
                {
                    sqlcommand.Parameters.Add("@HOST", SqlDbType.NVarChar, 50).Value = rating.Host;
                    sqlcommand.Parameters.Add("@METHOD", SqlDbType.NChar, 10).Value = rating.Method;
                    sqlcommand.Parameters.Add("@PATH", SqlDbType.NVarChar, 50).Value = rating.Path;
                    sqlcommand.Parameters.Add("@Record_Date", SqlDbType.DateTime).Value = rating.RecordDate;
                   
                    sqlcommand.Connection.Open();
                    int result = sqlcommand.ExecuteNonQuery();


                }
            }
        }
    }

