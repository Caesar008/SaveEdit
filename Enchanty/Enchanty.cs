using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace SaveEdit
{
    public class Enchant
    {
        public Enchant(short id, string jmeno, int maxLevel, List<int> idItemu)
        {
            PovoleneItemy = new List<int>();
            ID = id;
            Jmeno = jmeno;
            MaxLevel = maxLevel;
            foreach (int i in idItemu)
            {
                PovoleneItemy.Add(i);
            }
        }

        public short ID
        {
            get;
            private set;
        }

        public string Jmeno
        {
            get;
            private set;
        }

        public int MaxLevel
        {
            get;
            private set;
        }

        public List<int> PovoleneItemy
        {
            get;
            private set;
        }
    }
    static class Enchanty
    {
        public static Enchant GetEnchant(int id, List<Enchant> listEnchantu)
        {
            foreach (Enchant e in listEnchantu)
                if (e.ID == id)
                    return e;
            //throw new ArgumentException("Neexistující id enchantu.");
            return new Enchant((short)id, "Neznámý enchant (id " + id + ")", 5, new List<int>());
        }

        public static List<int> GetEnabledItem(int id, List<Enchant> listEnchantu)
        {
            foreach (Enchant e in listEnchantu)
                if (e.ID == id)
                    return e.PovoleneItemy;
            throw new ArgumentException("Neexistující id enchantu.");
        }

        public static List<int> GetEnabledItems(string jmenoEnchantu, List<Enchant> listEnchantu)
        {
            foreach (Enchant e in listEnchantu)
                if (e.Jmeno == jmenoEnchantu)
                    return e.PovoleneItemy;
            throw new ArgumentException("Neexistující enchant.");
        }

        public static short GetId(string jmenoEnchantu, List<Enchant> listEnchantu)
        {
            foreach (Enchant e in listEnchantu)
                if (e.Jmeno == jmenoEnchantu)
                    return e.ID;
            return -1;
        }

        public static int Verze
        {
            get;
            internal set;
        }

        public static List<Enchant> Load()
        {
            List<Enchant> ench = new List<Enchant>();
            try
            {
                XmlDocument enchanty = new XmlDocument();
                enchanty.Load(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\Enchanty.xml");
                Verze = int.Parse(enchanty.SelectSingleNode("Enchanty/Verze").InnerText);

                XmlNodeList enchantyHra = enchanty.SelectNodes("Enchanty/Hra/Enchant");
                foreach (XmlNode en in enchantyHra)
                {
                    List<int> id = new List<int>();
                    XmlNodeList pi = en.SelectNodes("PovoleneItemy/ID");
                    foreach (XmlNode povol in pi)
                    {
                        id.Add(int.Parse(povol.InnerText));
                    }
                    ench.Add(new Enchant(short.Parse(en.SelectSingleNode("ID").InnerText), en.SelectSingleNode("Jmeno").InnerText, int.Parse(en.SelectSingleNode("MaxLevel").InnerText), id));
                }
                
                return ench;
            }
            catch
            {
                MessageBox.Show("Chybí soubor s Enchanty, nebo je poškozen. Prosím, aktualizujte!");
                Verze = -1;
                return null;
            }
        }
    }
}
