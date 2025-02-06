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
        /// UserId.
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// UserRole.
        /// </summary>
        [Required]
        public Role UserRole { get; set; }
    }

    /// <summary>
    /// Enum.
    /// </summary>
    public enum Role
    {
        Visitor, User, Admin
    }
}
