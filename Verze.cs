using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SaveEdit
{
    public class Serializace
    {
        public Serializace()
        {
        }

        public void Ulozit(string soubor, Verze verze)
        {
            Stream stream = File.Open(soubor, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, verze);
            stream.Close();
        }

        public Verze Nacist(string soubor)
        {
            try
            {
                Verze verze;
                Stream stream = File.Open(soubor, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                verze = (Verze)bFormatter.Deserialize(stream);
                stream.Close();
                return verze;
            }
            catch { return null; }
        }
    }

    [Serializable]
    public class Verze
    {
        Dictionary<string, int> seznam = new Dictionary<string, int>();
        public Verze(int verze, string objekt)
        {
            seznam.Add(objekt, verze);
            GetObjekty = seznam;
        }

        public Dictionary<string, int> GetObjekty
        {
            get;
            set;
        }
    }
}
