using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Jutland;
using R5T.Suebia;

using R5T.T0062;
using R5T.T0063;



namespace R5T.Frisia.Suebia
{
    public static class IServiceActionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HardCodedAwsEc2ServerSecretsFileNameProvider"/> implementation of <see cref="IAwsEc2ServerSecretsFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IAwsEc2ServerSecretsFileNameProvider> AddHardCodedAwsEc2ServerSecretsFileNameProviderAction(this IServiceAction _)
        {
            var serviceAction = _.New<IAwsEc2ServerSecretsFileNameProvider>(services => services.AddHardCodedAwsEc2ServerSecretsFileNameProvider());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="InstanceAwsEc2ServerHostFriendlyNameProvider"/> implementation of <see cref="IAwsEc2ServerHostFriendlyNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> AddInstanceAwsEc2ServerHostFriendlyNameProviderAction(this IServiceAction _,
            string hostFriendlyName)
        {
            var serviceAction = _.New<IAwsEc2ServerHostFriendlyNameProvider>(services => services.AddInstanceAwsEc2ServerHostFriendlyNameProvider(
                hostFriendlyName));

            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="SuebiaAwsEc2ServerSecretsProvider"/> implementation of <see cref="IAwsEc2ServerSecretsProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IAwsEc2ServerSecretsProvider> AddSuebiaAwsEc2ServerSecretsProviderAction(this IServiceAction _,
            IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> awsEc2ServerHostFriendlyNameProviderAction,
            IServiceAction<IAwsEc2ServerSecretsFileNameProvider> awsEc2ServerSecretsFileNameProviderAction,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction,
            IServiceAction<IJsonFileSerializationOperator> jsonFileSerializationOperatorAction)
        {
            var serviceAction = _.New<IAwsEc2ServerSecretsProvider>(services => services.AddSuebiaAwsEc2ServerSecretsProvider(
                awsEc2ServerHostFriendlyNameProviderAction,
                awsEc2ServerSecretsFileNameProviderAction,
                secretsDirectoryFilePathProviderAction,
                jsonFileSerializationOperatorAction));

            return serviceAction;
        }
    }
}
