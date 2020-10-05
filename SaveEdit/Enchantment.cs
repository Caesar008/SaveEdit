using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaveEdit
{
    class Enchantment
    {
        public Enchantment(string name, string id, short level)
        {
            Name = name;
            ID = id;
            MaxLevel = level;
            Itemy = new List<string>();
        }

        public void Add(string itemID)
        {
            Itemy.Add(itemID);
        }

        public string Name { get; private set; }
        public string ID { get; private set; }
        public short MaxLevel { get; private set; }
        public List<string> Itemy { get; private set; }
    }
}
