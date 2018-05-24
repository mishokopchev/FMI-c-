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
            //Reader reader = new Reader();
            //reader.CheckXMlwithDTD();
            //reader.Serialize();


            //Serialization();

            var host = BuildWebHost(args);
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<DotaContext>();
                    var dbInitiliazer = new DbInitializer(context);
                    dbInitiliazer.Initialize();
                    _adapt(context);

                    //TODO check the logger that is created here in the application settings
                    var logger = services.GetRequiredService<ILogger<Program>>();

                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            //host.Run();
            //checkXml();

            //Reader<Dota> reader = new Reader<Dota>();

            //  Dota dota = dota1();
            //reader.Serialize(dota,"/Users/mihailkopchev/Projects/asp-dota/asp-dota/XML/valid_xml_7.xml");
            //Dota deDota = reader.Deserialize("/Users/mihailkopchev/Projects/asp-dota/asp-dota/XML/valid_xml_7.xml");
            //Console.WriteLine(deDota);

            // tova se serializira pravilno no trqbva da se sazdata pravilno obektite i vrazkite my tqh 
            // za da mine test parvo trqbva da da ima tag za dotata

            //_adapt();


        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>().ConfigureLogging((logging) => logging.AddDebug().AddConsole().AddConsole())
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







        //serialializeItem();

        /*
    }
    public static void DesirealizeDota(){
        try{
            XmlSerializer xml = new XmlSerializer(typeof(Dota));
            StreamReader reader = new StreamReader("/Users/mihailkopchev/asp/xml_types/generated.xml");
            Dota dota = (aspdota.Models.Dota)xml.Deserialize(reader);

        }catch(Exception e){
            Console.Write(e);
        }
    }
    public static void DesilializeHero(){
        try{
            XmlSerializer heroSerializer = new XmlSerializer(typeof(Hero));
            StreamReader reader = new StreamReader("/Users/mihailkopchev/asp/xml_types/test1.xml");
            Hero hero = (aspdota.Models.Hero)heroSerializer.Deserialize(reader);
            Console.WriteLine(hero.ToString());

         }
        catch(Exception e ){
            Console.WriteLine(e);
        }

    }
    public static void serialializeItem(){
        try{


        DbInitializer db = new DbInitializer();
        XmlSerializer itemS = new XmlSerializer(typeof(Item));
        TextWriter FileStream = new StreamWriter("/Users/mihailkopchev/asp/xml_types/test.xml");

        List<Effect> effects = new List<Effect>();
        Skill skill = new Skill
        {
            Num1 = "ewq",
            Num2 = "dqwdqw",
            Num3 = "dqwdqw",
            Num4 = "dwqdqq"
        };

        Hero hero = db.CreateHero(skill);
        Item item = db.CreateItem(effects, hero);
        Console.WriteLine(hero.ToString());

        itemS.Serialize(FileStream,item);
        }
        catch(Exception e){
            Console.WriteLine(e);
        }
    }







*/

    }


}
      




