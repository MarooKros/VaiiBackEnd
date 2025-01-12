namespace VaibackEnd.Models
{
    public class Picture
    {
        public int Id { get; set; }
        public string Img { get; set; }
        public User User { get; set; }
    }
}
