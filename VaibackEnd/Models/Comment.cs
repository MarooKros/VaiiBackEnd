namespace VaibackEnd.Models
{
    public class Comment
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// User id.
        /// </summary>
        public required int UserId { get; set; }

        /// <summary>
        /// User.
        /// </summary>
        public required User User { get; set; }

        /// <summary>
        /// Text.
        /// </summary>
        public required string Text { get; set; }
    }
}
