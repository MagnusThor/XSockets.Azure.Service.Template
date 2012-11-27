using System;
using System.Diagnostics;
using XSockets.Core.Common.Socket;
using XSockets.Core.Common.Socket.Event.Arguments;
using XSockets.Plugin.Framework.Core.Attributes;
using XSockets.Plugin.Framework.Helpers;

namespace XSockets.Azure.Service.Host
{

    public class Instance
    {
        [ImportOne(typeof(IXBaseServerContainer))]

        public IXBaseServerContainer wss { get; set; }

        public Instance()
        {
            try
            {
                Trace.AutoFlush = true;
                this.ComposeMe();
                wss.OnServersStarted += wss_OnServersStarted;
                wss.OnServerClientConnection += wss_OnServerClientConnection;
                wss.OnServerClientDisconnection += wss_OnServerClientDisconnection;
                wss.OnError += wss_OnError;
                wss.OnIncommingTextData += wss_OnIncommingTextData;
                wss.OnOutgoingText += wss_OnOutgoingText;
                wss.OnServersStopped += wss_OnServersStopped;
                wss.StartServers();

            }
            catch (Exception ex)
            {
                Trace.WriteLine("Exception while starting server");
                Trace.WriteLine(ex.Message);
                Trace.WriteLine(ex.StackTrace);
                Trace.WriteLine("Press enter to quit");
            }
        }

        void wss_OnOutgoingText(object sender, TextArgs e)
        {
            Trace.WriteLine("");
            Trace.WriteLine("Outgoing TextMessage");
            Trace.WriteLine("Handler: " + ((IXBaseSocket)sender).Alias);
            //Check fo null since XNode might not be set if the handshake was invalid.
            //Then we will be sending directly on the socket.
            if (((IXBaseSocket)sender).XNode != null)
                Trace.WriteLine("Sender: " + ((IXBaseSocket)sender).XNode.ClientGuid);
            Trace.WriteLine("Event: " + e.@event);
            Trace.WriteLine("Data: " + e.data);
            Trace.WriteLine("");
        }

        void wss_OnIncommingTextData(object sender, TextArgs e)
        {
            Trace.WriteLine("");
            Trace.WriteLine("Incomming TextMessage");
            Trace.WriteLine("Handler: " + ((IXBaseSocket)sender).Alias);
            Trace.WriteLine("Sender: " + ((IXBaseSocket)sender).XNode.ClientGuid);
            Trace.WriteLine("Event: " + e.@event);
            Trace.WriteLine("Data: " + e.data);
            Trace.WriteLine("");
        }

        void wss_OnError(object sender, OnErrorArgs e)
        {
            Trace.WriteLine("");
            Trace.WriteLine("Error");
            Trace.WriteLine("ExceptionMessage: " + e.Exception.Message);
            Trace.WriteLine("CustomMessage: " + e.Message);
            Trace.WriteLine("");
        }

        void wss_OnServerClientDisconnection(object sender, OnClientDisConnectArgs e)
        {
            Trace.WriteLine("");
            Trace.WriteLine("Disconnected");
            Trace.WriteLine("Handler: " + ((IXBaseSocket)sender).Alias);
            Trace.WriteLine("ClientGuid: " + e.XNode.ClientGuid);
            Trace.WriteLine("");
        }

        void wss_OnServerClientConnection(object sender, OnClientConnectArgs e)
        {
            Trace.WriteLine("");
            Trace.WriteLine("Connected");
            Trace.WriteLine("Handler: " + ((IXBaseSocket)sender).Alias);
            Trace.WriteLine("ClientGuid: " + e.XNode.ClientGuid);
            Trace.WriteLine("");
        }

        void wss_OnServersStarted(object sender, EventArgs e)
        {
            Trace.WriteLine("[XSockets Development Server]");
            Trace.WriteLine("[Servers Started]");

            Trace.WriteLine("_______________________XSOCKET HANDLERS_________________________________");
            foreach (var plugin in wss.XSocketFactory.Plugins)
            {
                Trace.WriteLine("Alias:\t\t" + plugin.Alias);
                Trace.WriteLine("BufferSize:\t" + plugin.BufferSize);
                Trace.WriteLine("PluginRange:\t" + plugin.PluginRange);
                Trace.WriteLine("Custom Events:");
                if (plugin.CustomEvents == null)
                    Trace.WriteLine("\tNone...");
                else
                    foreach (var customEventList in plugin.CustomEvents)
                        foreach (var customEvent in customEventList.Value)
                        {
                            Trace.WriteLine("\tMethodName:\t" + customEvent.MethodInfo.Name);
                            Trace.WriteLine("\tHandlerEvent:\t" + customEventList.Key);
                        }
                Trace.WriteLine("");
            }
            Trace.WriteLine("________________________________________________________________________");
            Trace.WriteLine("");
            Trace.WriteLine("_______________________XSOCKET PROTOCOLS________________________________");
            foreach (var plugin in wss.XSocketProtocolFactory.Protocols)
            {
                Trace.WriteLine("Identifier: " + plugin.ProtocolIdentifier);
            }
            Trace.WriteLine("________________________________________________________________________");
            Trace.WriteLine("");
            Trace.WriteLine("_______________________XSOCKET INTERCEPTORS_____________________________");
            foreach (var plugin in wss.MessageInterceptors)
            {
                Trace.WriteLine("Type: " + plugin.GetType().Name);
            }
            foreach (var plugin in wss.ConnectionInterceptors)
            {
                Trace.WriteLine("Type: " + plugin.GetType().Name);
            }
            foreach (var plugin in wss.HandshakeInterceptors)
            {
                Trace.WriteLine("Type: " + plugin.GetType().Name);
            }
            foreach (var plugin in wss.ErrorInterceptors)
            {
                Trace.WriteLine("Type: " + plugin.GetType().Name);
            }
            Trace.WriteLine("________________________________________________________________________");
        }

        void wss_OnServersStopped(object sender, EventArgs e)
        {
            Trace.WriteLine("");
            Trace.WriteLine("[XSockets Development Server]");
            Trace.WriteLine("[Servers Stopped]");
            Trace.WriteLine("");
        }
    }
}
