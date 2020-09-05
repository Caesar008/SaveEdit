using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaveEdit
{
    class Item
    {
        public Item() { }
        public Item(int id, string stringId, string jmeno, int maxPoskozeni, string obrazek, short x, short y, bool stackovatelne, short kategorie, bool vlastni, string potion, int barva)
        {
            ID = id;
            StringID = stringId;
            Jmeno = jmeno;
            MaxPoskozeni = maxPoskozeni;
            Obrazek = obrazek;
            X = x;
            Y = y;
            Stackovatelne = stackovatelne;
            Kategorie = kategorie;
            Vlastni = vlastni;
            Potion = potion;
            Barva = barva;
        }

        public int ID
        {
            get;
            private set;
        }

        public string StringID
        {
            get;
            private set;
        }

        public string Jmeno
        {
            get;
            private set;
        }

        public int MaxPoskozeni
        {
            get;
            private set;
        }

        public string Obrazek
        {
            get;
            private set;
        }

        public short X
        {
            get;
            private set;
        }

        public short Y
        {
            get;
            private set;
        }

        public bool Stackovatelne
        {
            get;
            private set;
        }

        public short Kategorie
        {
            get;
            private set;
        }

        public bool Vlastni
        {
            get;
            private set;
        }

        public string Potion
        {
            get;
            private set;
        }

public int Barva
{
 get;
private set;
}

    }
}
