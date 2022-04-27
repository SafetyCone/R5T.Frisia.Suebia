using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Jutland;
using R5T.Suebia;

using R5T.T0063;


namespace R5T.Frisia.Suebia
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HardCodedAwsEc2ServerSecretsFileNameProvider"/> implementation of <see cref="IAwsEc2ServerSecretsFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddHardCodedAwsEc2ServerSecretsFileNameProvider(this IServiceCollection services)
        {
            services.AddSingleton<IAwsEc2ServerSecretsFileNameProvider, HardCodedAwsEc2ServerSecretsFileNameProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="InstanceAwsEc2ServerHostFriendlyNameProvider"/> implementation of <see cref="IAwsEc2ServerHostFriendlyNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddInstanceAwsEc2ServerHostFriendlyNameProvider(this IServiceCollection services,
            string hostFriendlyName)
        {
            services.AddSingleton<IAwsEc2ServerHostFriendlyNameProvider, InstanceAwsEc2ServerHostFriendlyNameProvider>((serviceProvider) =>
            {
                var instanceAwsEc2ServerHostFriendlyNameProvider = new InstanceAwsEc2ServerHostFriendlyNameProvider(hostFriendlyName);
                return instanceAwsEc2ServerHostFriendlyNameProvider;
            });

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SuebiaAwsEc2ServerSecretsProvider"/> implementation of <see cref="IAwsEc2ServerSecretsProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSuebiaAwsEc2ServerSecretsProvider(this IServiceCollection services,
            IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> awsEc2ServerHostFriendlyNameProviderAction,
            IServiceAction<IAwsEc2ServerSecretsFileNameProvider> awsEc2ServerSecretsFileNameProviderAction,
            IServiceAction<ISecretsDirectoryFilePathProvider> secretsDirectoryFilePathProviderAction,
            IServiceAction<IJsonFileSerializationOperator> jsonFileSerializationOperatorAction)
        {
            services
                .Run(awsEc2ServerHostFriendlyNameProviderAction)
                .Run(awsEc2ServerSecretsFileNameProviderAction)
                .Run(secretsDirectoryFilePathProviderAction)
                .Run(jsonFileSerializationOperatorAction)
                .AddSingleton<IAwsEc2ServerSecretsProvider, SuebiaAwsEc2ServerSecretsProvider>()
                ;

            return services;
        }
    }
}
