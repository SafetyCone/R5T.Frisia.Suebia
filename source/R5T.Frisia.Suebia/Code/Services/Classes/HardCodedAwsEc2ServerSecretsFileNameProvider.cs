using System;


namespace R5T.Frisia.Suebia
{
    /// <summary>
    /// Provides the hard-coded <see cref="Constants.AwsEc2ServerSecretsJSONFileName"/> value.
    /// </summary>
    public class HardCodedAwsEc2ServerSecretsFileNameProvider : IAwsEc2ServerSecretsFileNameProvider
    {
        public string GetAwsEc2ServerSecretsFileName()
        {
            var output = Constants.AwsEc2ServerSecretsJSONFileName;
            return output;
        }
    }
}
