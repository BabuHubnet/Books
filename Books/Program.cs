using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.Threading.Tasks;

namespace Books
{
    public class Program
    {
        public async static Task Main(string[] args)
        {
            var logger = LogManager.GetCurrentClassLogger();

            //var builder1 = WebApplication.CreateBuilder(args);
            var builder = CreateHostBuilder(args);
            var app = builder.Build();
            try
            {
                using (var listener = app.RunAsync())
                {
                    logger.Info("Rest Api initialized");
                    await listener;
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex, "Error at init");
            }
            finally
            {
                LogManager.Shutdown();
            }
            //builder.Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
