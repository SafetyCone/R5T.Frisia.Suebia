using System;

using R5T.Frisia.Suebia.Extensions;
using R5T.Jutland;
using R5T.Suebia;

using R5T.T0064;


namespace R5T.Frisia.Suebia
{
    /// <summary>
    /// Provides AWS EC2 server secrets from a secrets file using <see cref="R5T.Suebia.ISecretsDirectoryFilePathProvider"/>.
    /// </summary>
    [ServiceImplementationMarker]
    public class SuebiaAwsEc2ServerSecretsProvider : IAwsEc2ServerSecretsProvider, IServiceImplementation
    {
        public IAwsEc2ServerSecretsFileNameProvider AwsEc2ServerSecretsFileNameProvider { get; }
        public ISecretsDirectoryFilePathProvider SecretsDirectoryFilePathProvider { get; }
        public IJsonFileSerializationOperator JsonFileSerializationOperator { get; }
        public IAwsEc2ServerHostFriendlyNameProvider AwsEc2ServerHostFriendlyNameProvider { get; }


        public SuebiaAwsEc2ServerSecretsProvider(
            IAwsEc2ServerSecretsFileNameProvider awsEc2ServerSecretsFileNameProvider,
            ISecretsDirectoryFilePathProvider secretsFilePathProvider,
            IJsonFileSerializationOperator jsonFileSerializationOperator,
            IAwsEc2ServerHostFriendlyNameProvider awsEc2ServerHostFriendlyNameProvider)
        {
            this.AwsEc2ServerSecretsFileNameProvider = awsEc2ServerSecretsFileNameProvider;
            this.SecretsDirectoryFilePathProvider = secretsFilePathProvider;
            this.JsonFileSerializationOperator = jsonFileSerializationOperator;
            this.AwsEc2ServerHostFriendlyNameProvider = awsEc2ServerHostFriendlyNameProvider;
        }

        public AwsEc2ServerSecrets GetAwsEc2ServerSecrets()
        {
            var awsEc2ServerSecretsFileName = this.AwsEc2ServerSecretsFileNameProvider.GetAwsEc2ServerSecretsFileName();

            var awsEc2ServerSecretsFilePath = this.SecretsDirectoryFilePathProvider.GetSecretsFilePath(awsEc2ServerSecretsFileName);

            var serverSecretsSerialization = this.JsonFileSerializationOperator.Deserialize<AwsEc2ServerSecretsSerialization>(awsEc2ServerSecretsFilePath);

            var hostFriendlyName = this.AwsEc2ServerHostFriendlyNameProvider.GetHostFriendlyName();

            var serverSecrets = serverSecretsSerialization.GetAwsEc2ServerSecrets(hostFriendlyName);
            return serverSecrets;
        }
    }
}
