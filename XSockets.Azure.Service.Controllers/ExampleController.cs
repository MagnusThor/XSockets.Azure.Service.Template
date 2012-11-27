using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XSockets.Core.XSocket;
using XSockets.Core.XSocket.Helpers;

namespace XSockets.Azure.Service.Controllers
{
    
    public class ExampleController : XBaseSocket
    {
        public void ExampleAction(MyModel model)
        {
            this.SendToAll(model, "onExampleActionResult");
            // Pass model forward to all clients that are subscribing to "onExampleActionResult"
        }
    }

    public class MyModel
    {
        public string Name { get; set; }
    }
}
