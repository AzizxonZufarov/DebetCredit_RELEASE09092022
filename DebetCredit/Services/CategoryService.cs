using DebetCredit.Database;
using DebetCredit.Models;
using Npgsql;
using System.Collections.Generic;
using System.Linq;

namespace DebetCredit.Services
{
    public class CategoryService
    {
        private PostgresDatabase database = new PostgresDatabase();

        public void Add(CategoryDB category)
        {
            var sql = @"INSERT INTO ""Category"" ( ""TypeID"", ""Name"" ) VALUES ( @TypeID, @Name );";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Name", category.Name),
                new NpgsqlParameter("@TypeID", category.TypeID)
            };

            database.Execute(sql, parameters);
        }

        public void Delete(int id)
        {
            var sql = @"DELETE FROM ""Category"" WHERE ""ID"" = @ID AND ""ID"" NOT IN (SELECT ""CategoryID"" FROM ""Balance"");";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@ID", id)
            };

            database.Execute(sql, parameters);
        }

        public CategoryModel GetById(int id)
        {
            var sql = @"SELECT c.""ID"", c.""TypeID"", c.""Name"", t.""Name"" FROM ""Category"" c JOIN ""BalanceType"" t ON c.""TypeID"" = t.""ID"" WHERE c.""ID"" = @ID LIMIT 1;";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@ID", id)
            };

            var row = database.Query(sql, parameters).FirstOrDefault();

            if (row is null)
            {
                return null;
            }

            return new CategoryModel
            {
                ID = (int)row[0],
                TypeID = (int)row[1],
                TypeName = (string)row[3],
                CategoryName = (string)row[2]
            };
        }

        public CategoryModel[] GetAll()
        {
            var output = new List<CategoryModel>();

            var sql = @"SELECT c.""ID"", c.""TypeID"", c.""Name"", t.""Name"" FROM ""Category"" c JOIN ""BalanceType"" t ON c.""TypeID"" = t.""ID"";";

            var rows = database.Query(sql);

            foreach (var row in rows)
            {
                var model = new CategoryModel
                {
                    ID = (int)row[0],
                    CategoryName = (string)row[2],
                    TypeID = (int)row[1],
                    TypeName = (string)row[3]
                };

                output.Add(model);
            }

            return output.ToArray();
        }

        public void Update(CategoryDB category)
        {
            var sql = @"UPDATE ""Category"" SET ""Name"" = @Name, ""TypeID"" = @TypeID  WHERE ""ID"" = @ID;";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@ID", category.ID),
                new NpgsqlParameter("@Name", category.Name),
                new NpgsqlParameter("@TypeID", category.TypeID)
            };

            database.Execute(sql, parameters);
        }
    }
}
