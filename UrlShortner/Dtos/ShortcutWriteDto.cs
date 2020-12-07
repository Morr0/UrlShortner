using System.ComponentModel.DataAnnotations;

namespace UrlShortner.Dtos
{
    public class ShortcutWriteDto
    {
        [Required]
        public string OriginalUrl { get; set; }
        public string DesiredUrl { get; set; }
    }
}