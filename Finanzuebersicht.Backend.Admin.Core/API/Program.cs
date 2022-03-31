using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;
using System;
using System.IO;

namespace Finanzuebersicht.Backend.Admin.Core.API
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            try
            {
                logger.Info("Server startup");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                logger.Fatal(ex, "Das Programm wurde durch einen fatalen Fehler beendet.");
                throw;
            }
            finally
            {
                logger.Info("Server shutdown");
                NLog.LogManager.Shutdown();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              })
              .ConfigureLogging(logging =>
              {
                  logging.ClearProviders();
                  logging.SetMinimumLevel(LogLevel.Trace);
              })
              .ConfigureAppConfiguration(configuration =>
              {
                  configuration.SetBasePath(Directory.GetCurrentDirectory());
                  configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                  configuration.AddEnvironmentVariables();
              })
              .UseNLog();
    }
}