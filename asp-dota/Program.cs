using System;
using System.Collections.Generic;
using System.IO;
using aspdota.Adapter;
using aspdota.Commons;
using aspdota.Data;
using aspdota.Models;
using aspdota.Repository;
using aspdota.Serializer;
using aspdota.XmlDto;
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
        

        public static void _adapt(DotaContext context){
            try{
                
 
            string filesystem = "/Users/mihailkopchev/Projects/asp-dota/asp-dota/XML/valid_xml_11.xml";
            IReader<Dota> reader = new Reader<Dota>();
            Dota dota = reader.Deserialize(filesystem);
            DotaDtoToDotaEntityAdapter adapter = new DotaDtoToDotaEntityAdapter();

            DotaEntity entity = adapter.Adapt(dota);
            Console.WriteLine(entity);

            DotaRepository dotaRepository = new DotaRepository(context);
            dotaRepository.Persist(entity);

            }
            catch(Exception e){
                Console.WriteLine(e);
            }

        }

    }


}
      




