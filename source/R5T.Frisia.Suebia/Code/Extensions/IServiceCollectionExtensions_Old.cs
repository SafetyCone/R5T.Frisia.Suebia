using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Dacia;
using R5T.Jutland;
using R5T.Suebia;


namespace R5T.Frisia.Suebia
{
    public static partial class IServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <see cref="HardCodedAwsEc2ServerSecretsFileNameProvider"/> implementation of <see cref="IAwsEc2ServerSecretsFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddHardCodedAwsEc2ServerSecretsFileNameProvider_Old(this IServiceCollection services)
        {
            services.AddSingleton<IAwsEc2ServerSecretsFileNameProvider, HardCodedAwsEc2ServerSecretsFileNameProvider>();

            return services;
        }

        /// <summary>
        /// Adds the <see cref="HardCodedAwsEc2ServerSecretsFileNameProvider"/> implementation of <see cref="IAwsEc2ServerSecretsFileNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IAwsEc2ServerSecretsFileNameProvider> AddHardCodedAwsEc2ServerSecretsFileNameProviderAction_Old(this IServiceCollection services)
        {
            var serviceAction = new ServiceAction<IAwsEc2ServerSecretsFileNameProvider>(() => services.AddHardCodedAwsEc2ServerSecretsFileNameProvider_Old());
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="InstanceAwsEc2ServerHostFriendlyNameProvider"/> implementation of <see cref="IAwsEc2ServerHostFriendlyNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddInstanceAwsEc2ServerHostFriendlyNameProvider_Old(this IServiceCollection services, string hostFriendlyName)
        {
            services.AddSingleton<IAwsEc2ServerHostFriendlyNameProvider, InstanceAwsEc2ServerHostFriendlyNameProvider>((serviceProvider) =>
            {
                var instanceAwsEc2ServerHostFriendlyNameProvider = new InstanceAwsEc2ServerHostFriendlyNameProvider(hostFriendlyName);
                return instanceAwsEc2ServerHostFriendlyNameProvider;
            });

            return services;
        }

        /// <summary>
        /// Adds the <see cref="InstanceAwsEc2ServerHostFriendlyNameProvider"/> implementation of <see cref="IAwsEc2ServerHostFriendlyNameProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> AddInstanceAwsEc2ServerHostFriendlyNameProviderAction_Old(this IServiceCollection services, string hostFriendlyName)
        {
            var serviceAction = new ServiceAction<IAwsEc2ServerHostFriendlyNameProvider>(() => services.AddInstanceAwsEc2ServerHostFriendlyNameProvider_Old(hostFriendlyName));
            return serviceAction;
        }

        /// <summary>
        /// Adds the <see cref="SuebiaAwsEc2ServerSecretsProvider"/> implementation of <see cref="IAwsEc2ServerSecretsProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceCollection AddSuebiaAwsEc2ServerSecretsProvider_Old(this IServiceCollection services,
            IServiceAction<IAwsEc2ServerSecretsFileNameProvider> addAwsEc2ServerSecretsFileNameProvider,
            IServiceAction<ISecretsDirectoryFilePathProvider> addSecretsDirectoryFilePathProvider,
            IServiceAction<IJsonFileSerializationOperator> addJsonFileSerializationOperator,
            IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            services
                .AddSingleton<IAwsEc2ServerSecretsProvider, SuebiaAwsEc2ServerSecretsProvider>()
                .RunServiceAction(addAwsEc2ServerSecretsFileNameProvider)
                .RunServiceAction(addSecretsDirectoryFilePathProvider)
                .RunServiceAction(addJsonFileSerializationOperator)
                .RunServiceAction(addAwsEc2ServerHostFriendlyNameProvider)
                ;

            return services;
        }

        /// <summary>
        /// Adds the <see cref="SuebiaAwsEc2ServerSecretsProvider"/> implementation of <see cref="IAwsEc2ServerSecretsProvider"/> as a <see cref="ServiceLifetime.Singleton"/>.
        /// </summary>
        public static IServiceAction<IAwsEc2ServerSecretsProvider> AddSuebiaAwsEc2ServerSecretsProviderAction_Old(this IServiceCollection services,
            IServiceAction<IAwsEc2ServerSecretsFileNameProvider> addAwsEc2ServerSecretsFileNameProvider,
            IServiceAction<ISecretsDirectoryFilePathProvider> addSecretsDirectoryFilePathProvider,
            IServiceAction<IJsonFileSerializationOperator> addJsonFileSerializationOperator,
            IServiceAction<IAwsEc2ServerHostFriendlyNameProvider> addAwsEc2ServerHostFriendlyNameProvider)
        {
            var serviceAction = new ServiceAction<IAwsEc2ServerSecretsProvider>(() => services.AddSuebiaAwsEc2ServerSecretsProvider_Old(
                addAwsEc2ServerSecretsFileNameProvider,
                addSecretsDirectoryFilePathProvider,
                addJsonFileSerializationOperator,
                addAwsEc2ServerHostFriendlyNameProvider));
            return serviceAction;
        }
    }
}
