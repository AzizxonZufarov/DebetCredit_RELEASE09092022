using DebetCredit.Database;
using Npgsql;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DebetCredit.Services
{
    public class LoginService
    {
        private PostgresDatabase database = new PostgresDatabase();

        public int Login(string userName, string password)
        {
            var query = @"SELECT ""ID"" FROM ""User"" WHERE ""Username"" = @Username AND ""Hash"" = @Hash LIMIT 1;";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Hash", GetHashString(password)),
                new NpgsqlParameter("@Username", userName)
            };

            var user = database.Query(query, parameters).FirstOrDefault();

            if (user is null)
            {
                return -1;
            }

            return (int)user[0];
        }

        public void RegUser()
        {
            var username = "admin";
            var password = "pass";

            var query = @"INSERT INTO ""User"" (""Username"", ""Hash"") VALUES ( @Username, @Hash );";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Hash", GetHashString(password)),
                new NpgsqlParameter("@Username", username)
            };

            database.Execute(query, parameters);
        }

        static string GetHashString(string input)
        {
            byte[] hash;

            using (HashAlgorithm algorithm = SHA256.Create())
            {
                hash = algorithm.ComputeHash(Encoding.UTF8.GetBytes(input));
            }

            var sb = new StringBuilder();

            foreach (byte b in hash)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }

    }
}