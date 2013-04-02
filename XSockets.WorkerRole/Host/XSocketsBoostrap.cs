using XSockets.Core.Common.Socket;
using XSockets.Plugin.Framework.Core.Attributes;
using XSockets.Plugin.Framework.Helpers;

namespace XSockets.WorkerRole.Host
{
    public class XSocketsBoostrap
    {
        [ImportOne(typeof(IXBaseServerContainer))]
        public IXBaseServerContainer _wss { get; set; }

        public XSocketsBoostrap()
        {
            this.ComposeMe();
        }

        public void Start()
        {

            _wss.StartServers();
        }

        public void Stop()
        {
            _wss.StopServers();
        }
    }
}