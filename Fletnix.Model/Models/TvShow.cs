using System;
using System.Collections.Generic;

namespace Fletnix.Models
{
    public class TvShow
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUri { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<TvShowSeason> Seasons { get; set; }
    }
}