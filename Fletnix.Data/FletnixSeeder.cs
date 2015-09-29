using System.Collections.Generic;
using System.Data.Entity;
using Fletnix.Models;

namespace Fletnix.Data
{
    public sealed class FletnixSeeder : DropCreateDatabaseAlways<FletnixDbContext>
    {
        protected override void Seed(FletnixDbContext context)
        {
            AddGenres(context);
            AddRoles(context);
            AddSubscriptionsAndFeatures(context);

            context.SaveChanges();
        }

        private void AddSubscriptionsAndFeatures(FletnixDbContext context)
        {
            var basic = new Subscription
            {
                Name = "Basic",
                Price = 6.99m,
                Features =
                    new List<Feature>
                    {
                        new Feature {Name = "Screens", Description = "Watch on your TV, smartphone or tablet."}
                    }
            };

            var standard = new Subscription
            {
                Name = "Standard",
                Price = 8.99m,
                Features =
                    new List<Feature>
                    {
                        new Feature {Name = "Screens", Description = "Watch on your TV, smartphone and tablet. You can watch on two screens at the same time!"},
                        new Feature {Name = "HD", Description = "Stream content in High Definition."}
                    }
            };

            var premium = new Subscription
            {
                Name = "Premium",
                Price = 10.99m,
                Features =
                    new List<Feature>
                    {
                        new Feature {Name = "Screens", Description = "Watch on your TV, smartphone and tablet. You can watch on <b>four</b> screens at the same time!"},
                        new Feature {Name = "HD", Description = "Stream content in Ultra High Definition (when available)."}
                    }
            };

            var subscriptions = context.Set<Subscription>();
            subscriptions.Add(basic);
            subscriptions.Add(standard);
            subscriptions.Add(premium);
        }

        private void AddRoles(FletnixDbContext context)
        {
            var roles = context.Set<CelebrityRole>();
            roles.Add(new CelebrityRole { Name = "director", Order = 1 });
            roles.Add(new CelebrityRole { Name = "writer", Order = 2 });
            roles.Add(new CelebrityRole { Name = "actor", Order = 3 });
            roles.Add(new CelebrityRole { Name = "producer", Order = 4 });
            roles.Add(new CelebrityRole { Name = "composer", Order = 5 });
        }

        private void AddGenres(FletnixDbContext context)
        {
            var genres = context.Set<Genre>();
            genres.Add(new Genre { Name = "action" });
            genres.Add(new Genre { Name = "adventure" });
            genres.Add(new Genre { Name = "animation" });
            genres.Add(new Genre { Name = "biography" });
            genres.Add(new Genre { Name = "comedy" });
            genres.Add(new Genre { Name = "crime" });
            genres.Add(new Genre { Name = "documentary" });
            genres.Add(new Genre { Name = "drama" });
            genres.Add(new Genre { Name = "family" });
            genres.Add(new Genre { Name = "fantasy" });
            genres.Add(new Genre { Name = "film-noir" });
            genres.Add(new Genre { Name = "history" });
            genres.Add(new Genre { Name = "music" });
            genres.Add(new Genre { Name = "musical" });
            genres.Add(new Genre { Name = "mystery" });
            genres.Add(new Genre { Name = "romance" });
            genres.Add(new Genre { Name = "sci-fi" });
            genres.Add(new Genre { Name = "sport" });
            genres.Add(new Genre { Name = "thriller" });
            genres.Add(new Genre { Name = "war" });
            genres.Add(new Genre { Name = "western" });
        }
    }
}