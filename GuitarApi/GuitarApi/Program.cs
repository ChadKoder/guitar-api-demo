using System;
using System.ServiceProcess;
using System.Windows.Forms;
using log4net;

namespace GuitarApi
{
    static class Program
    {
      //  private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private static readonly ILog Log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static void Main(string[] args)
        {
            try
            {
                BuildContainer();
                WriteDate();

                log4net.Config.XmlConfigurator.Configure();
             
                var runAsService = CommandLineParser.ShouldRunAsService(args);

                if (runAsService)
                {
                    ServiceBase[] ServicesToRun;
                    ServicesToRun = new ServiceBase[]
                    {
                        new GuitarService()
                    };

                    ServiceBase.Run(ServicesToRun);
                }
                else
                {
                    Log.Debug("Running application as console...");
                    RunAsConsole(args);
                }
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Application failed to load. {0}", ex.Message);
            }
        }

        private static void BuildContainer()
        {
        }

        private static void WriteDate()
        {
        }

        private static void RunAsConsole(string[] args)
        {
            using (GuitarService service = new GuitarService())
            {
                using (DebugView debugView = new DebugView())
                {
                    debugView.Show();
                    
                    while (!debugView.Stop)
                    {
                        Application.DoEvents();
                    }
                }
            }
        }
    }
}