using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using aspdota.Exceptions;
using aspdota.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace aspdota.Serializer
{
    public class Reader<T> : IReader<T>
    {
        private static string FILESYSTEM = "/Users/mihailkopchev/Projects/asp-dota/asp-dota/XML";
        private static string EXTENSION = ".xml";
        private string currentFile = "";
        private XmlReaderSettings _settings;
        private XmlSerializer _xmlSerializer; 
        private ILogger _logger;

        public Reader (){
            this._xmlSerializer = new XmlSerializer(typeof(T));
            InitSettings(ValidationType.DTD, DtdProcessing.Parse);
            UseEventHandler();

        }
        public Reader(ILogger logger){
            _logger = logger;
        }

        public T Deserialize(string file)
        {
            TextReader reader = null;
            try{
                reader = new StreamReader(file);
                return this._desirializeInternal(reader);

            }catch(Exception e){
                throw new CannotDeserializeException(e.Message, e.GetBaseException());
            }
            finally{
                if(reader != null){
                    reader.Close();
                }
            }

        }
        public T Deserialize(TextReader reader)
        {
            try
            {
                return this._desirializeInternal(reader);
            }
            catch (Exception e)
            {
                throw new CannotDeserializeException(e.Message, e.GetBaseException());
            }
        }

        public void Serialize(T obj, TextWriter streamWriter)
        {
            try{
                this._serializeInternal(obj,streamWriter);
            }
            catch (Exception e)
            {
                throw new CannotSerializeException(e.Message, e);
            }
        }

        public void Serialize(T obj,string where){
            TextWriter writer = null;
            try
            {
                writer = new StreamWriter(where);
                this._serializeInternal(obj, writer);
            }
            catch (Exception e)
            {
                throw new CannotSerializeException(e.Message, e);
            }
            finally{
                if(writer != null){
                    writer.Close();
                }
            }

        }
        private void _serializeInternal(T obj,TextWriter writer){
            this._xmlSerializer.Serialize(writer,obj);

        }

        public bool ValidateInput(String file){
            InitSettings(ValidationType.DTD, DtdProcessing.Parse);
            InitResolver(file);
            UseEventHandler();

            currentFile = file;
            try{
                XmlReader reader = XmlReader.Create(file, _settings);
                while (reader.Read())
                {
                    // if exception occur ValidationCallback is called to interrupt the process
                }
                return true;
            }
            catch(Exception e){
                Console.WriteLine(e);
                return false;
            }


        }

        public void ValidateContent(string filesystem)
        {
            string fs = filesystem ?? FILESYSTEM;
            InitSettings(ValidationType.DTD,DtdProcessing.Parse);
            InitResolver(fs);

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
            {
				Console.WriteLine("Problem with file: " + currentFile + ", cause + " + e.Message);
                throw new Exception("File not valid");
                
            }
                
        }

        private string[] GetFiles(string fs)
        {
            return Directory.Exists(fs) ? Directory.GetFiles(fs) : null;

        }
        private static bool IsCorrectFile(string file)
        {
            return file.EndsWith(EXTENSION);
        }
        private void InitSettings(ValidationType type, DtdProcessing dtdProcessing)
        {

            XmlReaderSettings settings = new XmlReaderSettings
            {
                ValidationType = type,
                DtdProcessing = dtdProcessing,
                IgnoreWhitespace = true
            };
            _settings = settings;
        }
        private void InitResolver(string fs)
        {
            XmlUrlResolver xmlResolver = new XmlUrlResolver();
            xmlResolver.ResolveUri(null, fs);
            _settings.XmlResolver = xmlResolver;
        }
        private void UseEventHandler()
        {
            ValidationEventHandler eventHandler = new ValidationEventHandler(ValidationCallBack);
            _settings.ValidationEventHandler += eventHandler;
        }
        private T _desirializeInternal(TextReader reader)
        {
            T obj = (T)this._xmlSerializer.Deserialize(reader);
            return obj;
        }

    }
}
