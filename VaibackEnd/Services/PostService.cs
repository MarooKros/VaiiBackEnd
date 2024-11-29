using VaibackEnd.Models;
using VaibackEnd.Data;
using Microsoft.EntityFrameworkCore;

public class PostService
{
    private readonly PostDbContext _context;

    public PostService(PostDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Post> GetPosts()
    {
        return _context.Posts.Include(p => p.Comments).ToList();
    }

    public Post? GetPostById(int id)
    {
        return _context.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
    }

    public Post CreatePost(Post post)
    {
        post.Comments = null;
        _context.Posts.Add(post);
        _context.SaveChanges();
        return post;
    }

    public bool UpdatePost(int id, Post updatedPost)
    {
        var post = _context.Posts.FirstOrDefault(p => p.Id == id);
        if (post == null)
        {
            return false;
        }

        post.Title = updatedPost.Title;
        post.Text = updatedPost.Text;
        post.User = updatedPost.User;
        _context.SaveChanges();
        return true;
    }

    public bool DeletePost(int id)
    {
        var post = _context.Posts.FirstOrDefault(p => p.Id == id);
        if (post == null)
        {
            return false;
        }

        _context.Posts.Remove(post);
        _context.SaveChanges();
        return true;
    }

    public bool AddCommentToPost(int postId, Comment comment)
    {
        var post = _context.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == postId);
        if (post == null)
        {
            return false;
        }

        if (post.Comments == null)
        {
            post.Comments = [comment];
        }
        else
        {
            post.Comments.Add(comment);
        }

        _context.SaveChanges();
        return true;
    }
}
