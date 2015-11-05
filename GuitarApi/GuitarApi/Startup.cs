using System.ComponentModel;
using System.Diagnostics;
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

namespace GuitarApi
{
    class Startup
    {
        public void Configuration(IAppBuilder appBuilder)
        {
            HttpConfiguration config = new HttpConfiguration();
            //config.Formatters.Remove(config.Formatters.XmlFormatter);
            
            config.Formatters.Add(new JsonpMediaTypeFormatter());
            config.MessageHandlers.Add(new CorsHandler(new CorsOptions()));
            config.Formatters.XmlFormatter.UseXmlSerializer = false;
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = true;
            config.MapHttpAttributeRoutes();

            var builder = new ContainerBuilder();
            builder.RegisterType<GetGuitarsByCompany>().As<IGetGuitarsByCompany>().AsImplementedInterfaces();
            builder.RegisterType<GetAllGuitars>().As<IGetAllGuitars>().AsImplementedInterfaces();
            builder.RegisterType<GetGuitarsByCompany>().As<IGetGuitarsByCompany>().InstancePerLifetimeScope();
            builder.RegisterType<GetAllGuitars>().As<IGetAllGuitars>().InstancePerLifetimeScope();
            builder.Register(c => new GuitarController(c.Resolve<IGetGuitarsByCompany>(), c.Resolve<IGetAllGuitars>()));
            builder.RegisterAssemblyTypes(Assembly.GetAssembly(typeof(GuitarController)));
            var container = builder.Build();
            container.Resolve<IGetGuitarsByCompany>();
            var resolver = new AutofacWebApiDependencyResolver(container);

            config.DependencyResolver = resolver;
            
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(name: "GuitarApi",
            routeTemplate: "api/Guitar/{action}",
            defaults: new { controller = "Guitar", action = "{action}" });
            
            appBuilder.UseWebApi(config);

            new CreateSampleData().Create();
        }
    }
}
