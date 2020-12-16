using System;
using System.Collections.Generic;
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
        private ShortcutViewRepository _shortcutViewRepo;

        public UrlShortnerService(IRepository repository, ShortcutViewRepository shortcutViewRepository,IMapper mapper)
        {
            _repo = repository;
            _shortcutViewRepo = shortcutViewRepository;
            _mapper = mapper;
        }
        
        public async Task<ShortcutReadDto> Shorten(ShortcutWriteDto writeDto)
        {
            if (!string.IsNullOrEmpty(writeDto.DesiredUrl))
            {
                if (await _repo.HasShortendUrl(writeDto.DesiredUrl)) return null;
            }
            
            var shortcut = await _repo.Get(writeDto.OriginalUrl).ConfigureAwait(false);
            if (shortcut != null) return _mapper.Map<ShortcutReadDto>(shortcut);
            
            shortcut = ShortcutFactory.CreateShortcut(ref _mapper, writeDto);
            await _repo.Add(shortcut).ConfigureAwait(false);
            
            return _mapper.Map<ShortcutReadDto>(shortcut);
        }

        public async Task<string> GetOriginalUrl(string shortendUrl, string ipAddress)
        {
            string originalUrl = await _repo.GetOriginalUrl(shortendUrl).ConfigureAwait(false);
            if (originalUrl is null) return null;
            await _shortcutViewRepo.AddView(ShortcutViewFactory.CreateShortcutView(shortendUrl, ipAddress)).ConfigureAwait(false);
            
            return originalUrl;
        }

        public async Task<Dictionary<string, long>> GetMostViewed(int amount)
        {
            var enumerable = await _repo.GetMostViewed(amount);
            var dict = new Dictionary<string, long>();

            foreach (var item in enumerable)
            {
                dict.Add(item.ShortendUrl, item.Views);
            }

            return dict;
        }
    }
}