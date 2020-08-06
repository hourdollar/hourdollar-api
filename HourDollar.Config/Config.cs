using System;
using Amazon.DynamoDBv2;
using HourDollar.BusinessLayer;
using HourDollar.BusinessLayer.Interface;
using HourDollar.DataLayer;
using HourDollar.DataLayer.Interface;
using HourDollar.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HourDollar.Config
{
    public static class Config
    {
        public static void ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<DatabaseSettings>(_ => new DatabaseSettings(configuration["ConnectionStrings:DefaultConnection"]));
            services.AddTransient<IArtistsDataDataLayer, ArtistsDataDataLayer>();
            services.AddTransient<IArtistsDataBusinessLayer, ArtistsDataBusinessLayer>(); 
            services.AddTransient<IArtistImageDataLayer, ArtistImageDataLayer>();
            services.AddTransient<IArtistImageBusinessLayer, ArtistImageBusinessLayer>();
            services.AddTransient<IArtistAlbumDataLayer, ArtistAlbumDataLayer>();
            services.AddTransient<IArtistAlbumBusinessLayer, ArtistAlbumBusinessLayer>();
            services.AddTransient<IAlbumPlatformDataLayer, AlbumPlatformDataLayer>();
            services.AddTransient<IArtistPlatformDataLayer, ArtistPlatformDataLayer>();
            services.AddTransient<IArtistVideoDataLayer, ArtistVideoDataLayer>();
            services.AddTransient<IArtistVideoBusinessLayer, ArtistVideoBusinessLayer>();
        }
    }
}
