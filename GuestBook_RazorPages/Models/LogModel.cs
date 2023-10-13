using System.ComponentModel.DataAnnotations;

namespace GuestBook_RazorPages.Models
{
    public class LogModel
    {
        [Required(ErrorMessage = "Поле является обязательным!")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Поле является обязательным!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
