using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Fletnix.Models;

namespace Fletnix.Data
{
    public sealed class FletnixSeeder : DropCreateDatabaseIfModelChanges<FletnixDbContext>
    {
        protected override void Seed(FletnixDbContext context)
        {
            AddGenres(context);
            AddRoles(context);
            AddSubscriptionsAndFeatures(context);
            AddCelebrities(context);
            AddMovies(context);
            AddTvShows(context);

            context.SaveChanges();
        }

        private void AddMovies(DbContext context)
        {
            var genres = context.Set<Genre>().Local;
            var celebrities = context.Set<Celebrity>().Local;
            var roles = context.Set<CelebrityRole>().Local;

            var actor = roles.First(r => r.Name == "actor");
            var director = roles.First(r => r.Name == "director");
            var writer = roles.First(r => r.Name == "writer");

            // Lucy
            var lucy = new Movie { Title = "Lucy", Synopsis = "A woman, accidentally caught in a dark deal, turns the tables on her captors and transforms into a merciless warrior evolved beyond human logic.", ImageUri = "http://ia.media-imdb.com/images/M/MV5BODcxMzY3ODY1NF5BMl5BanBnXkFtZTgwNzg1NDY4MTE@._V1_SX214_AL_.jpg", Duration = TimeSpan.FromMinutes(89), Cast = new List<MovieCastMember>(), Genres = new List<Genre>(), Streams = new List<Mediastream>()};
            lucy.Genres.Add(genres.First(g => g.Name == "action"));
            lucy.Genres.Add(genres.First(g => g.Name == "sci-fi"));
            lucy.Genres.Add(genres.First(g => g.Name == "thriller"));

            lucy.Cast.Add(new MovieCastMember { Movie = lucy, Celebrity = celebrities.First(c => c.FirstName == "Luc"), Role = director });
            lucy.Cast.Add(new MovieCastMember { Movie = lucy, Celebrity = celebrities.First(c => c.FirstName == "Luc"), Role = writer });
            lucy.Cast.Add(new MovieCastMember { Movie = lucy, Name = "Lucy", Celebrity = celebrities.First(c => c.FirstName == "Scarlett"), Role = actor });
            lucy.Cast.Add(new MovieCastMember { Movie = lucy, Name = "Professor Norman", Celebrity = celebrities.First(c => c.FirstName == "Morgan"), Role = actor });

            // Maleficent
            var maleficent = new Movie { Title = "Maleficent", Synopsis = "A vengeful fairy is driven to curse an infant princess, only to discover that the child may be the one person who can restore peace to their troubled land.", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTQ1NDk3NTk0MV5BMl5BanBnXkFtZTgwMTk3MDcxMzE@._V1_SY317_CR5,0,214,317_AL_.jpg", Duration = TimeSpan.FromMinutes(97), Cast = new List<MovieCastMember>(), Genres = new List<Genre>(), Streams = new List<Mediastream>() };
            maleficent.Genres.Add(genres.First(g => g.Name == "action"));
            maleficent.Genres.Add(genres.First(g => g.Name == "adventure"));
            maleficent.Genres.Add(genres.First(g => g.Name == "family"));
            
            maleficent.Cast.Add(new MovieCastMember { Movie = maleficent, Celebrity = celebrities.First(c => c.FirstName == "Robert"), Role = director });
            maleficent.Cast.Add(new MovieCastMember { Movie = maleficent, Name = "Maleficent", Celebrity = celebrities.First(c => c.FirstName == "Angelina"), Role = actor });
            maleficent.Cast.Add(new MovieCastMember { Movie = maleficent, Name = "Aurora", Celebrity = celebrities.First(c => c.FirstName == "Elle"), Role = actor });
            maleficent.Cast.Add(new MovieCastMember { Movie = maleficent, Name = "Stefan", Celebrity = celebrities.First(c => c.FirstName == "Sharlto"), Role = actor });

            // Hunger Games
            var hungerGames = new Movie { Title = "The Hunger Games: Mockingjay - Part 1", Synopsis = "Katniss Everdeen is in District 13 after she shatters the games forever. Under the leadership of President Coin and the advice of her trusted friends, Katniss spreads her wings as she fights to save Peeta and a nation moved by her courage.", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTcxNDI2NDAzNl5BMl5BanBnXkFtZTgwODM3MTc2MjE@._V1_SX214_AL_.jpg", Duration = TimeSpan.FromMinutes(123), Cast = new List<MovieCastMember>(), Genres = new List<Genre>(), Streams = new List<Mediastream>() };
            hungerGames.Genres.Add(genres.First(g => g.Name == "adventure"));
            hungerGames.Genres.Add(genres.First(g => g.Name == "sci-fi"));
            hungerGames.Genres.Add(genres.First(g => g.Name == "thriller"));

            hungerGames.Cast.Add(new MovieCastMember { Movie = hungerGames, Celebrity = celebrities.First(c => c.FirstName == "Francis"), Role = director });
            hungerGames.Cast.Add(new MovieCastMember { Movie = hungerGames, Name = "Katniss Everdeen", Celebrity = celebrities.First(c => c.FirstName == "Jennifer"), Role = actor });
            hungerGames.Cast.Add(new MovieCastMember { Movie = hungerGames, Name = "Haymitch Abernathy", Celebrity = celebrities.First(c => c.FirstName == "Woody"), Role = actor });
            hungerGames.Cast.Add(new MovieCastMember { Movie = hungerGames, Name = "President Snow", Celebrity = celebrities.First(c => c.FirstName == "Donald"), Role = actor });
            hungerGames.Cast.Add(new MovieCastMember { Movie = hungerGames, Name = "Plutarch Heavensbee", Celebrity = celebrities.First(c => c.FirstName == "Philip Seymour"), Role = actor });
            hungerGames.Cast.Add(new MovieCastMember { Movie = hungerGames, Name = "Cressida", Celebrity = celebrities.First(c => c.FirstName == "Natalie"), Role = actor });

            var set = context.Set<Movie>();
            set.Add(lucy);
            set.Add(maleficent);
            set.Add(hungerGames);
        }

        private void AddTvShows(DbContext context)
        {
            var genres = context.Set<Genre>().Local;
            var celebrities = context.Set<Celebrity>().Local.Skip(13).Take(4).ToList();

            var actor = context.Set<CelebrityRole>().Local.First(r => r.Name == "actor");

            var tvShow = new TvShow
            {
                Title = "Constantine",
                ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTQ2MzQzMjA2NF5BMl5BanBnXkFtZTgwODg1MTI4MjE@._V1_SY317_CR1,0,214,317_AL_.jpg",
                Genres = new List<Genre>(),
                Seasons = new List<TvShowSeason>()
            };

            tvShow.Genres.Add(genres.First(g => g.Name == "fantasy"));
            tvShow.Genres.Add(genres.First(g => g.Name == "horror"));

            var season = new TvShowSeason { SeasonNr = 1, TvShow = tvShow, Episodes = new List<Episode>() };
            tvShow.Seasons.Add(season);

            AddConstantineEpisode(season, celebrities, actor, "Non Est Asylum", "Based on the wildly popular comic book series \"Hellblazer\" from DC Comics, seasoned demon hunter and master of the occult John Constantine is armed with a ferocious knowledge of the dark arts and a wickedly naughty wit. He fights the good fight - or at least he did. With his soul already damned to hell, he's decided to abandon his campaign against evil until a series of events thrusts him back into the fray when an old friend's daughter becomes the target of supernatural forces.", TimeSpan.FromMinutes(43), "http://ia.media-imdb.com/images/M/MV5BOTUxMjM1OTAzM15BMl5BanBnXkFtZTgwNzAyNzIxMzE@._V1_SY317_CR104,0,214,317_AL_.jpg");
            AddConstantineEpisode(season, celebrities, actor, "The Darkness Beneath", "Deep in the mountains of Western Pennsylvania, John is the small mining community's only defense against an ancient Welsh spirit. In the course of protecting these isolated innocents, John finds a vital new ally in a mysterious young woman named Zed.", TimeSpan.FromMinutes(43), "http://ia.media-imdb.com/images/M/MV5BMjE3NTQ3Njg4M15BMl5BanBnXkFtZTgwMzY3ODcxMzE@._V1_SY317_CR104,0,214,317_AL_.jpg");
            AddConstantineEpisode(season, celebrities, actor, "The Devil's Vinyl", "John and Zed engage in a dangerous confrontation to save a woman and her family from sinister forces. John's efforts force him to confront the darkness in his own life - while also coming face to face with a new powerful adversary in Papa Midnite.", TimeSpan.FromMinutes(43), "http://ia.media-imdb.com/images/M/MV5BNzU3NTM5NTMxOF5BMl5BanBnXkFtZTgwNzc4MTgzMzE@._V1_SY317_CR131,0,214,317_AL_.jpg");
            AddConstantineEpisode(season, celebrities, actor, "A Feast of Friends", "When Constantine's old friend Gary Lester accidentally releases a powerful demon in Atlanta, John is forced to determine exactly what he is prepared to sacrifice in his battle with the underworld.", TimeSpan.FromMinutes(43), "http://ia.media-imdb.com/images/M/MV5BMTQyNDEwNDYzNV5BMl5BanBnXkFtZTgwNDUwOTM0MzE@._V1_SY317_CR104,0,214,317_AL_.jpg");
            AddConstantineEpisode(season, celebrities, actor, "Danse Vaudou", "In New Orleans, Constantine's unusual knowledge of a string of crimes gets him into trouble with Detective Jim Corrigan. He must form an unholy alliance with Papa Midnite when a voodoo ritual to help people communicate with their dead loved ones takes a deadly turn.", TimeSpan.FromMinutes(43), "http://ia.media-imdb.com/images/M/MV5BMTkwMjMxMjA1MF5BMl5BanBnXkFtZTgwNDAxMTc0MzE@._V1_SY317_CR131,0,214,317_AL_.jpg");
            AddConstantineEpisode(season, celebrities, actor, "Rage of Caliban", "When a young boy is taken over by a malevolent spirit, John must put aside his misgivings over exorcising a child and convince the parents that their boy is not all that he seems.", TimeSpan.FromMinutes(43), "http://ia.media-imdb.com/images/M/MV5BMjIyOTY4ODI4Ml5BMl5BanBnXkFtZTgwNzg5OTI2MzE@._V1_SY317_CR104,0,214,317_AL_.jpg");
            AddConstantineEpisode(season, celebrities, actor, "Blessed Are the Damned", "While in art class, Zed has a bizarre vision of snakes that lead her and John to a small town where a preacher has mysteriously gained the ability to heal his congregation.", TimeSpan.FromMinutes(43), "http://ia.media-imdb.com/images/M/MV5BMTQ3NTEwMjIyNl5BMl5BanBnXkFtZTgwNzc4NDE3MzE@._V1_SY317_CR130,0,214,317_AL_.jpg");
            AddConstantineEpisode(season, celebrities, actor, "The Saint of Last Resorts", "Anne Marie, a member of the Newcastle crew, asks John and Chas for help in Mexico City -- bringing them close to the heart of the rising darkness; Zed is haunted by her past.", TimeSpan.FromMinutes(43), "http://ia.media-imdb.com/images/M/MV5BMTUxOTg4MjA0NV5BMl5BanBnXkFtZTgwMTU3NDE3MzE@._V1_SY317_CR130,0,214,317_AL_.jpg");
            AddConstantineEpisode(season, celebrities, actor, "The Saint of Last Resorts: Part 2", "ohn summons a demon into himself to help fend off an attack; Chas, Zed, and Anne Marie rush to save John.", TimeSpan.FromMinutes(43), "http://ia.media-imdb.com/images/M/MV5BNTg3OTU5NjI2OF5BMl5BanBnXkFtZTgwMDI2MjcwNDE@._V1_SY317_CR104,0,214,317_AL_.jpg");
            AddConstantineEpisode(season, celebrities, actor, "Quid Pro Quo", "When thousands of people in Brooklyn - including Chas' daughter - slip into comas, John must locate and defeat the evil forces responsible.", TimeSpan.FromMinutes(43), "http://ia.media-imdb.com/images/M/MV5BMzE0ODE0MDUxMl5BMl5BanBnXkFtZTgwOTE4ODYxNDE@._V1_SY317_CR104,0,214,317_AL_.jpg");
            AddConstantineEpisode(season, celebrities, actor, "A Whole World Out There", "John is sent to help an old friend at Ivy University, where students have figured out how to get to an alternate dimension - only to be met by a killer.", TimeSpan.FromMinutes(43), "http://ia.media-imdb.com/images/M/MV5BNzIxMDY3MjcyNF5BMl5BanBnXkFtZTgwNjE3NjkyNDE@._V1_SY317_CR104,0,214,317_AL_.jpg");
            AddConstantineEpisode(season, celebrities, actor, "Angels and Ministers of Grace", "John asks Manny to help him investigate a mysterious attack at a hospital; a health issue prompts Zed to question her visions.", TimeSpan.FromMinutes(43), null);
            AddConstantineEpisode(season, celebrities, actor, "Waiting for the Man", "John and Zed return to New Orleans when Detective Jim Corrigan asks for their help in the case of a missing girl. Papa Midnite takes steps toward exacting his revenge on John. Meanwhile, the truth behind the Rising Darkness comes to light.", TimeSpan.FromMinutes(43), null);

            context.Set<TvShow>().Add(tvShow);
        }

        private void AddConstantineEpisode(TvShowSeason season, IEnumerable<Celebrity> celebrities, CelebrityRole actor,
            string title, string synopsis, TimeSpan duration, string imageUri)
        {
            var episode = new Episode
            {
                Title = title,
                Synopsis = synopsis,
                Duration = duration,
                ImageUri = imageUri,
                Season = season,
                Cast = new List<EpisodeCastMember>(),
                Streams = new List<Mediastream>()
            };

            foreach (var celebrity in celebrities)
            {
                episode.Cast.Add(new EpisodeCastMember
                {
                    Episode = episode,
                    Name = GetConstantineNameForCelebrity(celebrity.FirstName),
                    Celebrity = celebrity,
                    Role = actor
                });
            }
            season.Episodes.Add(episode);
        }

        private string GetConstantineNameForCelebrity(string firstName)
        {
            switch (firstName)
            {
                case "Matt":
                    return "John Constantine";
                case "Charles":
                    return "Chas Chandler";
                case "Harold":
                    return "Manny";
                case "Angélica":
                    return "John Constantine";
            }

            return null;
        }

        private void AddCelebrities(DbContext context)
        {
            var set = context.Set<Celebrity>();
            // Lucy
            set.Add(new Celebrity { FirstName = "Morgan", LastName = "Freeman", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTc0MDMyMzI2OF5BMl5BanBnXkFtZTcwMzM2OTk1MQ@@._V1_UX214_CR0,0,214,317_AL_.jpg", ImdbId = "nm0000151" });
            set.Add(new Celebrity { FirstName = "Scarlett", LastName = "Johansson", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTM3OTUwMDYwNl5BMl5BanBnXkFtZTcwNTUyNzc3Nw@@._V1_UY317_CR23,0,214,317_AL_.jpg", ImdbId = "nm0424060" });
            set.Add(new Celebrity { FirstName = "Luc", LastName = "Besson", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTAwNzE4Njg0NTFeQTJeQWpwZ15BbWU3MDk0MDEyMDc@._V1_UY317_CR4,0,214,317_AL_.jpg", ImdbId = "nm0000108" });

            // Maleficent
            set.Add(new Celebrity { FirstName = "Robert", LastName = "Stromberg", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTI3NDEzNTE1MV5BMl5BanBnXkFtZTcwMTI2MzMyMw@@._V1_UX214_CR0,0,214,317_AL_.jpg", ImdbId = "nm0834902" });
            set.Add(new Celebrity { FirstName = "Angelina", LastName = "Jolie", ImageUri = "http://ia.media-imdb.com/images/M/MV5BODg3MzYwMjE4N15BMl5BanBnXkFtZTcwMjU5NzAzNw@@._V1_UY317_CR22,0,214,317_AL_.jpg", ImdbId = "nm0001401" });
            set.Add(new Celebrity { FirstName = "Elle", LastName = "Fanning", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTc0ODA1MjY5M15BMl5BanBnXkFtZTcwNzcwMDYzOQ@@._V1_UX214_CR0,0,214,317_AL_.jpg", ImdbId = "nm1102577" });
            set.Add(new Celebrity { FirstName = "Sharlto", LastName = "Copley", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMzY1MTA2NjQ1NF5BMl5BanBnXkFtZTgwMTQ5MzAzMjE@._V1_UY317_CR1,0,214,317_AL_.jpg", ImdbId = "nm1663205" });

            // The Hunger Games
            set.Add(new Celebrity { FirstName = "Francis", LastName = "Lawrence", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTI4Mjc4MTMzNF5BMl5BanBnXkFtZTYwNjkzNzc4._V1_UY317_CR101,0,214,317_AL_.jpg", ImdbId = "nm1349376" });
            set.Add(new Celebrity { FirstName = "Jennifer", LastName = "Lawrence", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTM4OTY2MDY1M15BMl5BanBnXkFtZTcwNDYyNDM3NA@@._V1_UY317_CR2,0,214,317_AL_.jpg", ImdbId = "nm2225369" });
            set.Add(new Celebrity { FirstName = "Woody", LastName = "Harrelson", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTU3NDc2ODc4MF5BMl5BanBnXkFtZTcwODk2MzAyMg@@._V1_UY317_CR1,0,214,317_AL_.jpg", ImdbId = "nm0000437" });
            set.Add(new Celebrity { FirstName = "Donald", LastName = "Sutherland", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTc0MDI1NzcyMl5BMl5BanBnXkFtZTcwOTk0MjQwOQ@@._V1_UY317_CR15,0,214,317_AL_.jpg", ImdbId = "nm0000661" });
            set.Add(new Celebrity { FirstName = "Philip Seymour", LastName = "Hoffman", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTQ0NTA1NTg3Ml5BMl5BanBnXkFtZTcwNzkxNzgxNw@@._V1_UY317_CR8,0,214,317_AL_.jpg", ImdbId = "nm0000450" });
            set.Add(new Celebrity { FirstName = "Natalie", LastName = "Dormer", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMjEwMjEyNjY4N15BMl5BanBnXkFtZTcwODE0Mzk4Nw@@._V1_UY317_CR25,0,214,317_AL_.jpg", ImdbId = "nm1754059" });

            // Constantine
            set.Add(new Celebrity { FirstName = "Matt", LastName = "Ryan", ImageUri = "http://ia.media-imdb.com/images/M/MV5BNDk1NDQ2MTY3N15BMl5BanBnXkFtZTcwMjk0Njg0Mw@@._V1_UX214_CR0,0,214,317_AL_.jpg", ImdbId = "nm1790682" });
            set.Add(new Celebrity { FirstName = "Harold", LastName = "Perrineau", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMjE4MDE4ODA5Nl5BMl5BanBnXkFtZTYwMzg0MjE0._V1_UY317_CR23,0,214,317_AL_.jpg", ImdbId = "nm0674782" });
            set.Add(new Celebrity { FirstName = "Angélica", LastName = "Celaya", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMTY5OTQ3NTMxOV5BMl5BanBnXkFtZTgwMTQwMzgyMDE@._V1_UY317_CR12,0,214,317_AL_.jpg", ImdbId = "nm1918575" });
            set.Add(new Celebrity { FirstName = "Charles", LastName = "Halford", ImageUri = "http://ia.media-imdb.com/images/M/MV5BMjI2NDY3OTEyOV5BMl5BanBnXkFtZTgwNzA5Njk4NjE@._V1_UY317_CR83,0,214,317_AL_.jpg", ImdbId = "nm0355155" });

        }

        private void AddSubscriptionsAndFeatures(DbContext context)
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

        private void AddRoles(DbContext context)
        {
            var roles = context.Set<CelebrityRole>();
            roles.Add(new CelebrityRole { Name = "director", Order = 1 });
            roles.Add(new CelebrityRole { Name = "writer", Order = 2 });
            roles.Add(new CelebrityRole { Name = "actor", Order = 3 });
            roles.Add(new CelebrityRole { Name = "producer", Order = 4 });
            roles.Add(new CelebrityRole { Name = "composer", Order = 5 });
        }

        private void AddGenres(DbContext context)
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
            genres.Add(new Genre { Name = "horror" });
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