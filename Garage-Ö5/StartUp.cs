using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Garage_Ö5
{
    internal class StartUp
    {

        internal void SetUp()
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();
            //serviceProvider.GetService<Setup>().Run();
           // var setup = new Setup();
            serviceProvider.GetRequiredService<Setup>().Run();
          //  setup.Run();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            IConfiguration config = GetConfig();

            services.AddSingleton(config);
            services.AddSingleton<Setup>();
            services.Configure<GarageSetting>(config.GetSection("garageapp:garagesetting").Bind);
        }

        private IConfiguration GetConfig()
        {
            return new ConfigurationBuilder()
             .SetBasePath(Environment.CurrentDirectory)
             .AddJsonFile("appsetting.json", optional: false, reloadOnChange: true)
             .Build();

        }
    }
}