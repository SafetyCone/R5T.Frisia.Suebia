using System;

using R5T.Suebia;


namespace R5T.Frisia.Suebia
{
    public class FrisiaAwsEc2ServerSecretsProvider : IAwsEc2ServerSecretsProvider
    {
        public IAwsEc2ServerSecretsFileNameProvider AwsEc2ServerSecretsFileNameProvider { get; }
        public ISecretsFilePathProvider SecretsFilePathProvider { get; }


        public FrisiaAwsEc2ServerSecretsProvider(IAwsEc2ServerSecretsFileNameProvider awsEc2ServerSecretsFileNameProvider, ISecretsFilePathProvider secretsFilePathProvider)
        {
            this.AwsEc2ServerSecretsFileNameProvider = awsEc2ServerSecretsFileNameProvider;
            this.SecretsFilePathProvider = secretsFilePathProvider;
        }

        public AwsEc2ServerSecrets GetAwsEc2ServerSecrets()
        {
            var awsEc2ServerSecretsFileName = this.AwsEc2ServerSecretsFileNameProvider.GetAwsEc2ServerSecretsFileName();

            var awsEc2ServerSecretsFilePath = this.SecretsFilePathProvider.GetSecretsFilePath(awsEc2ServerSecretsFileName);

            // Load 

            throw new NotImplementedException();
        }
    }
}
