using System.Threading.Tasks;
using UrlShortner.Dtos;

namespace UrlShortner.Services
{
    public interface IUrlShortnerService
    {
        Task<ShortcutReadDto> Shorten(ShortcutWriteDto writeDto);
        Task<string> GetOriginalUrl(string shortendUrl);
    }
}