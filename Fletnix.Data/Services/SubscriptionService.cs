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

        public SubscriptionService(IBaseRepository<Subscription> subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public Task<List<Subscription>> GetSubscriptionsAsync()
        {
            return _subscriptionRepository.Get().Include(s => s.Features).ToListAsync();
        }

        public Task<Subscription> GetSubscriptionByIdAsync(Guid id)
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