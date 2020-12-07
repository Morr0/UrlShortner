namespace UrlShortner.Dtos
{
    public class ShortcutReadDto
    {
        public string ShortendUrl { get; set; }
        public string OriginalUrl { get; set; }
        public bool Custom { get; set; }
    }
}