using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Fletnix.Models;

namespace Fletnix.Data
{
    public sealed class FletnixDbContext : DbContext
    {
        public FletnixDbContext() : base("FletnixDB")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer(new FletnixSeeder());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Let's use singular table names
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Entity configuration
            var genre = modelBuilder.Entity<Genre>();
            genre.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            genre.Property(p => p.Name).IsRequired().HasMaxLength(50);

            var celebRole = modelBuilder.Entity<CelebrityRole>();
            celebRole.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            celebRole.Property(p => p.Name).IsRequired().HasMaxLength(50);

            var celebrity = modelBuilder.Entity<Celebrity>();
            celebrity.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            celebrity.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            celebrity.Property(p => p.LastName).IsRequired().HasMaxLength(100);
            celebrity.Property(p => p.ImdbId).IsUnicode(false).HasMaxLength(50);
            celebrity.Property(p => p.ImageUri).IsUnicode(false).HasMaxLength(1000);

            var tvShow = modelBuilder.Entity<TvShow>();
            tvShow.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            tvShow.Property(p => p.Title).IsRequired().HasMaxLength(200);
            tvShow.Property(p => p.ImageUri).HasMaxLength(1000);

            tvShow
                .HasMany(t => t.Genres)
                .WithMany()
                .Map(m => m
                    .ToTable("TvShowGenre")
                    .MapLeftKey("TvShowId")
                    .MapRightKey("GenreId"));

            tvShow
                .HasMany(t => t.Seasons)
                .WithRequired(s => s.TvShow)
                .HasForeignKey(s => s.TvShowId)
                .WillCascadeOnDelete();

            var season = modelBuilder.Entity<TvShowSeason>();
            season.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            season.Property(p => p.SeasonNr).IsRequired();

            var episode = modelBuilder.Entity<Episode>();
            episode.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            episode.Property(p => p.Title).HasMaxLength(200);
            episode.Property(p => p.ImageUri).HasMaxLength(1000);

            episode
                .HasMany(e => e.Cast)
                .WithRequired()
                .HasForeignKey(c => c.ParentId)
                .WillCascadeOnDelete();

            episode
                .HasRequired(e => e.Season)
                .WithMany(s => s.Episodes)
                .HasForeignKey(e => e.SeasonId);

            var movie = modelBuilder.Entity<Movie>();
            movie.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            movie.Property(p => p.Title).IsRequired().HasMaxLength(200);
            movie.Property(p => p.ImageUri).HasMaxLength(1000);

            movie
                .HasMany(m => m.Genres)
                .WithMany()
                .Map(m => m
                    .ToTable("MovieGenre")
                    .MapLeftKey("MovieId")
                    .MapRightKey("GenreId"));

            movie
                .HasMany(m => m.Cast)
                .WithRequired()
                .HasForeignKey(c => c.ParentId)
                .WillCascadeOnDelete();

            var cast = modelBuilder.Entity<CastMember>();
            cast.HasKey(c => new {c.ParentId, c.CelebrityId, c.RoleId});

            cast
                .HasRequired(c => c.Celebrity)
                .WithMany()
                .HasForeignKey(c => c.CelebrityId);

            cast
                .HasRequired(c => c.Role)
                .WithMany()
                .HasForeignKey(c => c.RoleId);

            var customer = modelBuilder.Entity<Customer>();
            customer.Property(p => p.Email).IsRequired().HasMaxLength(500);
            customer.Property(p => p.FirstName).IsRequired().HasMaxLength(100);
            customer.Property(p => p.LastName).IsRequired().HasMaxLength(100);

            var feature = modelBuilder.Entity<Feature>();
            feature.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            feature.Property(p => p.Name).IsRequired().HasMaxLength(100);
            feature.Property(p => p.Description).HasMaxLength(2000);

            var subscription = modelBuilder.Entity<Subscription>();
            subscription.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            subscription.Property(p => p.Name).IsRequired().HasMaxLength(40);
            subscription.Property(p => p.Price).IsRequired();

            subscription
                .HasMany(s => s.Features)
                .WithRequired()
                .HasForeignKey(f => f.SubscriptionId)
                .WillCascadeOnDelete();

            var customerSubscription = modelBuilder.Entity<CustomerSubscription>();
            customerSubscription.Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            customerSubscription.Ignore(p => p.IsSubscribed);

            customerSubscription
                .HasRequired(c => c.Subscription)
                .WithMany()
                .HasForeignKey(c => c.SubscriptionId);

            customerSubscription
                .HasRequired(c => c.Customer)
                .WithOptional(c => c.Subscription)
                .Map(m => m.MapKey("CustomerId"));
        }
    }
}