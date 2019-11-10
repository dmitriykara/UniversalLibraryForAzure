using System;
using System.Data.SqlClient;

namespace UniversalLibraryForAzure
{
    public class Registration
    {
        public static int CurrentId()
        {
            int currentid = -1;

            SqlConnection connection = Connect.MakeNewConnect;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = $@"SELECT * FROM Users"
                };

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        try
                        {
                            currentid = int.Parse(reader.GetValue(0).ToString());
                        }
                        catch
                        {
                            currentid = -1;
                        }
                    }
                    reader.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return currentid;
        }

        public static string Add(Client client)
        {
            string errorMessage = "OK";

            SqlConnection connection = Connect.MakeNewConnect;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = $@"INSERT INTO {Constants.BASENAME} VALUES (@id, @surname, 
                        @name, @secondname, @email, @password)"
                };

                command.Parameters.Add("@id", CurrentId() + 1);
                command.Parameters.Add("@surname", client.Surname);
                command.Parameters.Add("@name", client.Name);
                command.Parameters.Add("@secondname", client.Secondname);
                command.Parameters.Add("@email", client.Email);
                command.Parameters.Add("@password", MyOwnSecurity.Hash(client.Password));

                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }
            return errorMessage;
        }
    }
}
