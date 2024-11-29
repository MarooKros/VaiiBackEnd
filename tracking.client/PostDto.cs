using VaibackEnd.Models;

namespace tracking.client
{
    internal class PostDto
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User.
        /// </summary>
        public required User User { get; set; }

        /// <summary>
        /// Title.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Text.
        /// </summary>
        public required string Text { get; set; }

        /// <summary>
        /// Comments.
        /// </summary>
        public Comment[]? Comments { get; set; }
    }
}
