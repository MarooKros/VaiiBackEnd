using System.ComponentModel.DataAnnotations;

namespace VaibackEnd.Models
{
    public class Issue
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        [Required]
        public required string Title { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [Required]
        public required string Description { get; set; }
        
        /// <summary>
        /// Priority.
        /// </summary>
        public Priority Priority { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        public IssueType Type { get; set; }

        /// <summary>
        /// Created.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Completed.
        /// </summary>
        public DateTime? Completed { get; set; }
    }

    public enum Priority {
        Low, Medium, High
    }

    public enum IssueType
    {
        Feature, Bug, Documentation
    }
}
