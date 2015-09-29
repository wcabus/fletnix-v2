using System;

namespace Fletnix.Models
{
    public class Celebrity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImdbId { get; set; }

        public string ImageUri { get; set; }
    }
}