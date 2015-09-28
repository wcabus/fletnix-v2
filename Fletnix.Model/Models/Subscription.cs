using System;
using System.Collections.Generic;

namespace Fletnix.Models
{
    public class Subscription
    {
        public Guid Id { get; set; } 

        public string Name { get; set; }

        public decimal Price { get; set; }

        public ICollection<Feature> Features { get; set; } 
    }
}