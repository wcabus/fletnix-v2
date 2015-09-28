using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Fletnix.Repositories;
using Fletnix.WebApi.Models;

namespace Fletnix.WebApi.Controllers
{
    [RoutePrefix("api/subscriptions")]
    public class SubscriptionController : ApiController
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionController(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }


        [Route, AllowAnonymous]
        public async Task<IHttpActionResult> Get()
        {
            var subscriptions = (await _subscriptionRepository.GetSubscriptions()).ToListOrNull();
            if (subscriptions == null || !subscriptions.Any())
            {
                return NotFound();
            }

            return Ok(subscriptions);
        }

        [Route("{id:guid}", Name = "GetSubscription"), AllowAnonymous]
        public async Task<IHttpActionResult> GetById(Guid id)
        {
            var subscription = await _subscriptionRepository.GetSubscriptionById(id);
            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(subscription);
        }

        [Route, HttpPost]
        public async Task<IHttpActionResult> Post(CreateSubscriptionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _subscriptionRepository.CreateSubscription(model.Name, model.Price);
            return CreatedAtRoute("GetSubscription", new {id = result.Id}, result);
        }
    }
}