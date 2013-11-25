XSockets.Azure.Service.Template
===============================

# Info

This is an simple example/template that shows how to setup & run  XSockets.NET (Using XSockets.NET 3.0.1.)  as a Windows Azure Cloud Service/WorkerRole
(Background processing service).  

> Note that we are running  [We are using Windows Azure SDK for .NET
> 2.2][1]

The example contains two project **XSockets3x.WorkerRole** and **XSockets.Azure.Service.Controllers**. The purpose of the controller project is to show you where to put the real-time controller's of yours.  

## Settings
The worker role has the following role-environment configuration's. 

### Settings
- "**XSocketsHostUri**", the Url that your clients connect to (IP/Hostname). default setting is ws://localhost:4511/
-  **XSocketsOrigins**", A comma separated list of origins ( locations ) that your XSockets.NET Service will accept traffic / connections from. Defaults to http://* and https://*

See the *XSockets3x.WorkerRole.Helpers.ConfigurationHelper* class found in XSockets3x.WorkerRole for details.

### Endpoints

We also defined two TCP endpoints under the *endpoints tab* . For each TCP endpoint defined a  server will be stared. The example defaults to two endpoints listening on port 4510 & 4511. 

####Details

The **XSockets3x.WorkerRole.XSocketsBoostrap** class contains the following method

    // For each TCP Enpoint defined on the role, create a new "cofiguration"
    
    var configurations = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints.Values.Where(p => p.Protocol.Equals("tcp")).Select(instanceEndpoint => ConfigurationHelper.Create(instanceEndpoint.IPEndpoint)).ToList();
    
    // Start the server/servers based on the InstanceEndpoints defined for this role.
    
    Wss.StartServers(false, false, configurations);
    
    ....

##Upgrading

If you want to uppgrade the example to an later version than XSockets.NET 3.0.1 (latest version by 25th of november 2013 ).  You must perform the following tasks.

On **XSockets3x.WorkerRole** run the following commands in the Package Manager Console

    PM-> Update-Package XSockets.Core
    PM-> Update-Package XSockets.Server

On the XSockets.Azure.Service.Contollers run the following commands in the Package Manager Console

    PM-> Update-Package XSockets.Core

**Kind regards, Team XSockest.NET**


  [1]: http://www.windowsazure.com/en-us/develop/visual-studio-2013/