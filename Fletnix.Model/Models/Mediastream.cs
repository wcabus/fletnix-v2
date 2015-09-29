using System;

namespace Fletnix.Models
{
    public class Mediastream
    {
        public Guid Id { get; set; } 

        public Language AudioLanguage { get; set; }
        public Language SubtitleLanguage { get; set; }
    }
}