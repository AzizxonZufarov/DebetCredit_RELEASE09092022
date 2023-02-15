using System;

namespace DebetCredit.Services
{
    public class BalanceDB
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public int TypeID { get; set; }

        public int CategoryID { get; set; }

        public int Amount { get; set; }

        public string Comment { get; set; }
    }
}