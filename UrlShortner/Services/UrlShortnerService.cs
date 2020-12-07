using System;
using System.Threading.Tasks;
using AutoMapper;
using UrlShortner.Dtos;
using UrlShortner.Factories;
using UrlShortner.Repositories;

namespace UrlShortner.Services
{
    public class UrlShortnerService : IUrlShortnerService
    {
        private IRepository _repo;
        private IMapper _mapper;

        public UrlShortnerService(IRepository repository, IMapper mapper)
        {
            _repo = repository;
            _mapper = mapper;
        }
        
        public async Task<ShortcutReadDto> Shorten(ShortcutWriteDto writeDto)
        {
            var shortcut = await _repo.Get(writeDto.OriginalUrl);

            if (shortcut != null) return _mapper.Map<ShortcutReadDto>(shortcut);
            
            shortcut = ShortcutFactory.CreateShortcut(ref _mapper, writeDto);
            await _repo.Add(shortcut).ConfigureAwait(false);
            
            return _mapper.Map<ShortcutReadDto>(shortcut);
        }

        public Task<string> GetOriginalUrl(string shortendUrl)
        {
            return _repo.GetOriginalUrl(shortendUrl);
        }
    }
}