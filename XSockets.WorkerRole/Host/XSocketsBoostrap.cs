using XSockets.Core.Common.Socket;
using XSockets.Plugin.Framework.Core.Attributes;
using XSockets.Plugin.Framework.Helpers;

namespace XSockets.WorkerRole.Host
{
    public class XSocketsBoostrap
    {
        [ImportOne(typeof(IXBaseServerContainer))]
        public IXBaseServerContainer Wss { get; set; }

        public XSocketsBoostrap()
        {
            Wss = XSockets.Plugin.Framework.Composable.GetExport<IXBaseServerContainer>();
        }

        public void Start()
        {

            Wss.StartServers();
        }

        public void Stop()
        {
            Wss.StopServers();
        }
    }
}