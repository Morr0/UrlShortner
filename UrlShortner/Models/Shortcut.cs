using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UrlShortner.Models
{
    public class Shortcut
    {
        public string ShortendUrl { get; set; }
        public string OriginalUrl { get; set; }
        public bool CustomUrl { get; set; }
        
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        
        public long Views { get; set; }
        public List<ShortcutView> ShortcutViews { get; set; }
    }
}