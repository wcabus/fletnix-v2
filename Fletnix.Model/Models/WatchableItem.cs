using System;
using System.Collections.Generic;

namespace Fletnix.Models
{
    public abstract class WatchableItem
    {
        public Guid Id { get; set; }
        public virtual ICollection<Mediastream> Streams { get; set; }

        // Can be the movie title or (optional) a title from an episode
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public string ImageUri { get; set; }

        public TimeSpan Duration { get; set; }

        public virtual ICollection<CastMember> Cast { get; set; }
    }
}