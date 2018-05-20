using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using aspdota.Exceptions;
using aspdota.Models;
using Microsoft.EntityFrameworkCore;

namespace aspdota.Serializer
{
    public class Reader<T>
    {
        private static string FILESYSTEM = "/Users/mihailkopchev/Projects/asp-dota/asp-dota/XML";
        private static string EXTENSION = ".xml";
        private string currentFile = "";
        private XmlReaderSettings _settings {get;set;}
        private XmlSerializer _xmlSerializer;

        public Reader(){}

        public T Deserialize(string file){
            return this.Desirialize(new StreamReader(file));

        }
        public T Desirialize(StreamReader reader){
            try
            {
                this._xmlSerializer = new XmlSerializer(typeof(T));
                T obj = (T)this._xmlSerializer.Deserialize(reader);
                return obj;
            }
            catch (Exception e)
            {
                throw new CannotDeserializeException(e.Message, e.GetBaseException());
            }
        }
        public void Serialize(T obj,string where){
            try
            {            
				this._xmlSerializer = new XmlSerializer(typeof(T));
                StreamWriter streamWriter = new StreamWriter(where);
				this._xmlSerializer.Serialize(streamWriter,obj);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public void validateFiles(string filesystem)
        {
            string fs = filesystem != null ? filesystem : FILESYSTEM;
            
            InitSettings(ValidationType.DTD,DtdProcessing.Parse);
            InitResolver(fs);

            useEventHandler();

            try
            {
                string[] files = GetFiles(fs);

                foreach(string file in files){
                    if(IsCorrectFile(file)){
                        currentFile = file;
                        XmlReader reader = XmlReader.Create(file, _settings);
                        while(reader.Read()){
                            // if exception occur ValidationCallback is called to interrupt the process
                        }
                        Console.WriteLine("------> file : " + currentFile + " is valid");

                    }

                }

            }
            catch (Exception e)
            {
               Console.WriteLine("Problem with file: " + currentFile + " ,cause +" + e.Message);

            }
        }


        private void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Error)
                Console.WriteLine("Problem with file: " + currentFile + ", cause + " + e.Message);
        }

        private string[] GetFiles(string fs)
        {
            return Directory.Exists(fs) ? Directory.GetFiles(fs) : null;

        }
        private static bool IsCorrectFile(string file)
        {
            return file.EndsWith(EXTENSION);
        }
        public void InitSettings(ValidationType type, DtdProcessing dtdProcessing)
        {

            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = type,
                DtdProcessing = dtdProcessing,
                IgnoreWhitespace = true
            };
            _settings = settings;
        }
        public void InitResolver(string fs)
        {
            XmlUrlResolver xmlResolver = new XmlUrlResolver();
            xmlResolver.ResolveUri(null, fs);
            _settings.XmlResolver = xmlResolver;
        }
        private void useEventHandler()
        {
            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationCallBack);
            _settings.ValidationEventHandler += eventHandler;
        }


    }
}
