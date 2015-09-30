using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fletnix.Models;

namespace Fletnix.Services
{
    public interface ISubscriptionService
    {
        Task<List<Subscription>> GetSubscriptionsAsync();
        Task<List<Subscription>> GetSubscriptionsAndFeaturesAsync();
        Task<List<Feature>> GetFeaturesForSubscription(Guid id);

        Task<Subscription> GetSubscriptionByIdAsync(Guid id);
        Task<Subscription> GetSubscriptionByIdAndFeaturesAsync(Guid id);

        Task<Subscription> CreateSubscriptionAsync(string name, decimal price);
    }
}