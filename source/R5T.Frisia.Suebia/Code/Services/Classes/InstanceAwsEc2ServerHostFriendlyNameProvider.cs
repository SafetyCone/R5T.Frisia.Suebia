using System;


namespace R5T.Frisia.Suebia
{
    public class InstanceAwsEc2ServerHostFriendlyNameProvider : IAwsEc2ServerHostFriendlyNameProvider
    {
        public string HostFriendlyName { get; }


        public InstanceAwsEc2ServerHostFriendlyNameProvider(string hostFriendlyName)
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
