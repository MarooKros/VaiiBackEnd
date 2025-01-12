using VaibackEnd.Data;
using VaibackEnd.Models;
using VaibackEnd.Services;

public class LogginService
{
    private readonly LogginDbContext _logginContext;
    private readonly HTMLSanitizer _htmlSanitizer;
    private static Loggin? _loggedInUser;

    public LogginService(LogginDbContext logginContext, HTMLSanitizer htmlSanitizer)
    {
        _logginContext = logginContext;
        _htmlSanitizer = htmlSanitizer;
    }

    public Loggin? GetLoggedInUser()
    {
        return _loggedInUser;
    }

    public Loggin AddLoggedInUser(User user)
    {
        if (_loggedInUser != null)
        {
            throw new Exception("A user is already logged in");
        }

        user.Name = _htmlSanitizer.Sanitize(user.Name);
        user.Password = _htmlSanitizer.Sanitize(user.Password);

        var loggin = new Loggin { user = user };
        _loggedInUser = loggin;
        return loggin;
    }

    public bool DeleteLoggedInUser()
    {
        if (_loggedInUser == null)
        {
            return false;
        }

        _loggedInUser = null;
        return true;
    }
}
