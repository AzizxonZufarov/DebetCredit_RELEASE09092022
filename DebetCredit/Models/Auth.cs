using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DebetCredit.Models
{
    public class Auth
    {
        public int ID { get; set; }

        [DisplayName("Логин")]
        [Required(ErrorMessage = "Введите логин правильно!")]
        public string Username { get; set; }
        
        [DisplayName("Пароль")]
        [Required(ErrorMessage = "Введите пароль правильно!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}