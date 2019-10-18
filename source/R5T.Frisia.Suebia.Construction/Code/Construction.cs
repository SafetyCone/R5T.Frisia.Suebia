using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Frisia.Suebia.Extensions;
using R5T.Jutland;


namespace R5T.Frisia.Suebia.Construction
{
    public static class Construction
    {
        public static void SubMain()
        {
            //Construction.TestGetExampleAwsEc2ServerSecrets();
            //Construction.TestSerializationOfAwsEc2ServerSecretsSerialization();
            Construction.TestDeserializationOfAwsEc2ServerSecretsSerialization();
        }

        private static void TestDeserializationOfAwsEc2ServerSecretsSerialization()
        {
            var serviceProvider = Program.GetServiceProvider();

            var jsonFileSerializationOperator = serviceProvider.GetRequiredService<IJsonFileSerializationOperator>();

            var serverSecretsSerialization = jsonFileSerializationOperator.Deserialize<AwsEc2ServerSecretsSerialization>(FilePaths.TempJsonFile1Path);

            var serverSecrets = serverSecretsSerialization.GetAwsEc2ServerSecrets(HostConnections.Temp1Name);
        }

        private static void TestSerializationOfAwsEc2ServerSecretsSerialization()
        {
            var serverSecretsSerialization = Construction.GetExampleAwsEc2ServerSecretsSerialization();

            var serviceProvider = Program.GetServiceProvider();

            var jsonFileSerializationOperator = serviceProvider.GetRequiredService<IJsonFileSerializationOperator>();

            jsonFileSerializationOperator.Serialize(FilePaths.TempJsonFile1Path, serverSecretsSerialization);
        }

        private static void TestGetExampleAwsEc2ServerSecrets()
        {
            var serverSecrets = Construction.GetExampleAwsEc2ServerSecrets();
        }

        private static AwsEc2ServerSecrets GetExampleAwsEc2ServerSecrets()
        {
            var serverSecretsSerialization = Construction.GetExampleAwsEc2ServerSecretsSerialization();

            var serverSecrets = serverSecretsSerialization.GetAwsEc2ServerSecrets(HostConnections.Temp1Name);
            return serverSecrets;
        }

        private static AwsEc2ServerSecretsSerialization GetExampleAwsEc2ServerSecretsSerialization()
        {
            var serialization = new AwsEc2ServerSecretsSerialization()
                .AddHostConnectionDefinition(HostConnections.Temp1Name, "www.url.com", Users.User1Name)
                .AddUserAuthentication(Users.User1Name, "da-user", "da-pass", "/da/file.key")
                ;

            return serialization;
        }
    }
}
