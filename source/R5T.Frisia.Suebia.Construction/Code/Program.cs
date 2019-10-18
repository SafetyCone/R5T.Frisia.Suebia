using System;

using Microsoft.Extensions.DependencyInjection;

using R5T.Jutland;
using R5T.Jutland.Newtonsoft;


namespace R5T.Frisia.Suebia.Construction
{
    class Program
    {
        static void Main(string[] args)
        {
            Construction.SubMain();
        }

        public static ServiceProvider GetServiceProvider()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IJsonFileSerializationOperator, NewtonsoftJsonFileSerializationOperator>()
                .BuildServiceProvider()
                ;

            return serviceProvider;
        }
    }
}
