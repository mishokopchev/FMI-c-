using System;
using System.Collections.Generic;

namespace aspdota.Models
{
    public class DotaEntity
    {
        public Game Game { get; set; }
        public List<Building> Buildings { get; set; }
        public List<Hero> Heroes { get; set; }
        public List<Item> Items { get; set; }


        public DotaEntity()
        {
        }
    }
}
