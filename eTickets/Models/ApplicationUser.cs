using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class ApplicationUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
    }
}
