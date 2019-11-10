using System.Security.Cryptography;

namespace UniversalLibraryForAzure
{
    internal static class Constants
    {
        public const string BASENAME = "";
        public const int SIZE = 0;
        public const string SERVER = "";
        public const string DATABASE = "";
        public const string LOGIN = "";
        public const string PASSWORD = "";

        /// <summary>
        /// New MD5
        /// </summary>
        public static MD5 DM5HASH => MD5.Create();

        /// <summary>
        /// Connect to Azure Data Base
        /// </summary>
        public static string СonnectionString => $@"Data Source={SERVER}.database.windows.net;
                       Initial Catalog={DATABASE};
                       Integrated Security=True; 
                       User ID={LOGIN};
                       Password={PASSWORD}; 
                       Trusted_Connection=False; 
                       Encrypt=True;";
    }
}
