using System;

namespace Fletnix.Models
{
    public class Episode : WatchableItem
    {
        public virtual TvShowSeason Season { get; set; }
        public Guid SeasonId { get; set; }
    }
}