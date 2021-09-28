using ChannelEngineAssessmentLogic.Configuration;
using ChannelEngineAssessmentLogic.Interfaces;
using ChannelEngineAssessmentLogic.Repositories;
using ChannelEngineAssessmentLogic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ChannelEngineAssessmentConsole
{
    class Program
    {
        public static void Main(string[] args)
        {
            var config = BuildConfiguration();
            var serviceProvider = ConfigureServices(config);
            var app = serviceProvider.GetRequiredService<Application>();
            app.Execute();
        }

        public static IServiceProvider ConfigureServices(IConfiguration config)
        {
            return new ServiceCollection()
                .Configure<ChannelEngineConfig>(config.GetSection(
                                        ChannelEngineConfig.SettingsName))
                .AddScoped<IChannelEngineClient, ChannelEngineClient>()
                .AddScoped<IChannelEngineRepository, ChannelEngineRepository>()
                .AddScoped<IOrderService, OrderService>()
                .AddScoped<IProductService, ProductService>()
                .AddSingleton<Application>()
                .BuildServiceProvider();
        }

        public static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }
    }
}
