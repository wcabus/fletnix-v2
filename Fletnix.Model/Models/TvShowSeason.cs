using System;
using System.Collections.Generic;

namespace Fletnix.Models
{
    public class TvShowSeason
    {
        public Guid Id { get; set; }

        public int SeasonNr { get; set; }

        public virtual TvShow TvShow { get; set; }
        public Guid TvShowId { get; set; }

        public virtual ICollection<Episode> Episodes { get; set; } 
    }
}