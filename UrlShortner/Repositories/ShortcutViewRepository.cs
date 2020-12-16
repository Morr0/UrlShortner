using System.Threading.Tasks;
using UrlShortner.Models;

namespace UrlShortner.Repositories
{
    public class ShortcutViewRepository
    {
        private DataContext _context;

        public ShortcutViewRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddView(ShortcutView view)
        {
            await _context.ShortcutView.AddAsync(view).ConfigureAwait(false);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}