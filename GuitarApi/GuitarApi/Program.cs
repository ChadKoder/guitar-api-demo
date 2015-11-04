using System.ServiceProcess;
using Autofac;
using GuitarApi.Interfaces;
using GuitarApi.Queries;

namespace GuitarApi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GetGuitarsByCompany>().As<IGetGuitarsByCompany>();

            var container = builder.Build();
            container.Resolve<IGetGuitarsByCompany>();
            
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new GuitarService()
            };

            ServiceBase.Run(ServicesToRun);
        }
    }
}