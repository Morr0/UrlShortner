using UrlShortner.Models;

namespace UrlShortner.Factories
{
    public static class ShortcutViewFactory
    {
        public static ShortcutView CreateShortcutView(string shortendUrl, string ipAddress)
        {
            return new ShortcutView
            {
                ShortendUrl = shortendUrl,
                Ip = ipAddress,
            };
        }
    }
}