using System;

using R5T.T0064;


namespace R5T.Frisia.Suebia
{
    /// <summary>
    /// Provides the hard-coded <see cref="Constants.AwsEc2ServerSecretsJSONFileName"/> value.
    /// </summary>
    [ServiceImplementationMarker]
    public class HardCodedAwsEc2ServerSecretsFileNameProvider : IAwsEc2ServerSecretsFileNameProvider, IServiceImplementation
    {
        public string GetAwsEc2ServerSecretsFileName()
        {
            var output = Constants.AwsEc2ServerSecretsJSONFileName;
            return output;
        }
    }
}
