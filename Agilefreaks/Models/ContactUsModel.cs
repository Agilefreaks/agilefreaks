using System.ComponentModel.DataAnnotations;

namespace Agilefreaks.Models
{
    public class ContactUsModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^(\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*)$", ErrorMessage = "Please enter a valid e-mail address.")]
        public string Email { get; set; }

        [Required]
        [StringLength(int.MaxValue, ErrorMessage = "Message too short.", MinimumLength = 4)]
        public string Message { get; set; }
    }
}