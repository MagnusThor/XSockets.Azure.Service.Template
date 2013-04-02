using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;

namespace XSockets.Azure.Service.Controllers
{
    // This controllers is referenced by the XSockets.WorkerRole
    public class Safari: XSocketController
    {
        public void Echo()
        {
            this.Send(new {Zoo = "Bar"}.AsTextArgs("Echo"));
        }
    }
}
