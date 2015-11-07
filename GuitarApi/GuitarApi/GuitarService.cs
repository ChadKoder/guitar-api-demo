using System;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace GuitarApi
{
    public partial class GuitarService : ServiceBase
    {
        private const string BaseAddress = "http://localhost:8103/";
        private IDisposable _server;
        
        public GuitarService()
        {
            InitializeComponent();
        }

        public void StartApp(string[] args)
        {
            OnStart(args);
        }

        protected override void OnStart(string[] args)
        {
            _server = WebApp.Start<Startup>(BaseAddress);
        }

        public void StopApp()
        {
            OnStop();
        }

        protected override void OnStop()
        {
            if(_server != null)
            {
                _server.Dispose();
            }
            
            base.OnStop();
        }
    }
}
