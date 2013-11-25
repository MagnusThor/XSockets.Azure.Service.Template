<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="XSockets.Azure.Service" generation="1" functional="0" release="0" Id="b4aa0a75-1f7e-4b1d-87ed-faa5dfe0319e" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="XSockets.Azure.ServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="XSockets3x.WorkerRole:XSocketsEndpoint1" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/LB:XSockets3x.WorkerRole:XSocketsEndpoint1" />
          </inToChannel>
        </inPort>
        <inPort name="XSockets3x.WorkerRole:XSocketsEndpoint2" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/LB:XSockets3x.WorkerRole:XSocketsEndpoint2" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="XSockets3x.WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="">
          <maps>
            <mapMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/MapXSockets3x.WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </maps>
        </aCS>
        <aCS name="XSockets3x.WorkerRole:XSocketsHostUri" defaultValue="">
          <maps>
            <mapMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/MapXSockets3x.WorkerRole:XSocketsHostUri" />
          </maps>
        </aCS>
        <aCS name="XSockets3x.WorkerRole:XSocketsOrigins" defaultValue="">
          <maps>
            <mapMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/MapXSockets3x.WorkerRole:XSocketsOrigins" />
          </maps>
        </aCS>
        <aCS name="XSockets3x.WorkerRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/MapXSockets3x.WorkerRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:XSockets3x.WorkerRole:XSocketsEndpoint1">
          <toPorts>
            <inPortMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets3x.WorkerRole/XSocketsEndpoint1" />
          </toPorts>
        </lBChannel>
        <lBChannel name="LB:XSockets3x.WorkerRole:XSocketsEndpoint2">
          <toPorts>
            <inPortMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets3x.WorkerRole/XSocketsEndpoint2" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapXSockets3x.WorkerRole:Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" kind="Identity">
          <setting>
            <aCSMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets3x.WorkerRole/Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" />
          </setting>
        </map>
        <map name="MapXSockets3x.WorkerRole:XSocketsHostUri" kind="Identity">
          <setting>
            <aCSMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets3x.WorkerRole/XSocketsHostUri" />
          </setting>
        </map>
        <map name="MapXSockets3x.WorkerRole:XSocketsOrigins" kind="Identity">
          <setting>
            <aCSMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets3x.WorkerRole/XSocketsOrigins" />
          </setting>
        </map>
        <map name="MapXSockets3x.WorkerRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets3x.WorkerRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="XSockets3x.WorkerRole" generation="1" functional="0" release="0" software="C:\Users\Magnus Thor\Documents\GitHub\XSockets.Azure.Service.Template\XSockets.Azure.Service\csx\Debug\roles\XSockets3x.WorkerRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="XSocketsEndpoint1" protocol="tcp" portRanges="4510" />
              <inPort name="XSocketsEndpoint2" protocol="tcp" portRanges="4511" />
            </componentports>
            <settings>
              <aCS name="Microsoft.WindowsAzure.Plugins.Diagnostics.ConnectionString" defaultValue="" />
              <aCS name="XSocketsHostUri" defaultValue="" />
              <aCS name="XSocketsOrigins" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;XSockets3x.WorkerRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;XSockets3x.WorkerRole&quot;&gt;&lt;e name=&quot;XSocketsEndpoint1&quot; /&gt;&lt;e name=&quot;XSocketsEndpoint2&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets3x.WorkerRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets3x.WorkerRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets3x.WorkerRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="XSockets3x.WorkerRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="XSockets3x.WorkerRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="XSockets3x.WorkerRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="477596c5-0613-43fb-ba83-1f777e1539c3" ref="Microsoft.RedDog.Contract\ServiceContract\XSockets.Azure.ServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="9d836f38-b7ac-410a-b212-7f4ca46b079b" ref="Microsoft.RedDog.Contract\Interface\XSockets3x.WorkerRole:XSocketsEndpoint1@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets3x.WorkerRole:XSocketsEndpoint1" />
          </inPort>
        </interfaceReference>
        <interfaceReference Id="569a9c91-010c-499e-9788-a60729d57558" ref="Microsoft.RedDog.Contract\Interface\XSockets3x.WorkerRole:XSocketsEndpoint2@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets3x.WorkerRole:XSocketsEndpoint2" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>