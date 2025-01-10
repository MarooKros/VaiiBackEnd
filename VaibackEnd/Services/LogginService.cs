using Microsoft.EntityFrameworkCore;
using VaibackEnd.Data;
using VaibackEnd.Models;

public class LogginService
{
    private readonly LogginDbContext _logginContext;
    private static Loggin? _loggedInUser;

    public LogginService(LogginDbContext logginContext)
    {
        _logginContext = logginContext;
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
