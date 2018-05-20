using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using aspdota.Models;
using Microsoft.EntityFrameworkCore;

namespace aspdota.Serializer
{
    public class Reader
    {
        private DbContext DbContext { get; set; }
        private string FILESYSTEM = "/Users/mihailkopchev/Projects/asp-dota/asp-dota/XML";
        private string currentFile = "";
        private XmlReaderSettings _settings {get;set;}



        private static string[] GetFiles(string fs){
            string[] files = Directory.GetFiles(fs);
            return files;
        }
        private static bool IsValidFile(string file){
            return file.EndsWith("xml", StringComparison.Ordinal);
        }
        private void InitSettings(){

            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = ValidationType.DTD,
                DtdProcessing = DtdProcessing.Parse,
                IgnoreWhitespace = true
            };
            _settings = settings;
        }
        private void InitResolver(){
            XmlUrlResolver xmlResolver = new XmlUrlResolver();
            xmlResolver.ResolveUri(null, FILESYSTEM + "/dota.dtd");    
            _settings.XmlResolver = xmlResolver;
        }

        public void Serialize(){
            try
            {
                XmlSerializer xml = new XmlSerializer(typeof(Dota));
                StreamReader reader = new StreamReader("/Users/mihailkopchev/asp/xml_types/generated.xml");
                Dota dota = (aspdota.Models.Dota)xml.Deserialize(reader);

            }
            catch (Exception e)
            {
                Console.Write(e);
            }

        }


        public  void CheckXMlwithDTD()
        {
            InitSettings();
			InitResolver();


            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationCallBack);
            _settings.ValidationEventHandler += eventHandler;

            try
            {
                string[] files = GetFiles(FILESYSTEM);
                foreach(string file in files){
                    if(IsValidFile(file)){
                        currentFile = file;
                        XmlReader reader = XmlReader.Create(file, _settings);
                        while(reader.Read()){
                            // ok
                        }

                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }



        private  void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
                Console.WriteLine("No validation occurred." + e.Message);
            else // Error
                Console.WriteLine("Validation error: " + e.Message);
        }



    }
}
