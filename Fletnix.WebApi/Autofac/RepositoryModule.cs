using Autofac;
using Fletnix.Data;
using Fletnix.Data.Repositories;
using Fletnix.Data.Services;

namespace Fletnix.WebApi.Autofac
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder
                .RegisterType<FletnixDbContext>()
                .AsSelf()
                .InstancePerRequest();

            builder
                .RegisterGeneric(typeof (BaseRepository<>))
                .AsImplementedInterfaces()
                .InstancePerRequest();

            builder.RegisterType<SubscriptionService>().AsImplementedInterfaces();
        }
    }
}