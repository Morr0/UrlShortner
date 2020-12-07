using System;
using System.ComponentModel.DataAnnotations;

namespace UrlShortner.Models
{
    public class Shortcut
    {
        [Key]
        public string ShortendUrl { get; set; }
        public string OriginalUrl { get; set; }
        
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
    }
}