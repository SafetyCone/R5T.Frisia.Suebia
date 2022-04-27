using System;

using R5T.T0064;


namespace R5T.Frisia.Suebia
{
    [ServiceDefinitionMarker]
    public interface IAwsEc2ServerHostFriendlyNameProvider : IServiceDefinition
    {
        string GetHostFriendlyName();
    }
}
