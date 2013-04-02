using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Diagnostics;
using Microsoft.WindowsAzure.ServiceRuntime;
using Microsoft.WindowsAzure.StorageClient;
using XSocketsBoostrap = XSockets.WorkerRole.Host.XSocketsBoostrap;

namespace XSockets.WorkerRole
{
    public class WorkerRole : RoleEntryPoint
    {
        XSocketsBoostrap host;
        public override void Run()
        {
            // This is a sample worker implementation. Replace with your logic.
            Trace.WriteLine("XSockets.WorkerRole entry point called", "Information");

            
            host = new XSocketsBoostrap();

            host.Start();

            // Just display the known plugins (XSockets Contollers )
            foreach (var plugin in host._wss.XSocketPlugins)
            {
                Trace.WriteLine(string.Format("Plugin {0} is registred and ready",plugin.Value.Alias));
            }

            while (true)
            {
                Thread.Sleep(10000);
                Trace.WriteLine(string.Format("Number of connections so far {0}", host._wss.TotalNumberOfConnections));
            }
        }

        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections 
            ServicePointManager.DefaultConnectionLimit = Int16.MaxValue;

            // For information on handling configuration changes
            // see the MSDN topic at http://go.microsoft.com/fwlink/?LinkId=166357.

            return base.OnStart();
        }

        public override void OnStop()
        {
            host.Stop();
            base.OnStop();
        }
    }
}
