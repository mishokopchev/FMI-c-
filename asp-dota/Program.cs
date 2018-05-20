using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using aspdota.Data;
using aspdota.Models;
using aspdota.Serializer;
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
            Reader reader = new Reader();
            //reader.CheckXMlwithDTD();
            //reader.Serialize();

            DesirealizeDota();

            //Serialization();

            //var host = BuildWebHost(args);
            //var dbInitiliazer = new DbInitializer();

            //using (var scope = host.Services.CreateScope())
            //{
            //    var services = scope.ServiceProvider;
            //    try
            //    {
            //        var context = services.GetRequiredService<DotaContext>();
            //        dbInitiliazer.Initialize(context);
            //    }
            //    catch (Exception ex)
            //    {
            //        var logger = services.GetRequiredService<ILogger<Program>>();
            //        logger.LogError(ex, "An error occurred while seeding the database.");
            //    }
            //}

            //host.Run();


        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();


        public static void Serialization(){

            //Dota Dota = new Dota();
            //TextWriter FileStream = new StreamWriter("test.xml");
            //XmlSerializer XmlSerializer = new XmlSerializer(typeof(Dota));
            //XmlSerializer.Serialize(FileStream,Dota);

            //XmlSerializer dotaSerializer = new XmlSerializer(typeof(Dota));
            //TextReader textReader = new StreamReader("/Users/mihailkopchev/asp/xml_types/valid_xml_1.xml");
            //Dota dota  = (aspdota.Models.Dota)dotaSerializer.Deserialize(textReader);
            //Console.WriteLine(dota);
            try{
                
            
            Game game = new Game
            {
                Designer = "dqwdwq",
                Name = "dwqdqw",
                Genre = "dqwdqw"

            };

            var db = new DbInitializer();
            Building building = db.CreateBulding();

            Dota dota = new Dota();
            dota.Buildings = new List<Building>();
            dota.Buildings.Add(building);
            dota.Buildings.Add(building);
            dota.Game = game;

            Skill skill = new Skill
            {
                Num1 = "ewq",
                Num2 = "dqwdqw",
                Num3 = "dqwdqw",
                Num4 = "dwqdqq"
            };
            Hero hero = db.CreateHero(skill);
            dota.Heroes = new List<Hero>();
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
            dota.Items = new List<Item>();
            
                Item item = db.CreateItem(effects, hero);
            dota.Items.Add(item);
            dota.Items.Add(item);

                TextWriter FileStream = new StreamWriter("/Users/mihailkopchev/Projects/asp-dota/asp-dota/XML/generated.xml");
            XmlSerializer XmlSerializer = new XmlSerializer(typeof(Dota));
            XmlSerializer.Serialize(FileStream,dota);
            }
            catch(Exception e){
                Console.WriteLine(e);
            }

            //serialializeItem();
            

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









        }

        

      
        
    }



