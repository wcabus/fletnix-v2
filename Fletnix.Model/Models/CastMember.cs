using System;

namespace Fletnix.Models
{
    public class CastMember
    {
        public Guid ParentId { get; set; }

        public virtual CelebrityRole Role { get; set; }
        public Guid RoleId { get; set; }

        public virtual Celebrity Celebrity { get; set; }
        public Guid CelebrityId { get; set; } 
    }
}