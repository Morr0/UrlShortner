using AutoMapper;
using UrlShortner.Dtos;
using UrlShortner.Models;

namespace UrlShortner.Mappings
{
    public class ShortcutMappingsProfile : Profile
    {
        public ShortcutMappingsProfile()
        {
            CreateMap<ShortcutWriteDto, Shortcut>();
            CreateMap<Shortcut, ShortcutReadDto>();
        }
    }
}