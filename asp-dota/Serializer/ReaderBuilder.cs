using System;
using System.Xml;
using System.Xml.Schema;

namespace aspdota.Serializer
{
    public class ReaderBuilder
    {
        public Reader Reader;

        public ReaderBuilder()
        {
        }

        public ReaderBuilder AddSettings(Settings settings){
            this.Reader.Settings = settings;
            return this;
        }
        public ReaderBuilder AddValidationCallback(ValidationEventHandler eventHandler){
            return this;
            
        }


        public Reader Build(){
            return Reader;
        }
    }
}
