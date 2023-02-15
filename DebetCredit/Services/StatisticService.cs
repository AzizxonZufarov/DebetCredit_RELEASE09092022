using DebetCredit.Database;
using Npgsql;
using System.Collections.Generic;
using System.Linq;

namespace DebetCredit.Services
{
    public class StatisticService
    {
        private PostgresDatabase database = new PostgresDatabase();

        public STable Get(int year)
        {
            var query = "SELECT b.\"ID\", EXTRACT(MONTH FROM b.\"Date\"), c.\"Name\", b.\"Amount\" FROM \"Balance\" b " +
                            "JOIN \"Category\" c ON c.\"ID\" = b.\"CategoryID\" " +
                        "WHERE b.\"TypeID\" = 1 AND EXTRACT(YEAR FROM b.\"Date\") = @Year;";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@Year", year)
            };

            var rows = database.Query(query, parameters);

            var output = new List<SelectObject>();

            foreach (var row in rows)
            {
                var obj = new SelectObject
                {
                    ID = (int)row[0],
                    Month = (int)(decimal)row[1],
                    Amount = (int)row[3],
                    CategoryName = (string)row[2]
                };

                output.Add(obj);
            }

            return Method(output);
        }

        STable Method(List<SelectObject> rows)
        {
            var table = new STable();
            var categoryNames = GetUniqueCategoryNames(rows);

            table.CategoryNames = categoryNames.ToList();
            table.CategoryNames.Insert(0, string.Empty);

            for (int month = 1; month <= 12; month++)
            {
                var row = new SRow();

                row.MonthNumber = month;

                foreach (var categoryName in categoryNames)
                {
                    var totalAmount = TotalAmount(rows, month, categoryName);

                    row.Set(categoryName, totalAmount);
                }

                table.Set(month, row);
            }

            return table;
        }

        string[] GetUniqueCategoryNames(List<SelectObject> rows)
        {
            var list = new List<string>();

            foreach (var row in rows)
            {
                if (list.Contains(row.CategoryName))
                {
                    continue;
                }

                list.Add(row.CategoryName);
            }

            return list.ToArray();
        }

        int TotalAmount(List<SelectObject> rows, int month, string categoryName)
        {
            var total = 0;

            foreach (var row in rows)
            {
                if (month == row.Month && categoryName == row.CategoryName)
                {
                    total += row.Amount;
                }
            }

            return total;
        }
    }

    class SelectObject
    {
        public int ID { get; set; }
        public int Month { get; set; }
        public int Amount { get; set; }
        public string CategoryName { get; set; }
    }

    public class SRow
    {
        public int MonthNumber { get; set; }

        private Dictionary<string, int> rows = new Dictionary<string, int>();

        public string[] GetStringValues()
        {
            var list = new List<string>();

            foreach (var key in rows.Keys)
            {
                list.Add(rows[key] == 0 ? string.Empty : rows[key].ToString());
            }

            var mountName = string.Empty;

            switch (MonthNumber)
            {
                case 1: mountName = "Январь"; break;
                case 2: mountName = "Февраль"; break;
                case 3: mountName = "Март"; break;
                case 4: mountName = "Апрель"; break;
                case 5: mountName = "Май"; break;
                case 6: mountName = "Июнь"; break;
                case 7: mountName = "Июль"; break;
                case 8: mountName = "Август"; break;
                case 9: mountName = "Сентябрь"; break;
                case 10: mountName = "Октябрь"; break;
                case 11: mountName = "Ноябрь"; break;
                case 12: mountName = "Декабрь"; break;
            }

            list.Insert(0, mountName);

            return list.ToArray();
        }

        public void Set(string key, int value)
        {
            if (rows.ContainsKey(key))
            {
                rows[key] = value;
            }
            else
            {
                rows.Add(key, value);
            }
        }

        public int Get(string key)
        {
            return rows[key];
        }
    }

    public class STable
    {
        private Dictionary<int, SRow> rows = new Dictionary<int, SRow>();

        public List<string> CategoryNames { get; set; }

        public SRow[] GetRows()
        {
            var array = new SRow[12];

            for (int i = 0; i < 12; i++)
            {
                array[i] = rows[i + 1];
            }

            return array;
        }

        public void Set(int key, SRow value)
        {
            if (rows.ContainsKey(key))
            {
                rows[key] = value;
            }
            else
            {
                rows.Add(key, value);
            }
        }

        public SRow Get(int key)
        {
            return rows[key];
        }
    }
}
