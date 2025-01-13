using System.ComponentModel.DataAnnotations;

namespace VaibackEnd.Models
{
    public class Roles
    {
        /// <summary>
        /// Id.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// User.
        /// </summary>
        [Required]
        public required User user { get; set; }

        /// <summary>
        /// UserRole.
        /// </summary>
        public Role userRole { get; set; }
    }
    /// <summary>
    /// Enum.
    /// </summary>
    public enum Role { 
        Visitor, user, Admin
    }
}
