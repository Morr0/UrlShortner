using System;

namespace UrlShortner.Utilities
{
    public class UrlShortner
    {
        public static string Make(string originalUrl)
        {
            return Guid.NewGuid().ToString();
        }
    }
}