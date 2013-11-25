using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.WindowsAzure.ServiceRuntime;
using XSockets.Core.Common.Configuration;
using XSockets.Core.Common.Socket;
using XSockets.Plugin.Framework.Attributes;
using XSockets3x.WorkerRole.Helpers;

namespace XSockets3x.WorkerRole
{
    public class XSocketsBoostrap
    {
        [ImportOne(typeof(IXSocketServerContainer))]
        public IXSocketServerContainer Wss { get; set; }

        public XSocketsBoostrap()
        {
            Wss = XSockets.Plugin.Framework.Composable.GetExport<IXSocketServerContainer>();
        }

        public void Start()
        {
            // For each TCP Enpoint defined on the role, create a new "cofiguration"
            var configurations = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints.Values.Where(p => p.Protocol.Equals("tcp")).Select(instanceEndpoint => ConfigurationHelper.Create(instanceEndpoint.IPEndpoint)).ToList();
            // Start the server/servers based on the InstanceEndpoints defined for this role.
            Wss.StartServers(false, false, configurations);
        }

        public void Stop()
        {
            Wss.StopServers();
        }
    }
}