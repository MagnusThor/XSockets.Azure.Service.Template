using System.Diagnostics;
using System.Net;
using System.Threading;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace XSockets3x.WorkerRole.Host
{
    public class WorkerRole : RoleEntryPoint
    {
        private XSocketsBoostrap _host;
        public override void Run()
        {
            while (true)
            {
                Thread.Sleep(10000);
                Trace.TraceInformation("Working", "Information");
            }
        }

        public override bool OnStart()
        {
            _host = new XSocketsBoostrap();
            _host.Start();
            return base.OnStart();
        }
    }
}
