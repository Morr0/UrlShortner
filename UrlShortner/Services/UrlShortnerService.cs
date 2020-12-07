using System.Threading.Tasks;
using UrlShortner.Dtos;
using UrlShortner.Repositories;

namespace UrlShortner.Services
{
    public class UrlShortnerService : IUrlShortnerService
    {
        private IRepository _repo;

        public UrlShortnerService(IRepository repository)
        {
            _repo = repository;
        }
        
        public Task<ShortcutReadDto> Shorten(ShortcutWriteDto writeDto)
        {
            return _repo.Add(writeDto);
        }
    }
}