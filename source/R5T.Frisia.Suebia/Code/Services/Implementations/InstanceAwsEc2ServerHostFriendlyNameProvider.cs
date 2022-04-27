using System;

using R5T.T0064;


namespace R5T.Frisia.Suebia
{
    [ServiceImplementationMarker]
    public class InstanceAwsEc2ServerHostFriendlyNameProvider : IAwsEc2ServerHostFriendlyNameProvider, IServiceImplementation
    {
        public string HostFriendlyName { get; }


        public InstanceAwsEc2ServerHostFriendlyNameProvider(
            [NotServiceComponent] string hostFriendlyName)
        {
            this.HostFriendlyName = hostFriendlyName;
        }

        public string GetHostFriendlyName()
        {
            var hostFriendlyName = this.HostFriendlyName;
            return hostFriendlyName;
        }
    }
}
