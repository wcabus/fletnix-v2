using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fletnix.Models;
using Fletnix.Repositories;

namespace Fletnix.Data.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        public Task<IEnumerable<Subscription>> GetSubscriptions()
        {
            throw new NotImplementedException();
        }

        public Task<Subscription> GetSubscriptionById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Subscription> CreateSubscription(string name, decimal price)
        {
            throw new NotImplementedException();
        }
    }
}