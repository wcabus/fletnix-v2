using System;

namespace Fletnix.Models
{
    public class MovieCastMember : CastMember
    {
        public Movie Movie { get; set; }
        public Guid MovieId { get; set; }
    }
}