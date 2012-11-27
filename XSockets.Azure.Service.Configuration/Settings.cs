using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.ServiceRuntime;
using XSockets.Core.Common.Configuration;
using XSockets.Core.Configuration;
using XSockets.Plugin.Framework.Core.Attributes;

namespace XSockets.Azure.Service.Configuration
{
    [Export(typeof (IConfigurationLoader))]
    public class AzureConfigurationLoader : IConfigurationLoader
    {
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
                if (_settings == null)
                {
                    Uri uri = GetUri(RoleEnvironment.GetConfigurationSettingValue("XSocketsHostUri"));
                    _settings = new ConfigurationSettings
                        {
                            Endpoint =
                                RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["XSocketsEndpoint"].IPEndpoint,
                            Port = uri.Port,
                            Origin = new List<string> {"*"},
                            Location = uri.Host,
                            Scheme = uri.Scheme,
                            Uri = uri,
                            BufferSize = 8192,
                            RemoveInactiveStorageAfterXDays = 7,
                            RemoveInactiveChannelsAfterXMinutes = 30,
                            NumberOfAllowedConections = -1
                        };
                }
                return _settings;
            }
        }
    }
}