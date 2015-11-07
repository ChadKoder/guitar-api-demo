using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using GuitarApi.Commands;
using GuitarApi.controllers;
using GuitarApi.Formatters;
using GuitarApi.handlers;
using GuitarApi.Interfaces;
using GuitarApi.Queries;
using Owin;
using IContainer = Autofac.IContainer;

namespace GuitarApi
{
    class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            appBuilder.UseWebApi(BuildHttpConfigurations());
            /*refresh DB data*/
            new DeleteAllFromRepository().Delete();
            new CreateSampleData().Create();
        }

        private HttpConfiguration BuildHttpConfigurations()
        {
            HttpConfiguration config = new HttpConfiguration();
            //config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.Formatters.Add(new JsonpMediaTypeFormatter());
            config.MessageHandlers.Add(new CorsHandler(new CorsOptions()));
            config.Formatters.XmlFormatter.UseXmlSerializer = false;
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            config.MapHttpAttributeRoutes();

            var resolver = new AutofacWebApiDependencyResolver(BuildContainer());
            config.DependencyResolver = resolver;

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(name: "GuitarApi",
            routeTemplate: "api/Guitar/{action}",
            defaults: new { controller = "Guitar", action = "{action}" });

            return config;
        }

        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GetGuitarsByCompany>().As<IGetGuitarsByCompany>().AsImplementedInterfaces();
            builder.RegisterType<GetAllGuitars>().As<IGetAllGuitars>().AsImplementedInterfaces();
            builder.Register(c => new GuitarController(c.Resolve<IGetGuitarsByCompany>(), c.Resolve<IGetAllGuitars>()));
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(GuitarController)));
            var container = builder.Build();
            
            return container;
        }
    }
}
