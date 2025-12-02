using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventAPI.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string phoneNumber { get; set; }
        [ForeignKey("user")]
        public int userId { get; set; }
        
        public User user { get; set; }
    }
}
