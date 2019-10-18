using System;

using R5T.Frisia.Suebia.Extensions;


namespace R5T.Frisia.Suebia.Construction
{
    public static class Construction
    {
        public static void SubMain()
        {
            Construction.TestGetExampleAwsEc2ServerSecrets();
        }

        private static void TestGetExampleAwsEc2ServerSecrets()
        {
            var serverSecrets = Construction.GetExampleAwsEc2ServerSecrets();
        }

        private static AwsEc2ServerSecrets GetExampleAwsEc2ServerSecrets()
        {
            var serverSecretsSerialization = Construction.GetExampleAwsEc2ServerSecretsSerialization();

            var serverSecrets = serverSecretsSerialization.GetAwsEc2ServerSecrets("Temp1");
            return serverSecrets;
        }

        private static AwsEc2ServerSecretsSerialization GetExampleAwsEc2ServerSecretsSerialization()
        {
            var serialization = new AwsEc2ServerSecretsSerialization()
                .AddHostConnectionDefinition("Temp1", "www.url.com", "User1")
                .AddUserAuthentication("User1", "da-user", "da-pass", "/da/file.key")
                ;

            return serialization;
        }
    }
}
