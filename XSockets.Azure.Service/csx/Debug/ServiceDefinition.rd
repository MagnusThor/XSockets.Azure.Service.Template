<?xml version="1.0" encoding="utf-8"?>
<serviceModel xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" name="XSockets.Azure.Service" generation="1" functional="0" release="0" Id="63665189-da4f-4ac9-9139-0c071c0c0072" dslVersion="1.2.0.0" xmlns="http://schemas.microsoft.com/dsltools/RDSM">
  <groups>
    <group name="XSockets.Azure.ServiceGroup" generation="1" functional="0" release="0">
      <componentports>
        <inPort name="XSockets.WorkerRole:XSocketsEndpoint" protocol="tcp">
          <inToChannel>
            <lBChannelMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/LB:XSockets.WorkerRole:XSocketsEndpoint" />
          </inToChannel>
        </inPort>
      </componentports>
      <settings>
        <aCS name="XSockets.WorkerRole:XSocketsHostUri" defaultValue="">
          <maps>
            <mapMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/MapXSockets.WorkerRole:XSocketsHostUri" />
          </maps>
        </aCS>
        <aCS name="XSockets.WorkerRole:XSocketsOrigins" defaultValue="">
          <maps>
            <mapMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/MapXSockets.WorkerRole:XSocketsOrigins" />
          </maps>
        </aCS>
        <aCS name="XSockets.WorkerRoleInstances" defaultValue="[1,1,1]">
          <maps>
            <mapMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/MapXSockets.WorkerRoleInstances" />
          </maps>
        </aCS>
      </settings>
      <channels>
        <lBChannel name="LB:XSockets.WorkerRole:XSocketsEndpoint">
          <toPorts>
            <inPortMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets.WorkerRole/XSocketsEndpoint" />
          </toPorts>
        </lBChannel>
      </channels>
      <maps>
        <map name="MapXSockets.WorkerRole:XSocketsHostUri" kind="Identity">
          <setting>
            <aCSMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets.WorkerRole/XSocketsHostUri" />
          </setting>
        </map>
        <map name="MapXSockets.WorkerRole:XSocketsOrigins" kind="Identity">
          <setting>
            <aCSMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets.WorkerRole/XSocketsOrigins" />
          </setting>
        </map>
        <map name="MapXSockets.WorkerRoleInstances" kind="Identity">
          <setting>
            <sCSPolicyIDMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets.WorkerRoleInstances" />
          </setting>
        </map>
      </maps>
      <components>
        <groupHascomponents>
          <role name="XSockets.WorkerRole" generation="1" functional="0" release="0" software="C:\Projects\XSockets.NET\Releases\XSockets.Azure.Service\XSockets.Azure.Service\XSockets.Azure.Service\csx\Debug\roles\XSockets.WorkerRole" entryPoint="base\x64\WaHostBootstrapper.exe" parameters="base\x64\WaWorkerHost.exe " memIndex="1792" hostingEnvironment="consoleroleadmin" hostingEnvironmentVersion="2">
            <componentports>
              <inPort name="XSocketsEndpoint" protocol="tcp" portRanges="10101" />
            </componentports>
            <settings>
              <aCS name="XSocketsHostUri" defaultValue="" />
              <aCS name="XSocketsOrigins" defaultValue="" />
              <aCS name="__ModelData" defaultValue="&lt;m role=&quot;XSockets.WorkerRole&quot; xmlns=&quot;urn:azure:m:v1&quot;&gt;&lt;r name=&quot;XSockets.WorkerRole&quot;&gt;&lt;e name=&quot;XSocketsEndpoint&quot; /&gt;&lt;/r&gt;&lt;/m&gt;" />
            </settings>
            <resourcereferences>
              <resourceReference name="DiagnosticStore" defaultAmount="[4096,4096,4096]" defaultSticky="true" kind="Directory" />
              <resourceReference name="EventStore" defaultAmount="[1000,1000,1000]" defaultSticky="false" kind="LogStore" />
            </resourcereferences>
          </role>
          <sCSPolicy>
            <sCSPolicyIDMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets.WorkerRoleInstances" />
            <sCSPolicyUpdateDomainMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets.WorkerRoleUpgradeDomains" />
            <sCSPolicyFaultDomainMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets.WorkerRoleFaultDomains" />
          </sCSPolicy>
        </groupHascomponents>
      </components>
      <sCSPolicy>
        <sCSPolicyUpdateDomain name="XSockets.WorkerRoleUpgradeDomains" defaultPolicy="[5,5,5]" />
        <sCSPolicyFaultDomain name="XSockets.WorkerRoleFaultDomains" defaultPolicy="[2,2,2]" />
        <sCSPolicyID name="XSockets.WorkerRoleInstances" defaultPolicy="[1,1,1]" />
      </sCSPolicy>
    </group>
  </groups>
  <implements>
    <implementation Id="462a8220-7912-4c18-9004-2b3a255c083b" ref="Microsoft.RedDog.Contract\ServiceContract\XSockets.Azure.ServiceContract@ServiceDefinition">
      <interfacereferences>
        <interfaceReference Id="908d61f0-6a7b-40f6-8b0c-4c729ca0ecc3" ref="Microsoft.RedDog.Contract\Interface\XSockets.WorkerRole:XSocketsEndpoint@ServiceDefinition">
          <inPort>
            <inPortMoniker name="/XSockets.Azure.Service/XSockets.Azure.ServiceGroup/XSockets.WorkerRole:XSocketsEndpoint" />
          </inPort>
        </interfaceReference>
      </interfacereferences>
    </implementation>
  </implements>
</serviceModel>