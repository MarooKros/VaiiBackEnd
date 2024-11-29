using VaibackEnd.Models;
using VaibackEnd.Data;
using Microsoft.EntityFrameworkCore;

public class PostService
{
    private readonly PostDbContext _postContext;
    private readonly UserDbContext _userContext;

    public PostService(PostDbContext postContext, UserDbContext userContext)
    {
        _postContext = postContext;
        _userContext = userContext;
    }

    public IEnumerable<Post> GetPosts()
    {
        return _postContext.Posts.Include(p => p.Comments).ToList();
    }

    public Post? GetPostById(int id)
    {
        return _postContext.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
    }

    public Post CreatePost(Post post)
    {
        var user = _userContext.Users.Find(post.User.Id);
        if (user == null)
        {
            throw new Exception("User does not exist");
        }

        _postContext.Entry(user).State = EntityState.Unchanged;

        post.User = user;
        _postContext.Posts.Add(post);
        _postContext.SaveChanges();
        return post;
    }

    public bool UpdatePost(int id, Post updatedPost)
    {
        var post = _postContext.Posts.FirstOrDefault(p => p.Id == id);
        if (post == null)
        {
            return false;
        }

        post.Title = updatedPost.Title;
        post.Text = updatedPost.Text;
        post.User = updatedPost.User;
        _postContext.SaveChanges();
        return true;
    }

    public bool DeletePost(int id)
    {
        var post = _postContext.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);
        if (post == null)
        {
            return false;
        }

        _postContext.RemoveRange(entities: post.Comments);
        _postContext.Posts.Remove(post);
        _postContext.SaveChanges();
        return true;
    }

    public bool AddCommentToPost(int postId, Comment comment)
    {
        var post = _postContext.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == postId);
        if (post == null)
        {
            return false;
        }

        var user = _userContext.Users.Find(comment.UserId);
        if (user == null)
        {
            throw new Exception("User does not exist");
        }

        _postContext.Entry(user).State = EntityState.Unchanged;

        comment.User = user;
        if (post.Comments == null)
        {
            post.Comments = new List<Comment> { comment };
        }
        else
        {
            post.Comments.Add(comment);
        }

        _postContext.SaveChanges();
        return true;
    }
}
