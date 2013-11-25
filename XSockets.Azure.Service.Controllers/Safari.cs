using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XSockets.Core.Common.Socket.Event.Interface;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;

namespace XSockets.Azure.Service.Controllers
{
    // This controllers is referenced by the XSockets.WorkerRole
    public class Safari: XSocketController
    {
        /// <summary>
        /// Give the controller a Generic behavior, pass inbound textArgs to others that has a subscription to it.
        /// </summary>
        /// <param name="textArgs"></param>
        public override void OnMessage(ITextArgs textArgs)
        {
            this.SendToAll(textArgs);
        }
        public void Echo()
        {
            this.Send(new {Zoo = "Bar"}.AsTextArgs("Echo"));
        }
    }
}
