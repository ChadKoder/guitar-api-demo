using System;
using System.ServiceProcess;
using GuitarApi.Commands;
using Microsoft.Owin.Hosting;

namespace GuitarApi
{
    public partial class GuitarService : ServiceBase
    {
        public string baseAddress = "http://localhost:8103/";
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
            _server = WebApp.Start<Startup>(baseAddress);
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
