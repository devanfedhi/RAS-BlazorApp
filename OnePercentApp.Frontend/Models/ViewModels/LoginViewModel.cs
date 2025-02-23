using System.ComponentModel.DataAnnotations;

namespace OnePercentApp.Frontend.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide an email")]
        public required string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a password")]
        public required string Password { get; set; }
    }
}
