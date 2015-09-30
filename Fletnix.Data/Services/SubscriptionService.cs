using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Fletnix.Models;
using Fletnix.Repositories;
using Fletnix.Services;

namespace Fletnix.Data.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly IBaseRepository<Subscription> _subscriptionRepository;
        private readonly IBaseRepository<Feature> _featureRepository;

        public SubscriptionService(IBaseRepository<Subscription> subscriptionRepository, IBaseRepository<Feature> featureRepository)
        {
            _subscriptionRepository = subscriptionRepository;
            _featureRepository = featureRepository;
        }

        public Task<List<Subscription>> GetSubscriptionsAsync()
        {
            return _subscriptionRepository.Get().ToListAsync();
        }

        public Task<List<Subscription>> GetSubscriptionsAndFeaturesAsync()
        {
            return _subscriptionRepository.Get().Include(s => s.Features).ToListAsync();
        }

        public Task<List<Feature>> GetFeaturesForSubscription(Guid id)
        {
            return _featureRepository.Get(f => f.SubscriptionId == id).ToListAsync();
        }

        public Task<Subscription> GetSubscriptionByIdAsync(Guid id)
        {
            return _subscriptionRepository.Get(s => s.Id == id).FirstOrDefaultAsync();
        }

        public Task<Subscription> GetSubscriptionByIdAndFeaturesAsync(Guid id)
        {
            return _subscriptionRepository.Get(s => s.Id == id).Include(s => s.Features).FirstOrDefaultAsync();
        }

        public async Task<Subscription> CreateSubscriptionAsync(string name, decimal price)
        {
            var subscription = _subscriptionRepository.Add(new Subscription {Name = name, Price = price});
            await _subscriptionRepository.SaveChangesAsync();

            return subscription;
        }
    }
}