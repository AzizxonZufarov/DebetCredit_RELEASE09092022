using Npgsql;
using System.Collections.Generic;

namespace DebetCredit.Database
{
    public class PostgresDatabase
    {
        private NpgsqlConnectionStringBuilder connectionBuilder = new NpgsqlConnectionStringBuilder()
        {
            Port = 5433,
            Password = "admin",
            Host = "localhost",
            Username = "postgres",
            Database = "DebetCredit"
        };

        public void PrepareTables()
        {
            PrepareUserTable();
            PrepareBalanceTable();
            PrepareCategoryTable();
            PrepareBalanceTypeTable();
        }

        public void DropTables()
        {
            Execute(@"DROP TABLE IF EXISTS ""User""");
            Execute(@"DROP TABLE IF EXISTS ""Balance""");
            Execute(@"DROP TABLE IF EXISTS ""Category""");
            Execute(@"DROP TABLE IF EXISTS ""BalanceType""");
        }

        public List<object[]> Query(string query, NpgsqlParameter[] parameters = null)
        {
            var output = new List<object[]>();

            using (var connection = new NpgsqlConnection(connectionBuilder.ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddRange(parameters ?? new NpgsqlParameter[0]);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                var row = new object[reader.FieldCount];

                                for (var i = 0; i < row.Length; i++)
                                {
                                    row[i] = reader.GetValue(i);
                                }

                                output.Add(row);
                            }
                        }
                    }
                }

                connection.Close();
            }

            return output;
        }

        public void Execute(string query, NpgsqlParameter[] parameters = null)
        {
            using (var connection = new NpgsqlConnection(connectionBuilder.ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    command.Parameters.AddRange(parameters ?? new NpgsqlParameter[0]);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        private void PrepareUserTable()
        {
            var sql =
                "CREATE TABLE IF NOT EXISTS \"User\" ( " +
                    "\"ID\" SERIAL PRIMARY KEY, " +
                    "\"Username\" VARCHAR(100) NOT NULL, " +
                    "\"Hash\" VARCHAR(64) NOT NULL " +
                ");";

            Execute(sql);
        }

        private void PrepareBalanceTable()
        {
            var sql =
                "CREATE TABLE IF NOT EXISTS \"Balance\" ( " +
                    "\"ID\" SERIAL PRIMARY KEY, " +
                    "\"Date\" DATE NOT NULL, " +
                    "\"TypeID\" INT NOT NULL, " +
                    "\"CategoryID\" INT NOT NULL, " +
                    "\"Amount\" INT NOT NULL, " +
                    "\"Comment\" VARCHAR(200) NOT NULL" +
                ");";

            Execute(sql);
        }

        private void PrepareCategoryTable()
        {
            Execute(@"CREATE TABLE IF NOT EXISTS ""Category"" ( ""ID"" SERIAL PRIMARY KEY, ""TypeID"" INT NOT NULL, ""Name"" VARCHAR(200) NOT NULL );");
            Execute(@"INSERT INTO ""Category"" (""TypeID"", ""Name"") VALUES ( 1, 'Неизвестно' )");
        }

        private void PrepareBalanceTypeTable()
        {
            Execute(@"CREATE TABLE IF NOT EXISTS ""BalanceType"" ( ""ID"" SERIAL PRIMARY KEY, ""Name"" VARCHAR(100) NOT NULL );");
            Execute(@"INSERT INTO ""BalanceType"" ( ""Name"" ) VALUES ( 'Доход' ), ( 'Расход' )");
        }
    }
}
