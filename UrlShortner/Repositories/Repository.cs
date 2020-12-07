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

        public Task<Shortcut> Get(ShortcutWriteDto writeDto)
        {
            return _context.Shortcut.FirstOrDefaultAsync(x => x.OriginalUrl == writeDto.OriginalUrl);
        }
    }
}