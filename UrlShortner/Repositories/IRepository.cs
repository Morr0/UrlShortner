using System.Collections.Generic;
using System.Threading.Tasks;
using UrlShortner.Dtos;
using UrlShortner.Models;

namespace UrlShortner.Repositories
{
    public interface IRepository
    {
        Task Add(Shortcut shortcut);
        Task<Shortcut> Get(string originalUrl);
        Task<string> GetOriginalUrl(string shortendUrl);
        Task<bool> HasShortendUrl(string shortendUrl);
        Task<IEnumerable<Shortcut>> GetMostViewed(int amount);
    }
}