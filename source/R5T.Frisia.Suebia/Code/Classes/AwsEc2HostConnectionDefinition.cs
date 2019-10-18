using System;


namespace R5T.Frisia.Suebia
{
    /// <summary>
    /// Links a host URL to the name of a user authentication.
    /// </summary>
    public class AwsEc2HostConnectionDefinition
    {
        /// <summary>
        /// The URL of the host.
        /// </summary>
        public string HostURL { get; set; }
        /// <summary>
        /// The name of the user authentication to use.
        /// </summary>
        public string UserAuthenticationName { get; set; }
    }
}
