using System;

namespace Fletnix.Models
{
    public class Customer
    {
        public Guid Id { get; set; } 
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CustomerSubscription Subscription { get; set; }
    }
}