using System.ComponentModel.DataAnnotations;

namespace Fletnix.WebApi.Models
{
    public class CreateSubscriptionModel
    {
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0.1, 999.99)]
        public decimal Price { get; set; }
    }
}