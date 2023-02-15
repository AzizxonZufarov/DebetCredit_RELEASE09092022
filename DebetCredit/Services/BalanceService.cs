using DebetCredit.Database;
using DebetCredit.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DebetCredit.Services
{
    public class BalanceService
    {
        private PostgresDatabase database = new PostgresDatabase();

        public void Add(BalanceDB balance)
        {
            if (balance.Amount < 0)
            {
                throw new ArgumentException("Amount");
            }

            var sql = @"INSERT INTO ""Balance""" +
                      @"  ( ""Date"", ""TypeID"", ""CategoryID"", ""Amount"", ""Comment"" ) " +
                      @"VALUES" +
                      @"  ( @Date, @TypeID, @CategoryID, @Amount, @Comment );";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Date", balance.Date),
                new NpgsqlParameter("@TypeID", balance.TypeID),
                new NpgsqlParameter("@CategoryID", balance.CategoryID),
                new NpgsqlParameter("@Amount", balance.Amount),
                new NpgsqlParameter("@Comment", balance.Comment ?? string.Empty),
            };

            database.Execute(sql, parameters);
        }

        public void Delete(int id)
        {
            var query = @"DELETE FROM ""Balance"" WHERE ""ID"" = @ID;";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@ID", id)
            };

            database.Execute(query, parameters);
        }

        public BalanceModel GetById(int id)
        {
            var sql =
                @"SELECT" +
                @"  b.""ID"", b.""Date"", b.""TypeID"", b.""CategoryID"", b.""Amount"", b.""Comment"", " +
                @"  c.""Name"", " +
                @"  tt.""Name"" " +
                @"FROM ""Balance"" b " +
                @"  JOIN ""Category"" c ON c.""ID"" = b.""CategoryID"" " +
                @"  JOIN ""BalanceType"" tt ON tt.""ID"" = b.""TypeID"" " +
                @"WHERE b.""ID"" = @ID LIMIT 1;";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@ID", id)
            };

            var row = database.Query(sql, parameters).FirstOrDefault();

            if (row is null)
            {
                return null;
            }

            return new BalanceModel
            {
                ID = (int)row[0],
                Date = (DateTime)row[1],
                TypeID = (int)row[2],
                CategoryID = (int)row[3],
                Amount = (int)row[4],
                Comment = (string)row[5],
                CategoryName = (string)row[6],
                TypeName = (string)row[7]
            };
        }

        public BalanceModel[] GetAll()
        {
            var sql =
                @"SELECT" +
                @"  b.""ID"", b.""Date"", b.""TypeID"", b.""CategoryID"", b.""Amount"", b.""Comment"", " +
                @"  c.""Name"", " +
                @"  tt.""Name"" " +
                @"FROM ""Balance"" b " +
                @"  JOIN ""Category"" c ON c.""ID"" = b.""CategoryID"" " +
                @"  JOIN ""BalanceType"" tt ON tt.""ID"" = b.""TypeID"" " +
                @"ORDER BY b.""Date"" DESC;";

            var rows = database.Query(sql);
            var output = new List<BalanceModel>();

            foreach (var row in rows)
            {
                var model = new BalanceModel
                {
                    ID = (int)row[0],
                    Date = (DateTime)row[1],
                    TypeID = (int)row[2],
                    CategoryID = (int)row[3],
                    Amount = (int)row[4],
                    Comment = (string)row[5],
                    CategoryName = (string)row[6],
                    TypeName = (string)row[7]
                };

                output.Add(model);
            }

            return output.ToArray();
        }

        public BalanceModel[] GetIncoming()
        {
            var sql =
                @"SELECT" +
                @"  b.""ID"", b.""Date"", b.""TypeID"", b.""CategoryID"", b.""Amount"", b.""Comment"", " +
                @"  c.""Name"", " +
                @"  tt.""Name"" " +
                @"FROM ""Balance"" b " +
                @"  JOIN ""Category"" c ON c.""ID"" = b.""CategoryID"" " +
                @"  JOIN ""BalanceType"" tt ON tt.""ID"" = b.""TypeID"" " +
                @"WHERE b.""TypeID"" = 1 " +
                @"ORDER BY b.""Date"" DESC;";

            var rows = database.Query(sql);
            var output = new List<BalanceModel>();

            foreach (var row in rows)
            {
                var model = new BalanceModel
                {
                    ID = (int)row[0],
                    Date = (DateTime)row[1],
                    TypeID = (int)row[2],
                    CategoryID = (int)row[3],
                    Amount = (int)row[4],
                    Comment = (string)row[5],
                    CategoryName = (string)row[6],
                    TypeName = (string)row[7]
                };

                output.Add(model);
            }

            return output.ToArray();
        }

        public BalanceModel[] GetOutcoming()
        {
            var sql =
                @"SELECT" +
                @"  b.""ID"", b.""Date"", b.""TypeID"", b.""CategoryID"", b.""Amount"", b.""Comment"", " +
                @"  c.""Name"", " +
                @"  tt.""Name"" " +
                @"FROM ""Balance"" b " +
                @"  JOIN ""Category"" c ON c.""ID"" = b.""CategoryID"" " +
                @"  JOIN ""BalanceType"" tt ON tt.""ID"" = b.""TypeID"" " +
                @"WHERE b.""TypeID"" = 2 " +
                @"ORDER BY b.""Date"" DESC;";

            var rows = database.Query(sql);
            var output = new List<BalanceModel>();

            foreach (var row in rows)
            {
                var model = new BalanceModel
                {
                    ID = (int)row[0],
                    Date = (DateTime)row[1],
                    TypeID = (int)row[2],
                    CategoryID = (int)row[3],
                    Amount = (int)row[4],
                    Comment = (string)row[5],
                    CategoryName = (string)row[6],
                    TypeName = (string)row[7]
                };

                output.Add(model);
            }

            return output.ToArray();
        }

        public BalanceModel[] GetRange(DateTime begin, DateTime end)
        {
            var sql =
                @"SELECT" +
                @"  b.""ID"", b.""Date"", b.""TypeID"", b.""CategoryID"", b.""Amount"", b.""Comment"", " +
                @"  c.""Name"", " +
                @"  tt.""Name"" " +
                @"FROM ""Balance"" b " +
                @"  JOIN ""Category"" c ON c.""ID"" = b.""CategoryID"" " +
                @"  JOIN ""BalanceType"" tt ON tt.""ID"" = b.""TypeID"" " +
                @"WHERE b.""Date"" BETWEEN @Begin AND @End " +
                @"ORDER BY b.""Date"" DESC;";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@End", end),
                new NpgsqlParameter("@Begin", begin)
            };

            var rows = database.Query(sql, parameters);
            var output = new List<BalanceModel>();

            foreach (var row in rows)
            {
                var model = new BalanceModel
                {
                    ID = (int)row[0],
                    Date = (DateTime)row[1],
                    TypeID = (int)row[2],
                    CategoryID = (int)row[3],
                    Amount = (int)row[4],
                    Comment = (string)row[5],
                    CategoryName = (string)row[6],
                    TypeName = (string)row[7]
                };

                output.Add(model);
            }

            return output.ToArray();
        }

        public void Update(BalanceDB balance)
        {
            var query = "UPDATE \"Balance\" " +
                        "SET " +
                            "\"Date\" = @Date, " +
                            "\"CategoryID\" = @CategoryID, " +
                            "\"Amount\" = @Amount, " +
                            "\"Comment\" = @Comment " +
                        "WHERE \"ID\" = @ID;";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@ID", balance.ID),
                new NpgsqlParameter("@Date", balance.Date),
                new NpgsqlParameter("@Amount", balance.Amount),
                new NpgsqlParameter("@CategoryID", balance.CategoryID),
                new NpgsqlParameter("@Comment", balance.Comment ?? string.Empty),
            };

            database.Execute(query, parameters);
        }

        public BalanceType[] GetTypes()
        {
            var output = new List<BalanceType>();

            var sql = @"SELECT ""ID"", ""Name"" FROM ""BalanceType""";

            var rows = database.Query(sql);

            foreach (var row in rows)
            {
                var item = new BalanceType
                {
                    ID = (int)row[0],
                    Name = (string)row[1]
                };

                output.Add(item);
            }

            return output.ToArray();
        }
    }
}