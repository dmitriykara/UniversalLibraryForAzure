using System;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace UniversalLibraryForAzure
{
    public class Login
    {
        public static string CheckLogin(string email, string password, out Client client)
        {
            Client newClient = null;
            string errorMessage = "OK";

            SqlConnection connection = Connect.MakeNewConnect;

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand
                {
                    Connection = connection,
                    CommandText = $@"SELECT * FROM Users WHERE EMAIL='{email}'"
                };

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.GetValue(5).ToString() != MyOwnSecurity.Hash(password))
                        {
                            errorMessage = "Неверный пароль";
                        }
                        else
                        {
                            newClient = new Client(int.Parse(reader.GetValue(0).ToString()),
                                reader.GetValue(1).ToString(),
                                reader.GetValue(2).ToString(),
                                reader.GetValue(3).ToString(),
                                reader.GetValue(4).ToString(),
                                reader.GetValue(5).ToString());
                        }
                    }
                    reader.Close();
                }
                else
                {
                    client = null;
                    errorMessage = "Данная почта не зарегистрирована";
                }
            }
            catch (SqlException ex)
            {
                errorMessage = ex.Message;
            }
            finally
            {
                connection.Close();
            }

            client = null;
            if (newClient != null)
            {
                client = newClient;
            }

            return errorMessage;
        }
    }
}
