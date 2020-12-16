using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UrlShortner.Models
{
    public class ShortcutView
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ShortendUrl { get; set; }
        public Shortcut Shortcut { get; set; }
        
        public string Ip { get; set; }
        public DateTime DateTime { get; set; } = DateTime.UtcNow;
    }
}