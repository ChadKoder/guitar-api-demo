using System.Web.Http;
using GuitarApi.Commands;
using GuitarApi.Formatters;
using GuitarApi.handlers;
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
