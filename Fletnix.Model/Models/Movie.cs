using System.Collections.Generic;

namespace Fletnix.Models
{
    public class Movie : WatchableItem
    {
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<MovieCastMember> Cast { get; set; }
    }
}