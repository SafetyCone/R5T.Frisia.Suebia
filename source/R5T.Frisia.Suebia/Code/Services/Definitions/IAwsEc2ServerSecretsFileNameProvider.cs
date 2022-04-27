using System;

using R5T.T0064;


namespace R5T.Frisia.Suebia
{
    [ServiceDefinitionMarker]
    public interface IAwsEc2ServerSecretsFileNameProvider : IServiceDefinition
    {
        string GetAwsEc2ServerSecretsFileName();
    }
}
