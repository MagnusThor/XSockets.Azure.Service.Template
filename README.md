XSockets.Azure.Service.Template
===============================

# Info

This is an simple example/template that shows how to run XSockets.NET as a Windows Azure Cloud Service 
(Background processing service). Using XSockets.NET 2.5.2

We simplified the example a bit and removed the Configuration and Host projects. Instead we added
a project containing just a stub for a custom controller ( see XSockets.Azure.Service.Controllers )

At http://xsockets.net/api/installation you will find futher information.

## Settings

The worker role has the following configuration settings

### Settings tab

- "XSocketsHostUri", the Url that your clients connect to (IP/Hostname). default setting is ws://localhost:10101
-  XSocketsOrigins", A comma separated list of origins ( locations ) that your XSockets.NET Service will accept traffic / connections from. Defaults to http://* and https://*


### Endpoints tab

"XSocketsEndpoint" , this is the TCP endpoint of the role.  The value of the port numbers specified must be assosiated with port specified in "XSocketsHostUri". Default 10101  

================================================
Kind regards
	Team XSockets.NET