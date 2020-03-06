using System;
using Amazon.DynamoDBv2;
using HourDollar.BusinessLayer;
using HourDollar.BusinessLayer.Interface;
using HourDollar.DataLayer;
using HourDollar.DataLayer.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace HourDollar.Config
{
    public class Config
    {
        public Config() { }

        public static void ConfigureDependencies(IServiceCollection services)
        {
            services.AddAWSService<IAmazonDynamoDB>();
            services.AddTransient<IArtistsDataDataLayer, ArtistsDataDataLayer>();
            services.AddTransient<IArtistsDataBusinessLayer, ArtistsDataBusinessLayer>();
        }
    }
}
