using System;

namespace Fletnix.Models
{
    public class EpisodeCastMember : CastMember
    {
        public Episode Episode { get; set; }
        public Guid EpisodeId { get; set; }
    }
}