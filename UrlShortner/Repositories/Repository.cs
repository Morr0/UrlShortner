using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UrlShortner.Dtos;
using UrlShortner.Models;

namespace UrlShortner.Repositories
{
    public class Repository : IRepository
    {
        private DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        
        public async Task Add(Shortcut shortcut)
        {
            await _context.Shortcut.AddAsync(shortcut).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }

        public Task<Shortcut> Get(string originalUrl)
        {
            return _context.Shortcut.FirstOrDefaultAsync(x => x.OriginalUrl == originalUrl);
        }

        public async Task<string> GetOriginalUrl(string shortendUrl)
        {
            Shortcut shortcut = await _context.Shortcut.FirstOrDefaultAsync(x => x.ShortendUrl == shortendUrl).ConfigureAwait(false);
            if (shortcut == null) return null;

            _context.Shortcut.Attach(shortcut);
            shortcut.Views++;
            _context.Entry(shortcut).Property(x => x.Views).IsModified = true;
            await _context.SaveChangesAsync();
            
            return shortcut.OriginalUrl;
        }

        public Task<bool> HasShortendUrl(string shortendUrl)
        {
            return _context.Shortcut.AsNoTracking().AnyAsync(x => x.ShortendUrl == shortendUrl);
        }
    }
}