using System.ComponentModel.DataAnnotations;

namespace OnePercentApp.Frontend.Models.ViewModels
{
    public class LogViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a date")]
        public required DateOnly Date { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a log title")]
        public required string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a log description")]
        public required string Description { get; set; }
    }
}
