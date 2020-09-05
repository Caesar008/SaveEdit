using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SaveEdit.Jazyk
{

    public class Serializace
    {
        public Serializace()
        {
        }

        public void Ulozit(string soubor, Ostatni jazyk)
        {
            if (!Directory.Exists("Lang"))
                Directory.CreateDirectory("Lang");

            Stream stream = File.Open("Lang/" + soubor, FileMode.Create);
            BinaryFormatter bFormatter = new BinaryFormatter();
            bFormatter.Serialize(stream, jazyk);
            stream.Close();
        }

        public Ostatni Nacist(string soubor)
        {
            try
            {
                Ostatni jazyk;
                Stream stream = File.Open("Lang/" + soubor, FileMode.Open);
                BinaryFormatter bFormatter = new BinaryFormatter();
                jazyk = (Ostatni)bFormatter.Deserialize(stream);
                stream.Close();
                return jazyk;
            }
            catch { return null; }
        }
    }

    //udělat jako vlastnosti a dát celý

    [Serializable]
    public class Ostatni
    {
        public string VerzeJazyka { get; set; }
        public string NazevJazyka { get; set; }
        public string Autor { get; set; }

        public string Hledej { get; set; }
        public string Seznam_itemu_neni_nacteny { get; set; }
        public string Pridat_vlastni_item { get; set; }
        public string Otevrit { get; set; }
        public string Ulozit { get; set; }
        public string Kopirovat { get; set; }
        public string Vlozit { get; set; }
        public string Moznosti_hry { get; set; }
        public string Napoveda { get; set; }
        public string O_programu { get; set; }
        public string Vyhledat_aktualizace { get; set; }
        public string Changelog { get; set; }
        public string Jazyk { get; set; }
        public string Aktualizovat { get; set; }
        public string Kategorie { get; set; }
        public string Seznam_kategorii { get; set; }
        public string Pocet { get; set; }
        public string Poskozeni { get; set; }
        public string Ulozeny_svet { get; set; }
        public string XP_level { get; set; }
        public string Zacni_otevrenim_ulozene_pozice { get; set; }
        public string Enchanty { get; set; }
        public string Vlastnosti_itemu { get; set; }
        public string Probiha_nacitani_itemu { get; set; }
        public string Pridat_item_do_seznamu { get; set; }
        public string Stavebni_material { get; set; }
        public string Vse { get; set; }
        public string Dekorativni_material { get; set; }
        public string Redstone { get; set; }
        public string Doprava { get; set; }
        public string Ruzne { get; set; }
        public string Jidlo { get; set; }
        public string Nastroje { get; set; }
        public string Zbrane { get; set; }
        public string Lektvary { get; set; }
        public string Materialy { get; set; }
        public string Vlastni { get; set; }
        public string Jmeno { get; set; }
        public string Soubor_s_obrazkem { get; set; }
        public string Najit { get; set; }
        public string Obrazek { get; set; }
        public string Bitmapa { get; set; }
        public string Zleva { get; set; }
        public string Poradi_obrazku { get; set; }
        public string Shora { get; set; }
        public string Stackovatelny { get; set; }
        public string Maximalni_poskozeni { get; set; }
        public string Rozmer { get; set; }
        public string Stavebni  { get; set; }
        public string Dekorativni { get; set; }
        public string Povinne_polozky { get; set; }
        public string Enchant { get; set; }
        public string Level { get; set; }
        public string Pridat { get; set; }
        public string Vypnout_limit { get; set; }
        public string Zrusit { get; set; }
        public string Odeslat { get; set; }
        public string Dodatecne_info { get; set; }
        public string Save_s_pouzitym { get; set; }
        public string Cisty_save { get; set; }
        public string Jednalo_se_o { get; set; }
        public string Co_jste { get; set; }
        public string Obsah_zpravy { get; set; }
        public string Pripojit_prilohu { get; set; }
        public string Odeslani_informace { get; set; }
        public string Seed_mapy { get; set; }
        public string Typ_hry { get; set; }
        public string Survival { get; set; }
        public string Creative { get; set; }
        public string Adventure { get; set; }
        public string Hardcore { get; set; }
        public string Povolit_prikazy { get; set; }
        public string Nesmrtelnost { get; set; }
        public string Hrac_neztrati { get; set; }
        public string Stridani_dne { get; set; }
        public string Denni_cas { get; set; }
        public string Hodin { get; set; }
        public string Minut { get; set; }
        public string Zivot { get; set; }
        public string Max_zivot { get; set; }
        public string Zakladni_utok { get; set; }
        public string Odolnost { get; set; }
        public string Zakladni { get; set; }
        public string Spectator { get; set; }
        public string Souradnice_spawnu { get; set; }
        public string Uzamceni_obtiznosti { get; set; }
        public string Kriticka_chyba { get; set; }
        public string Pad { get; set; }
    }
}
