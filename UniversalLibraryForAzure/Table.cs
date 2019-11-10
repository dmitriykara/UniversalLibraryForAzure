using System;
using System.Data.SqlClient;

namespace UniversalLibraryForAzure
{
    public class Table
    {
        /// <summary>
        /// Delete whole information from the table
        /// Don't delete the table
        /// </summary>
        public static void Clean()
        {
            SqlConnection connection = Connect.MakeNewConnect;
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = $@"TRUNCATE TABLE {Constants.BASENAME}"
                };

                command.ExecuteNonQuery();

                Console.WriteLine($"{Constants.BASENAME} cleaned");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        /// <summary>
        /// Show whole information in the table
        /// </summary>
        public static void Show()
        {
            SqlConnection connection = Connect.MakeNewConnect;
            try
            {
                connection.Open();

                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = $@"SELECT * FROM {Constants.BASENAME}"
                };

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string rowInfo = $"{reader.GetValue(0)}\t{reader.GetValue(1)}\t" +
                            $"{reader.GetValue(2)}\t{reader.GetValue(3)}\t{reader.GetValue(4)}\t{reader.GetValue(5)}\t";
                        Console.WriteLine(rowInfo);
                    }
                }
                reader.Close();

                Console.WriteLine($"{Constants.BASENAME} showed");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}