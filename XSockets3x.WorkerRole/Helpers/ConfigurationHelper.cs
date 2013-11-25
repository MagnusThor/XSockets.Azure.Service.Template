using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Microsoft.WindowsAzure.ServiceRuntime;
using XSockets.Core.Common.Configuration;
using XSockets.Core.Configuration;

namespace XSockets3x.WorkerRole.Helpers
{
  
    public static class  ConfigurationHelper 
    {
        /// <summary>
        /// Get a Url from the WorkerRole settings 
        /// </summary>
        /// <returns></returns>
        static Uri GetUri()
        {
            try
            {
                return new Uri(RoleEnvironment.GetConfigurationSettingValue("XSocketsHostUri"));
            }
            catch (Exception)
            {
                throw new Exception("Unable to get the XSocketsHostUri from from the WorkerRole settings");
            }
        }

        /// <summary>
        /// Get the trusted origins from the WorkerRole settings
        /// </summary>
        /// <returns></returns>
        static HashSet<string> GetOrigins()
        {
            var origins = RoleEnvironment.GetConfigurationSettingValue("XSocketsOrigins");
            return  new HashSet<string>(!string.IsNullOrEmpty(origins) ? origins.Split(',').ToList() : new List<string> { "*" });
        }

        public static IConfigurationSetting Create(IPEndPoint endPoint)
        {
            var setting = new ConfigurationSetting();
            var uri = GetUri();
            setting.Endpoint = endPoint;
            setting.Port = uri.Port;
            setting.Origin = GetOrigins();
            setting.Location = uri.Host;
            setting.Scheme = uri.Scheme;
            setting.Uri = uri;
            setting.BufferSize = 8192;
            return setting;
        }
    }
}