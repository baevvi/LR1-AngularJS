using System.ComponentModel.DataAnnotations;

namespace ITDAngularJS.Models
{
    public class ContactModel
    {
        [EmailAddress]
        [Required (ErrorMessage = "Неверный email-адрес")]
        public string Email { get; set; }

        [StringLength(50, ErrorMessage = "Тема должна быть меньше 50 символов")]
        public string Subject { get; set; }

        [StringLength(2000, ErrorMessage = "Сообщение должно быть меньше 2000 символов")]
        [Required (ErrorMessage = "Сообщение не указано")]
        public string Message { get; set; }
    }
}