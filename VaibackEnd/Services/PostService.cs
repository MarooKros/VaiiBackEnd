using Microsoft.EntityFrameworkCore;
using VaibackEnd.Models;
using System.ComponentModel.DataAnnotations;
using VaibackEnd.Services;

public class PostService
{
    private readonly PostDbContext _postContext;
    private readonly UserDbContext _userContext;
    private readonly IHTMLSanitizer _htmlSanitizer;

    public PostService(PostDbContext postContext, UserDbContext userContext, IHTMLSanitizer htmlSanitizer)
    {
        _postContext = postContext;
        _userContext = userContext;
        _htmlSanitizer = htmlSanitizer;
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
        ValidatePost(post);

        var user = _userContext.Users.Find(post.User.Id);
        if (user == null)
        {
            throw new Exception("User does not exist");
        }

        _postContext.Entry(user).State = EntityState.Unchanged;

        post.User = user;
        post.Title = _htmlSanitizer.Sanitize(post.Title);
        post.Text = _htmlSanitizer.Sanitize(post.Text);
        post.Comments = null;
        _postContext.Posts.Add(post);
        _postContext.SaveChanges();
        return post;
    }

    public bool UpdatePost(int id, Post updatedPost)
    {
        ValidatePost(updatedPost);

        var post = _postContext.Posts.FirstOrDefault(p => p.Id == id);
        if (post == null)
        {
            return false;
        }

        post.Title = _htmlSanitizer.Sanitize(updatedPost.Title);
        post.Text = _htmlSanitizer.Sanitize(updatedPost.Text);
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

        _postContext.RemoveRange(post.Comments);
        _postContext.Posts.Remove(post);
        _postContext.SaveChanges();
        return true;
    }

    public bool AddCommentToPost(int postId, Comment comment)
    {
        ValidateComment(comment);

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
        comment.PostId = postId;
        comment.Text = comment.Text;
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

    public bool DeleteCommentFromPost(int commentId)
    {
        var comment = _postContext.Comments.FirstOrDefault(c => c.Id == commentId);
        if (comment == null)
        {
            return false;
        }

        _postContext.Comments.Remove(comment);
        _postContext.SaveChanges();
        return true;
    }

    private void ValidatePost(Post post)
    {
        var validationContext = new ValidationContext(post);
        Validator.ValidateObject(post, validationContext, validateAllProperties: true);
    }

    private void ValidateComment(Comment comment)
    {
        var validationContext = new ValidationContext(comment);
        Validator.ValidateObject(comment, validationContext, validateAllProperties: true);
    }
}
