using System;

//using R5T.Frisia;


namespace R5T.Frisia.Suebia.Extensions
{
    public static class AwsEc2ServerSecretsSerializationExtensions
    {
        public static AwsEc2ServerSecretsSerialization AddHostConnectionDefinition(this AwsEc2ServerSecretsSerialization serialization,
            string friendlyName, AwsEc2HostConnectionDefinition hostConnectionDefinition)
        {
            serialization.HostConnectionsByFriendlyName.Add(friendlyName, hostConnectionDefinition);

            return serialization;
        }

        public static AwsEc2ServerSecretsSerialization AddHostConnectionDefinition(this AwsEc2ServerSecretsSerialization serialization,
            string friendlyName, string hostUrl, string userAuthenticationName)
        {
            var hostConnectionDefinition = new AwsEc2HostConnectionDefinition()
            {
                HostURL = hostUrl,
                UserAuthenticationName = userAuthenticationName,
            };

            serialization.AddHostConnectionDefinition(friendlyName, hostConnectionDefinition);

            return serialization;
        }

        public static AwsEc2ServerSecretsSerialization AddUserAuthentication(this AwsEc2ServerSecretsSerialization serialization,
            string friendlyName, AwsEc2UserAuthentication userAuthentication)
        {
            serialization.UserAuthenticationsByFriendlyName.Add(friendlyName, userAuthentication);

            return serialization;
        }

        public static AwsEc2ServerSecretsSerialization AddUserAuthentication(this AwsEc2ServerSecretsSerialization serialization,
            string friendlyName, string userID, string password, string privateKeyFilePath)
        {
            var userAuthentication = new AwsEc2UserAuthentication()
            {
                UserID = userID,
                Password = password,
                PrivateKeyFilePath = privateKeyFilePath,
            };

            serialization.AddUserAuthentication(friendlyName, userAuthentication);

            return serialization;
        }

        public static AwsEc2ServerSecrets GetAwsEc2ServerSecrets(this AwsEc2ServerSecretsSerialization serialization, string hostFriendlyName)
        {
            var hostConnectionDefinition = serialization.HostConnectionsByFriendlyName[hostFriendlyName];

            var userAuthentication = serialization.UserAuthenticationsByFriendlyName[hostConnectionDefinition.UserAuthenticationName];

            var serverSecrets = new AwsEc2ServerSecrets()
            {
                HostUrl = hostConnectionDefinition.HostURL,
                UserID = userAuthentication.UserID,
                Password = userAuthentication.Password,
                PrivateKeyFilePath = userAuthentication.PrivateKeyFilePath,
            };

            return serverSecrets;
        }
    }
}
