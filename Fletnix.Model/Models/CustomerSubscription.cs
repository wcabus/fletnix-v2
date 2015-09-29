using System;

namespace Fletnix.Models
{
    public class CustomerSubscription
    {
        public Guid Id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Subscription Subscription { get; set; }
        public Guid SubscriptionId { get; set; }

        // When did the customer subscribe?
        public DateTime SubscriptionTimeStamp { get; set; }
        
        // When the customer unsubscribes, remember the final date until he/she has access
        public DateTime? PaidUntil { get; set; }

        public bool IsSubscribed => PaidUntil == null || DateTime.UtcNow <= PaidUntil.Value;
    }
}