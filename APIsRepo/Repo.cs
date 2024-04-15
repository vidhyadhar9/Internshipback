using Microsoft.Data.SqlClient;
using System.Data;
using Common.Common;
using System.Linq.Expressions;
using System.Data.Common;

namespace APIsRepo
{
    public class Repo : IRepo1
    {
        private readonly IDbConnection _connection;
        public Repo(IDbConnection connection)
        {
            _connection = connection;
        }


        public async Task<List<Apis>> GetAll()
        {
            List<Apis> students = new List<Apis>();

            try
            {
                _connection.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in DB connection", ex);
            }

            string query = "Select * from Apis";

            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

            try
            {
                using (SqlDataReader reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        Apis student = new Apis()
                        {
                            date = Convert.ToString(reader["Dates"]),
                            events = Convert.ToString(reader["Evnets"]),
                          


                        };
                        Console.WriteLine("reading the table succussfully");
                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errorn in reading the data base", ex.Message);
            }
            finally { _connection.Close(); }
            return students;

        }




        //posting the data
       
        public async Task<bool>Post(string date,string events)
        {
            try
            {
                _connection.Open();
                Console.WriteLine("opening the db connection ");

            }
            catch (Exception ex)
            {
                Console.WriteLine("error in opening the db connection ", ex.Message);
            }
            string query = "Insert into Apis  values (@value1,@value2) ";



            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

            command.Parameters.AddWithValue("@value1",date);
            command.Parameters.AddWithValue("@value2", events); // Replace with actual property roll from Students class

            try
            {
                Console.WriteLine("Data item are", command.CommandText);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Data inserted successfully");
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine("error while inserting the query", ex.Message);
                return false;
            }
            finally { _connection.Close(); }

        }
    
    }
}
