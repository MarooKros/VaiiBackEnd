using VaibackEnd.Models;

public class Post
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
    public List<Comment>? Comments { get; set; }
}
