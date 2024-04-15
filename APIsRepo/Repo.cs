using Microsoft.Data.SqlClient;
using System.Data;
using Common.Common;
using System.Linq.Expressions;
using System.Data.Common;
using Microsoft.Extensions.Logging;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
                       
                        students.Add(student);
                    }
                    Console.WriteLine("reading the table succussfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Errorn in reading the data base", ex.Message);
            }
            finally { _connection.Close(); }
            return students;

        }


        public async Task<List<Apis>> GetByDate(string date)
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

            string query = "Select * from Apis where Dates=@value";


            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

            command.Parameters.AddWithValue("@value", date);
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

        public async Task<bool> Post(string date, string events)
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

            command.Parameters.AddWithValue("@value1", date);
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

        public async Task<bool> Update(string curDate, string curEvents, string newDate, string newEvents)
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
            string query = "Update Apis set Dates=@value1,Evnets=@value2 where Dates=@value3 and Evnets=@value4 ";



            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);

            command.Parameters.AddWithValue("@value1", newDate);
            command.Parameters.AddWithValue("@value2", newEvents); // Replace with actual property roll from Students class
            command.Parameters.AddWithValue("@value3", curDate);
            command.Parameters.AddWithValue("@value4", curEvents);
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


        public async Task<bool> Remove(string curDate, string curEvents)
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


            string query = "Delete from Apis where Dates=@value1 and Evnets=@value2 ";



            SqlCommand command = new SqlCommand(query, (SqlConnection)_connection);
            // Replace with actual property roll from Students class
            command.Parameters.AddWithValue("@value1", curDate);
            command.Parameters.AddWithValue("@value2", curEvents);
            try
            {
                Console.WriteLine("Data item are", command.CommandText);
                await command.ExecuteNonQueryAsync();
                Console.WriteLine("Data deleted successfully");
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