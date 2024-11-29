using System.ComponentModel.DataAnnotations;

namespace VaibackEnd.Models
{
    public class User
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        public required string Name { get; set; }

        /// <summary>
        /// password
        /// </summary>
        [Required]
        public required string Password { get; set; }
    }
}
