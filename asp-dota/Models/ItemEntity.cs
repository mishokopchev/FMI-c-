using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using aspdota.Models;

namespace aspdota.Models
{
    
    public class ItemEntity
    {
        public int ID { get; set; }
        public int Slot { get; set; }
        public HeroEntity Hero { get; set; }
        public string Merchant { get; set; }
        public int Price { get; set; }
        public List<EffectEntity> Effects { get; set; }
        public string Need { get; set; }
        public string Description { get; set; }

        public void AddEffect(EffectEntity eff){
            if(eff != null){
                Effects.Add(eff);
            }
        }

        public ItemEntity()
        {
        }
    }
  
}
