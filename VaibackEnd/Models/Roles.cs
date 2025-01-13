using System.ComponentModel.DataAnnotations;

namespace VaibackEnd.Models
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required User user { get; set; }

        public Role userRole { get; set; }
    }

    public enum Role { 
        Visitor, user, Admin
    }
}
