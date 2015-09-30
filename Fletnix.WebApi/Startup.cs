using System;
using System.Collections.Generic;
using System.Net.Http.Formatting;
using System.Web.Http;
using Microsoft.Owin;
using Newtonsoft.Json.Serialization;
using Owin;
using Autofac;
using Autofac.Integration.WebApi;
using Fletnix.WebApi.Autofac;

[assembly: OwinStartup(typeof(Fletnix.WebApi.Startup))]
namespace Fletnix.WebApi
{
    public sealed class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            // Authentication 
            ConfigureAuth(app);

            // API Media type formatter configuration
            ConfigureMediaTypeFormatters(config);

            // Add an AuthorizeAttribute to disallow anonymous access by default
            // config.Filters.Add(new AuthorizeAttribute());

            // Configure dependency injection
            ConfigureAutofac(config);

            // Enable attribute-based routing
            config.MapHttpAttributeRoutes();

            // Enable Web API
            app.UseWebApi(config);
        }

        private void ConfigureMediaTypeFormatters(HttpConfiguration configuration)
        {
            // Remove all formatters (to get rid of the XML one)
            configuration.Formatters.Clear();

            // And add a JSON formatter that's configured using better defaults
            var jsonFormatter = new JsonMediaTypeFormatter
            {
                SerializerSettings = {ContractResolver = new CamelCasePropertyNamesContractResolver()}
            };
            configuration.Formatters.Add(jsonFormatter);
        }

        private void ConfigureAuth(IAppBuilder app)
        {
        }

        private void ConfigureAutofac(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<RepositoryModule>();
            builder.RegisterApiControllers(GetType().Assembly);

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}