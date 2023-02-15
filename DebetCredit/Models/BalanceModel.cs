using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DebetCredit.Models
{
    public class BalanceModel
    {
        public bool Incoming => TypeID == 1;
        public bool Outcoming => TypeID == 2;

        public int ID { get; set; }

        [DisplayName("Дата")] public DateTimeOffset Date { get; set; } = DateTimeOffset.Now.Date;

        [Required] [DisplayName("Тип")] public int TypeID { get; set; }

        [DisplayName("Тип")] public string TypeName { get; set; }

        [Required] [DisplayName("Категория")] public int CategoryID { get; set; }

        [DisplayName("Категория")] public string CategoryName { get; set; }

        [DisplayName("Сумма")] public int Amount { get; set; }

        [DisplayName("Комментарий")] public string Comment { get; set; }

        public long Unix => Date.ToUnixTimeSeconds();
    }
}
