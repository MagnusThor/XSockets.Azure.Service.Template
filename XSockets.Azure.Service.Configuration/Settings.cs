using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.WindowsAzure.ServiceRuntime;
using XSockets.Core.Common.Configuration;
using XSockets.Plugin.Framework.Core.Attributes;

namespace XSocketsLive.Config
{

    [Export(typeof(IConfigurationLoader))]
    public class AzureConfigurationLoader : IConfigurationLoader
    {
        public AzureConfigurationLoader()
        {
        }

        public IConfigurationSettings _settings = null;

        public Uri GetUri(string url)
        {
            try
            {

                return new Uri(url);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public IConfigurationSettings ConfigurationSettings
        {
            get
            {
                if (this._settings == null)
                {
                    var uri = GetUri(RoleEnvironment.GetConfigurationSettingValue("XSocketsHostUri"));
                    

                    this._settings = new XSockets.Core.Configuration.ConfigurationSettings
                    {

                        Endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["XSocketsEndpoint"].IPEndpoint,
                        Port = uri.Port,
                        Origin = new List<string>() { "*" },
                        Location = uri.Host,
                        Scheme = uri.Scheme,
                        Uri = uri,
                        BufferSize = 8192,
                        RemoveInactiveStorageAfterXDays = 7,
                        RemoveInactiveChannelsAfterXMinutes = 30,
                        NumberOfAllowedConections = -1
                    };
                }
                return this._settings;
            }
        }
    }
}