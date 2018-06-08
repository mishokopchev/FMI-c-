using System;
using aspdota.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace asp_dota
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DotaContext>();
                    var dbInitiliazer = new DbInitializer(context);
                    dbInitiliazer.Initialize();
                    //TODO check the logger that is created here in the application settings
                    var logger = services.GetRequiredService<ILogger<Program>>();

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();


        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>()
                .Build();

    }

}






