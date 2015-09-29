using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fletnix.Models;

namespace Fletnix.Services
{
    public interface ISubscriptionService
    {
        Task<List<Subscription>> GetSubscriptionsAsync();
        Task<Subscription> GetSubscriptionByIdAsync(Guid id);

        Task<Subscription> CreateSubscriptionAsync(string name, decimal price);
    }
}