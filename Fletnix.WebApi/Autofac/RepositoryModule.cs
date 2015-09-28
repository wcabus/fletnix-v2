using Autofac;
using Fletnix.Data.Repositories;

namespace Fletnix.WebApi.Autofac
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SubscriptionRepository>().AsImplementedInterfaces();
        }
    }
}