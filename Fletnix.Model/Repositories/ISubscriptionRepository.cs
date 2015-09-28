using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fletnix.Models;

namespace Fletnix.Repositories
{
    public interface ISubscriptionRepository
    {
        Task<IEnumerable<Subscription>> GetSubscriptions();
        Task<Subscription> GetSubscriptionById(Guid id);

        Task<Subscription> CreateSubscription(string name, decimal price);
    }
}