using System;
using System.Collections.Generic;


namespace R5T.Frisia.Suebia
{
    /// <summary>
    /// A serialization type for AWS EC2 server secrets.
    /// </summary>
    public class AwsEc2ServerSecretsSerialization
    {
        public Dictionary<string, AwsEc2HostConnectionDefinition> HostConnectionsByFriendlyName { get; } = new Dictionary<string, AwsEc2HostConnectionDefinition>();
        public Dictionary<string, AwsEc2UserAuthentication> UserAuthenticationsByFriendlyName { get; } = new Dictionary<string, AwsEc2UserAuthentication>();
    }
}
