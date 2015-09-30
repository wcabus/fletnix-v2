using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Fletnix.Models;
using Fletnix.Services;
using Fletnix.WebApi.Models;

namespace Fletnix.WebApi.Controllers
{
    [RoutePrefix("api/subscriptions")]
    public class SubscriptionController : ApiController
    {
        private readonly ISubscriptionService _service;

        public SubscriptionController(ISubscriptionService service)
        {
            _service = service;
        }


        [Route, AllowAnonymous]
        public async Task<IHttpActionResult> Get(string include = null)
        {
            IList<Subscription> subscriptions;

            if (string.Equals(include, "features", StringComparison.OrdinalIgnoreCase))
            {
                subscriptions = await _service.GetSubscriptionsAndFeaturesAsync();
            }
            else
            {
                subscriptions = await _service.GetSubscriptionsAsync();
            }

            if (subscriptions == null || !subscriptions.Any())
            {
                return NotFound();
            }

            return Ok(subscriptions);
        }

        [Route("{id:guid}", Name = "GetSubscription"), AllowAnonymous]
        public async Task<IHttpActionResult> GetById(Guid id)
        {
            var subscription = await _service.GetSubscriptionByIdAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }

            return Ok(subscription);
        }

        [Route("{id:guid}/Features"), AllowAnonymous]
        public async Task<IHttpActionResult> GetFeatures(Guid id)
        {
            if (await _service.GetSubscriptionByIdAsync(id) == null)
            {
                return NotFound();
            }

            var features = await _service.GetFeaturesForSubscription(id);
            if (features == null || !features.Any())
            {
                return StatusCode(HttpStatusCode.NoContent);
            }

            return Ok(features);
        }

        [Route, HttpPost]
        public async Task<IHttpActionResult> Post(CreateSubscriptionModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.CreateSubscriptionAsync(model.Name, model.Price);
            return CreatedAtRoute("GetSubscription", new {id = result.Id}, result);
        }
    }
}