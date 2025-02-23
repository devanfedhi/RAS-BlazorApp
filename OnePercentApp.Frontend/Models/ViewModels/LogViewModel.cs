using System.ComponentModel.DataAnnotations;

namespace OnePercentApp.Frontend.Models.ViewModels
{
    public class LogViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a date")]
        public DateOnly Date { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a log title")]
        public string Title { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide a log description")]
        public string Description { get; set; }
    }
}
