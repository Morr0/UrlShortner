using System.Threading.Tasks;
using UrlShortner.Dtos;

namespace UrlShortner.Repositories
{
    public interface IRepository
    {
        Task<ShortcutReadDto> Add(ShortcutWriteDto writeDto);
    }
}