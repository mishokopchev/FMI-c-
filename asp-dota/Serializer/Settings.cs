using System;
using System.Xml;
using System.Xml.Schema;

namespace aspdota.Serializer
{
    public class Settings
    {
        public XmlReaderSettings _settings { get; set; }

        public Settings(XmlReaderSettings settings) => this._settings = settings;

        public Settings(){}

        public void AddResolver(XmlResolver xmlResolver) => this._settings.XmlResolver = xmlResolver;

        public XmlReaderSettings GetSettings() => _settings;

        public void SetSettings(XmlReaderSettings value) => _settings = value;


        public static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
                Console.WriteLine("Warning: Matching schema not found.  No validation occurred." + e.Message);
            else // Error
                Console.WriteLine("Validation error: " + e.Message);
        }
        public void AddValidationCallback(){
            this._settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
        }

    }
}
