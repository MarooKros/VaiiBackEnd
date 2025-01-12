using Microsoft.EntityFrameworkCore;
using VaibackEnd.Data;
using VaibackEnd.Models;

namespace VaibackEnd.Services
{
    public class PictureService
    {
        private readonly PictureDbContext _context;
        private readonly HTMLSanitizer _htmlSanitizer;

        public PictureService(PictureDbContext context, HTMLSanitizer htmlSanitizer)
        {
            _context = context;
            _htmlSanitizer = htmlSanitizer;
        }

        public async Task<Picture> CreatePictureAsync(Picture picture)
        {
            var existingUser = await _context.Users.FindAsync(picture.User.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with Id {picture.User.Id} not found.");
            }

            picture.User = existingUser;
            picture.Img = _htmlSanitizer.Sanitize(picture.Img);
            _context.Pictures.Add(picture);
            await _context.SaveChangesAsync();
            return picture;
        }

        public async Task<Picture> GetPictureByIdAsync(int id)
        {
            var picture = await _context.Pictures
                .Include(p => p.User)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (picture == null)
            {
                throw new KeyNotFoundException($"Picture with Id {id} not found.");
            }

            return picture;
        }

        public async Task<List<Picture>> GetAllPicturesAsync()
        {
            return await _context.Pictures
                .Include(p => p.User)
                .ToListAsync();
        }

        public async Task<bool> DeletePictureAsync(int id)
        {
            var picture = await _context.Pictures.FindAsync(id);
            if (picture == null)
            {
                throw new KeyNotFoundException($"Picture with Id {id} not found.");
            }

            _context.Pictures.Remove(picture);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
