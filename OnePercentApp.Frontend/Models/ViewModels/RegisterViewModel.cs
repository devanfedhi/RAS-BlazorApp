using System.ComponentModel.DataAnnotations;

namespace OnePercentApp.Frontend.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a Name")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide an email")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a password")]
        public string Password { get; set; }
    }
}
