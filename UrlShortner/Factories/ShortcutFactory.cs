using AutoMapper;
using UrlShortner.Dtos;
using UrlShortner.Models;

namespace UrlShortner.Factories
{
    public static class ShortcutFactory
    {
        public static Shortcut CreateShortcut(ref IMapper mapper, ShortcutWriteDto writeDto)
        {
            Shortcut shortcut = mapper.Map<Shortcut>(writeDto);
            CreateShortendUrl(ref writeDto, ref shortcut);
            return shortcut;
        }

        private static void CreateShortendUrl(ref ShortcutWriteDto writeDto, ref Shortcut shortcut)
        {
            // Custom URL
            if (!string.IsNullOrEmpty(writeDto.DesiredUrl))
            {
                shortcut.CustomUrl = true;
                shortcut.ShortendUrl = writeDto.DesiredUrl;
            }
            else
            {
                shortcut.ShortendUrl = Utilities.UrlShortner.Make(shortcut.OriginalUrl);
            }
        }
    }
}