using System;
using System.Threading.Tasks;
using UrlShortner.Dtos;

namespace UrlShortner.Repositories
{
    public class Repository : IRepository
    {
        public async Task<ShortcutReadDto> Add(ShortcutWriteDto writeDto)
        {
            throw new Exception("Unimplemented");
        }
    }
}