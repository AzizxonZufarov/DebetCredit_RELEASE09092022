using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DebetCredit.Models
{
    public class CategoryModel
    {
        public int ID { get; set; }

        [Required] [DisplayName("Тип")] public int TypeID { get; set; }

        [Required] [DisplayName("Тип")] public string TypeName { get; set; }

        [Required] [DisplayName("Категория")] public string CategoryName { get; set; }
    }
}