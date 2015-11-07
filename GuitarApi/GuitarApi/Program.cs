using System;
using System.ServiceProcess;
using System.Windows.Forms;
using log4net;

namespace GuitarApi
{
    static class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        public static void Main(string[] args)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure();
                RunAsServiceOrConsole(args);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Application failed to load. {0}", ex.Message);
            }
        }

        private static void RunAsServiceOrConsole(string[] args)
        {
            var runAsService = CommandLineParser.ShouldRunAsService(args);

            if (runAsService)
            {
                ServiceBase[] ServicesToRun;
                ServicesToRun = new ServiceBase[]
                    {
                        new GuitarService()
                    };

                Log.Info("Launching application as service...");
                ServiceBase.Run(ServicesToRun);
            }
            else
            {
                Log.Info("Launching application as console...");
                RunAsConsole(args);
            }
        }

        private static void RunAsConsole(string[] args)
        {
            using (GuitarService service = new GuitarService())
            {
                using (DebugView debugView = new DebugView())
                {
                    debugView.Show();
                    service.StartApp(args);

                    while (!debugView.Stop)
                    {
                        Application.DoEvents();

                        if (debugView.Stop)
                        {
                            service.StopApp();
                        }
                    }
                }
            }
        }
    }
}