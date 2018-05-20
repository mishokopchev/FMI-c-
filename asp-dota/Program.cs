using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using aspdota.Data;
using aspdota.Serializer;
using aspdota.XmlDto;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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

            //var host = BuildWebHost(args);
            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<DotaContext>();
            //        var dbInitiliazer = new DbInitializer(context);
            //        //TODO check the logger that is created here in the application settings
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        dbInitiliazer.Initialize();
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred while seeding the database.");
            //    }
            //}

            //host.Run();

            //checkXml();
            Reader<Dota> reader = new Reader<Dota>();
            Dota dota = dota1();
            reader.Serialize(dota,"/Users/mihailkopchev/Projects/asp-dota/asp-dota/XML/valid_xml_7.xml");


        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                   .UseStartup<Startup>().ConfigureLogging((logging) => logging.AddDebug().AddConsole().AddConsole())
                .Build();


        public static void checkXml()
        {
            Reader<Dota> reader = new Reader<Dota>();
            string fs = "/Users/mihailkopchev/Projects/asp-dota/asp-dota/XML";
            reader.validateFiles(fs);
        }




        public static Dota dota1()
        {
            Dota dota = new Dota();

            Game game = new Game
            {
                Designer = "dqwdwq",
                Name = "dwqdqw",
                Genre = "dqwdqw"
            };

            dota.Game = game;

            Building building = new Building
            {
                Type = "building",
                Side = Side.scorge,
                Main = "main",
                Region = "region",
                Life = 1,
                Defence = 123,
                Damage = 1
            };

            dota.Buildings.Add(building);
            dota.Buildings.Add(building);


            Skill skill = new Skill
            {
                Num1 = "ewq",
                Num2 = "dqwdqw",
                Num3 = "dqwdqw",
                Num4 = "dwqdqq"
            };

            AttributeHero atr = new AttributeHero
            {
                Short = Short.AGI
            };

            Hero hero = new Hero
            {
                Attack = Attack.melee,
                Affiliation = Affiliation.scorge,
                Title = "titole",
                Short = atr,
                Status = "status",
                Movespeed = 123,
                Armor = "kur",
                DPS = 123

            };
            dota.Heroes.Add(hero);
            dota.Heroes.Add(hero);

            Effect eff = new Effect
            {
                Main = "dobre",
                Secondary = "qko da"
            };

            List<Effect> effects = new List<Effect>();
            effects.Add(eff);
            effects.Add(eff);

            Item item = new Item
            {
                HeroName = "kur",
                Merchant = "qk",
                Price = 123,
                Need = "tes",
                Description = "da",
                Effects = effects
            };

            dota.Items.Add(item);
            dota.Items.Add(item);

            return dota;

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
      




