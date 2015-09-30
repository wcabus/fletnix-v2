using System;
using System.Collections.Generic;

namespace Fletnix.Models
{
    public class Episode : WatchableItem
    {
        public virtual TvShowSeason Season { get; set; }
        public Guid SeasonId { get; set; }

        public virtual ICollection<EpisodeCastMember> Cast { get; set; }
    }
}