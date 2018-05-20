using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using aspdota.Models;

namespace aspdota.Models
{
    
    public class Item
    {
        public int ID { get; set; }
        public int Slot { get; set; }
        public Hero Hero { get; set; }
        public string Merchant { get; set; }
        public int Price { get; set; }
        public List<Effect> Effects { get; set; }
        public string Need { get; set; }
        public string Description { get; set; }

        public Item()
        {
        }
    }
  
}
