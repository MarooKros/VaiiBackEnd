namespace VaibackEnd.Models
{
    public class Picture
    {
        /// <summary>
        /// Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Img.
        /// </summary>
        public string Img { get; set; }

        /// <summary>
        /// User.
        /// </summary>
        public User User { get; set; }
    }
}
