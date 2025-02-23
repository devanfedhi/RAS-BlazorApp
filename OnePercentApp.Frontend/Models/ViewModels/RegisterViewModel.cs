using System.ComponentModel.DataAnnotations;

namespace OnePercentApp.Frontend.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a Name")]
        public required string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide an email")]
        public required string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a password")]
        public required string Password { get; set; }
    }
}
