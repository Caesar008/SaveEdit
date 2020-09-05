using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace SaveEdit.Jazyk
{
    public class Strings
    {
        static Serializace s = new Serializace();
        static Ostatni jazyk; 
        private static Strings instance = new Strings();

        private Strings()
        {
            jazyk = s.Nacist(Properties.Settings.Default.jazyk);
        }

        public static string Text(string vlastnost)
        {
            if (Properties.Settings.Default.jazyk != "CZ" && Properties.Settings.Default.jazyk != "EN")
            {
                try
                {
                    PropertyInfo fi = jazyk.GetType().GetProperty(vlastnost);
                    return fi.GetValue(jazyk, null).ToString();
                }
                catch
                {
                    Type typ = typeof(SaveEdit.Jazyk.EN);
                    FieldInfo fi = typ.GetField(vlastnost);
                    return fi.GetValue(null).ToString();
                }
            }
            else if (Properties.Settings.Default.jazyk == "CZ")
            {
                Type typ = typeof(SaveEdit.Jazyk.CZ);
                FieldInfo fi = typ.GetField(vlastnost);
                return fi.GetValue(null).ToString();
            }
            else
            {
                Type typ = typeof(SaveEdit.Jazyk.EN);
                FieldInfo fi = typ.GetField(vlastnost);
                return fi.GetValue(null).ToString();
            }
        }

        public static void Reload()
        {
            instance = new Strings();
        }

        public static string Hledej
        {
            get
            {
                return Strings.Text("Hledej");
            }
        }
        public static string Seznam_itemu_neni_nacteny
        {
            get
            {
                return Strings.Text("Seznam_itemu_neni_nacteny");
            }
        }
        public static string Pridat_vlastni_item
        {
            get
            {
                return Strings.Text("Pridat_vlastni_item");
            }
        }
        public static string Otevrit
        {
            get
            {
                return Strings.Text("Otevrit");
            }
        }
        public static string Ulozit
        {
            get
            {
                return Strings.Text("Ulozit");
            }
        }
        public static string Kopirovat
        {
            get
            {
                return Strings.Text("Kopirovat");
            }
        }
        public static string Vlozit
        {
            get
            {
                return Strings.Text("Vlozit");
            }
        }
        public static string Moznosti_hry
        {
            get
            {
                return Strings.Text("Moznosti_hry");
            }
        }

        public static string Napoveda
        {
            get
            {
                return Strings.Text("Napoveda");
            }
        }
        public static string O_programu
        {
            get
            {
                return Strings.Text("O_programu");
            }
        }
        public static string Vyhledat_aktualizace
        {
            get
            {
                return Strings.Text("Vyhledat_aktualizace");
            }
        }
        public static string Changelog
        {
            get
            {
                return Strings.Text("Changelog");
            }
        }
        public static string Jazyk
        {
            get
            {
                return Strings.Text("Jazyk");
            }
        }
        public static string Aktualizovat
        {
            get
            {
                return Strings.Text("Aktualizovat");
            }
        }
        public static string Kategorie
        {
            get
            {
                return Strings.Text("Kategorie");
            }
        }
        public static string Seznam_kategorii
        {
            get
            {
                return Strings.Text("Seznam_kategorii");
            }
        }
        public static string Pocet
        {
            get
            {
                return Strings.Text("Pocet");
            }
        }
        public static string Poskozeni
        {
            get
            {
                return Strings.Text("Poskozeni");
            }
        }
        public static string Ulozeny_svet
        {
            get
            {
                return Strings.Text("Ulozeny_svet");
            }
        }
        public static string XP_level
        {
            get
            {
                return Strings.Text("XP_level");
            }
        }
        public static string Zacni_otevrenim_ulozene_pozice
        {
            get
            {
                return Text("Zacni_otevrenim_ulozene_pozice");
            }
        }
        public static string Enchanty
        {
            get
            {
                return Strings.Text("Enchanty");
            }
        }
        public static string Vlastnosti_itemu
        {
            get
            {
                return Strings.Text("Vlastnosti_itemu");
            }
        }
        public static string Probiha_nacitani_itemu
        {
            get
            {
                return Strings.Text("Probiha_nacitani_itemu");
            }
        }
        public static string Pridat_item_do_seznamu
        {
            get
            {
                return Strings.Text("Pridat_item_do_seznamu");
            }
        }
        public static string Stavebni_material
        {
            get
            {
                return Strings.Text("Stavebni_material");
            }
        }
        public static string Vse
        {
            get
            {
                return Strings.Text("Vse");
            }
        }
        public static string Dekorativni_material
        {
            get
            {
                return Strings.Text("Dekorativni_material");
            }
        }
        public static string Redstone
        {
            get
            {
                return Strings.Text("Redstone");
            }
        }
        public static string Doprava
        {
            get
            {
                return Strings.Text("Doprava");
            }
        }
        public static string Ruzne
        {
            get
            {
                return Strings.Text("Ruzne");
            }
        }
        public static string Jidlo
        {
            get
            {
                return Strings.Text("Jidlo");
            }
        }
        public static string Nastroje
        {
            get
            {
                return Strings.Text("Nastroje");
            }
        }
        public static string Zbrane
        {
            get
            {
                return Strings.Text("Zbrane");
            }
        }
        public static string Lektvary
        {
            get
            {
                return Strings.Text("Lektvary");
            }
        }
        public static string Materialy
        {
            get
            {
                return Strings.Text("Materialy");
            }
        }
        public static string Vlastni
        {
            get
            {
                return Strings.Text("Vlastni");
            }
        }
        public static string Jmeno
        {
            get
            {
                return Strings.Text("Jmeno");
            }
        }
        public static string Soubor_s_obrazkem
        {
            get
            {
                return Strings.Text("Soubor_s_obrazkem");
            }
        }
        public static string Najit
        {
            get
            {
                return Strings.Text("Najit");
            }
        }
        public static string Obrazek
        {
            get
            {
                return Strings.Text("Obrazek");
            }
        }
        public static string Bitmapa
        {
            get
            {
                return Strings.Text("Bitmapa");
            }
        }
        public static string Zleva
        {
            get
            {
                return Strings.Text("Zleva");
            }
        }
        public static string Poradi_obrazku
        {
            get
            {
                return Strings.Text("Poradi_obrazku");
            }
        }
        public static string Shora
        {
            get
            {
                return Strings.Text("Shora");
            }
        }
        public static string Stackovatelny
        {
            get
            {
                return Strings.Text("Stackovatelny");
            }
        }
        public static string Maximalni_poskozeni
        {
            get
            {
                return Strings.Text("Maximalni_poskozeni");
            }
        }
        public static string Rozmer
        {
            get
            {
                return Strings.Text("Rozmer");
            }
        }
        public static string Stavebni
        {
            get
            {
                return Strings.Text("Stavebni");
            }
        }
        public static string Dekorativni
        {
            get
            {
                return Strings.Text("Dekorativni");
            }
        }
        public static string Povinne_polozky
        {
            get
            {
                return Strings.Text("Povinne_polozky");
            }
        }
        public static string Enchant
        {
            get
            {
                return Strings.Text("Enchant");
            }
        }
        public static string Level
        {
            get
            {
                return Strings.Text("Level");
            }
        }
        public static string Pridat
        {
            get
            {
                return Strings.Text("Pridat");
            }
        }
        public static string Vypnout_limit
        {
            get
            {
                return Strings.Text("Vypnout_limit");
            }
        }
        public static string Zrusit
        {
            get
            {
                return Strings.Text("Zrusit");
            }
        }
        public static string Odeslat
        {
            get
            {
                return Strings.Text("Odeslat");
            }
        }
        public static string Dodatecne_info
        {
            get
            {
                return Strings.Text("Dodatecne_info");
            }
        }
        public static string Save_s_pouzitym
        {
            get
            {
                return Strings.Text("Save_s_pouzitym");
            }
        }
        public static string Cisty_save
        {
            get
            {
                return Strings.Text("Cisty_save");
            }
        }
        public static string Jednalo_se_o
        {
            get
            {
                return Strings.Text("Jednalo_se_o");
            }
        }
        public static string Co_jste
        {
            get
            {
                return Strings.Text("Co_jste");
            }
        }
        public static string Obsah_zpravy
        {
            get
            {
                return Strings.Text("Obsah_zpravy");
            }
        }
        public static string Pripojit_prilohu
        {
            get
            {
                return Strings.Text("Pripojit_prilohu");
            }
        }
        public static string Odeslani_informace
        {
            get
            {
                return Strings.Text("Odeslani_informace");
            }
        }
        public static string Seed_mapy
        {
            get
            {
                return Strings.Text("Seed_mapy");
            }
        }
        public static string Typ_hry
        {
            get
            {
                return Strings.Text("Typ_hry");
            }
        }
        public static string Survival
        {
            get
            {
                return Strings.Text("Survival");
            }
        }
        public static string Creative
        {
            get
            {
                return Strings.Text("Creative");
            }
        }
        public static string Adventure
        {
            get
            {
                return Strings.Text("Adventure");
            }
        }
        public static string Hardcore
        {
            get
            {
                return Strings.Text("Hardcore");
            }
        }
        public static string Povolit_prikazy
        {
            get
            {
                return Strings.Text("Povolit_prikazy");
            }
        }
        public static string Nesmrtelnost
        {
            get
            {
                return Strings.Text("Nesmrtelnost");
            }
        }
        public static string Hrac_neztrati
        {
            get
            {
                return Strings.Text("Hrac_neztrati");
            }
        }
        public static string Stridani_dne
        {
            get
            {
                return Strings.Text("Stridani_dne");
            }
        }
        public static string Denni_cas
        {
            get
            {
                return Strings.Text("Denni_cas");
            }
        }
        public static string Hodin
        {
            get
            {
                return Strings.Text("Hodin");
            }
        }
        public static string Minut
        {
            get
            {
                return Strings.Text("Minut");
            }
        }
        public static string Zivot
        {
            get
            {
                return Strings.Text("Zivot");
            }
        }
        public static string Max_zivot
        {
            get
            {
                return Strings.Text("Max_zivot");
            }
        }
        public static string Zakladni_utok
        {
            get
            {
                return Strings.Text("Zakladni_utok");
            }
        }
        public static string Odolnost
        {
            get
            {
                return Strings.Text("Odolnost");
            }
        }
        public static string Zakladni
        {
            get
            {
                return Strings.Text("Zakladni");
            }
        }
        public static string Spectator
        {
            get
            {
                return Strings.Text("Spectator");
            }
        }
        public static string Souradnice_spawnu
        {
            get
            {
                return Strings.Text("Souradnice_spawnu");
            }
        }
        public static string Uzamceni_obtiznosti
        {
            get
            {
                return Strings.Text("Uzamceni_obtiznosti");
            }
        }
        public static string Kriticka_chyba
        {
            get
            {
                return Strings.Text("Kriticka_chyba");
            }
        }
        public static string Pad
        {
            get
            {
                return Strings.Text("Pad");
            }
        }

        public static string Barva_patterny
        {
            get
            {
                return Strings.Text("Barva_patterny");
            }
        }

        public static string Jmeno_itemu
        {
            get
            {
                return Strings.Text("Jmeno_itemu");
            }
        }

        public static string Barvy
        {
            get
            {
                return Strings.Text("Barvy");
            }
        }

        public static string Pridat_barvu
        {
            get
            {
                return Strings.Text("Pridat_barvu");
            }
        }

        public static string Odebrat_barvu
        {
            get
            {
                return Strings.Text("Odebrat_barvu");
            }
        }

        public static string Prechody
        {
            get
            {
                return Strings.Text("Prechody");
            }
        }

        public static string Pridat_prechod
        {
            get
            {
                return Strings.Text("Pridat_prechod");
            }
        }

        public static string Odebrat_prechod
        {
            get
            {
                return Strings.Text("Odebrat_prechod");
            }
        }

        public static string Pridat_vybuch
        {
            get
            {
                return Strings.Text("Pridat_vybuch");
            }
        }

        public static string Odebrat_vybuch
        {
            get
            {
                return Strings.Text("Odebrat_vybuch");
            }
        }

        public static string Efekty
        {
            get
            {
                return Strings.Text("Efekty");
            }
        }

        public static string Trail
        {
            get
            {
                return Strings.Text("Trail");
            }
        }

        public static string Twinkle
        {
            get
            {
                return Strings.Text("Twinkle");
            }
        }

        public static string Rozprsknuti
        {
            get
            {
                return Strings.Text("Rozprsknuti");
            }
        }

        public static string Hlava_creepera
        {
            get
            {
                return Strings.Text("Hlava_creepera");
            }
        }

        public static string Hvezda
        {
            get
            {
                return Strings.Text("Hvezda");
            }
        }

        public static string Velka_koule
        {
            get
            {
                return Strings.Text("Velka_koule");
            }
        }

        public static string Mala_koule
        {
            get
            {
                return Strings.Text("Mala_koule");
            }
        }

        public static string Vyska_doletu
        {
            get
            {
                return Strings.Text("Vyska_doletu");
            }
        }

        public static string Vybuchy
        {
            get
            {
                return Strings.Text("Vybuchy");
            }
        }

        public static string Smazat_patternu
        {
            get
            {
                return Strings.Text("Smazat_patternu");
            }
        }

        public static string Vlnity_ram
        {
            get
            {
                return Strings.Text("Vlnity_ram");
            }
        }

        public static string Gradient_nahoru
        {
            get
            {
                return Strings.Text("Gradient_nahoru");
            }
        }

        public static string Gradient_dolu
        {
            get
            {
                return Strings.Text("Gradient_dolu");
            }
        }

        public static string Leva_dolni_pulka
        {
            get
            {
                return Strings.Text("Leva_dolni_pulka");
            }
        }

        public static string Prava_dolni_pulka
        {
            get
            {
                return Strings.Text("Prava_dolni_pulka");
            }
        }

        public static string Prava_horni_pulka
        {
            get
            {
                return Strings.Text("Prava_horni_pulka");
            }
        }

        public static string Leva_horni_pulka
        {
            get
            {
                return Strings.Text("Leva_horni_pulka");
            }
        }

        public static string Leva_pulka
        {
            get
            {
                return Strings.Text("Leva_pulka");
            }
        }

        public static string Prava_pulka
        {
            get
            {
                return Strings.Text("Prava_pulka");
            }
        }

        public static string Pravy_pruh
        {
            get
            {
                return Strings.Text("Pravy_pruh");
            }
        }

        public static string Levy_pruh
        {
            get
            {
                return Strings.Text("Levy_pruh");
            }
        }

        public static string Pruhy
        {
            get
            {
                return Strings.Text("Pruhy");
            }
        }

        public static string Dolni_pulka
        {
            get
            {
                return Strings.Text("Dolni_pulka");
            }
        }

        public static string Dolni_pruh
        {
            get
            {
                return Strings.Text("Dolni_pruh");
            }
        }

        public static string Horni_pulka
        {
            get
            {
                return Strings.Text("Horni_pulka");
            }
        }

        public static string Horni_pruh
        {
            get
            {
                return Strings.Text("Horni_pruh");
            }
        }

        public static string Kosoctverec
        {
            get
            {
                return Strings.Text("Kosoctverec");
            }
        }

        public static string Svisly_pruh
        {
            get
            {
                return Strings.Text("Svisly_pruh");
            }
        }

        public static string Vodorovny_pruh
        {
            get
            {
                return Strings.Text("Vodorovny_pruh");
            }
        }

        public static string Dolni_zuby
        {
            get
            {
                return Strings.Text("Dolni_zuby");
            }
        }

        public static string Horni_zuby
        {
            get
            {
                return Strings.Text("Horni_zuby");
            }
        }

        public static string Kriz
        {
            get
            {
                return Strings.Text("Kriz");
            }
        }

        public static string Pruh_doprava_dolu
        {
            get
            {
                return Strings.Text("Pruh_doprava_dolu");
            }
        }

        public static string Pruh_doleva_dolu
        {
            get
            {
                return Strings.Text("Pruh_doleva_dolu");
            }
        }

        public static string Trojuhelnik_dole
        {
            get
            {
                return Strings.Text("Trojuhelnik_dole");
            }
        }

        public static string Trojuhelnik_nahore
        {
            get
            {
                return Strings.Text("Trojuhelnik_nahore");
            }
        }

        public static string Ctverec_vpravo_dole
        {
            get
            {
                return Strings.Text("Ctverec_vpravo_dole");
            }
        }

        public static string Ctverec_vlevo_dole
        {
            get
            {
                return Strings.Text("Ctverec_vlevo_dole");
            }
        }

        public static string Ctverec_vlevo_nahore
        {
            get
            {
                return Strings.Text("Ctverec_vlevo_nahore");
            }
        }

        public static string Ctverec_vpravo_nahore
        {
            get
            {
                return Strings.Text("Ctverec_vpravo_nahore");
            }
        }

        public static string Kruh
        {
            get
            {
                return Strings.Text("Kruh");
            }
        }

        public static string Cihly
        {
            get
            {
                return Strings.Text("Cihly");
            }
        }

        public static string Kvetina
        {
            get
            {
                return Strings.Text("Kvetina");
            }
        }

        public static string Lebka
        {
            get
            {
                return Strings.Text("Lebka");
            }
        }

        public static string Creeper
        {
            get
            {
                return Strings.Text("Creeper");
            }
        }

        public static string Ramecek
        {
            get
            {
                return Strings.Text("Ramecek");
            }
        }

        public static string Rovny_kriz
        {
            get
            {
                return Strings.Text("Rovny_kriz");
            }
        }

        public static string Zmenit_barvu
        {
            get
            {
                return Strings.Text("Zmenit_barvu");
            }
        }

        public static string Pridat_patternu
        {
            get
            {
                return Strings.Text("Pridat_patternu");
            }
        }

        public static string Seznam_pattern
        {
            get
            {
                return Strings.Text("Seznam_pattern");
            }
        }

        public static string Nahled_banneru
        {
            get
            {
                return Strings.Text("Nahled_banneru");
            }
        }

        public static string Vyhledavam_aktualizace
        {
            get
            {
                return Strings.Text("Vyhledavam_aktualizace");
            }
        }

        public static string Vyhledavam_aktualizace_chyba
        {
            get
            {
                return Strings.Text("Vyhledavam_aktualizace_chyba");
            }
        }

        public static string Novy_program
        {
            get
            {
                return Strings.Text("Novy_program");
            }
        }

        public static string Novy_item
        {
            get
            {
                return Strings.Text("Novy_item");
            }
        }

        public static string Novy_program_item
        {
            get
            {
                return Strings.Text("Novy_program_item");
            }
        }

        public static string Novy_enchant
        {
            get
            {
                return Strings.Text("Novy_enchant");
            }
        }

        public static string Novy_program_enchant
        {
            get
            {
                return Strings.Text("Novy_program_enchant");
            }
        }

        public static string Novy_item_enchant
        {
            get
            {
                return Strings.Text("Novy_item_enchant");
            }
        }

        public static string Novy_program_item_enchant
        {
            get
            {
                return Strings.Text("Novy_program_item_enchant");
            }
        }

        public static string Novy_libnbt
        {
            get
            {
                return Strings.Text("Novy_libnbt");
            }
        }

        public static string Novy_program_libnbt
        {
            get
            {
                return Strings.Text("Novy_program_libnbt");
            }
        }

        public static string Novy_item_libnbt
        {
            get
            {
                return Strings.Text("Novy_item_libnbt");
            }
        }

        public static string Novy_program_item_libnbt
        {
            get
            {
                return Strings.Text("Novy_program_item_libnbt");
            }
        }

        public static string Novy_libnbt_enchant
        {
            get
            {
                return Strings.Text("Novy_libnbt_enchant");
            }
        }

        public static string Novy_program_libnbt_enchant
        {
            get
            {
                return Strings.Text("Novy_program_libnbt_enchant");
            }
        }

        public static string Novy_item_libnbt_enchant
        {
            get
            {
                return Strings.Text("Novy_item_libnbt_enchant");
            }
        }

        public static string Novy_program_item_libnbt_enchant
        {
            get
            {
                return Strings.Text("Novy_program_item_libnbt_enchant");
            }
        }

        public static string Vlnity_ram_d
        {
            get
            {
                return Strings.Text("Vlnity_ram_d");
            }
        }

        public static string Gradient_nahoru_d
        {
            get
            {
                return Strings.Text("Gradient_nahoru_d");
            }
        }

        public static string Gradient_dolu_d
        {
            get
            {
                return Strings.Text("Gradient_dolu_d");
            }
        }

        public static string Leva_dolni_pulka_d
        {
            get
            {
                return Strings.Text("Leva_dolni_pulka_d");
            }
        }

        public static string Prava_dolni_pulka_d
        {
            get
            {
                return Strings.Text("Prava_dolni_pulka_d");
            }
        }

        public static string Prava_horni_pulka_d
        {
            get
            {
                return Strings.Text("Prava_horni_pulka_d");
            }
        }

        public static string Leva_horni_pulka_d
        {
            get
            {
                return Strings.Text("Leva_horni_pulka_d");
            }
        }

        public static string Leva_pulka_d
        {
            get
            {
                return Strings.Text("Leva_pulka_d");
            }
        }

        public static string Prava_pulka_d
        {
            get
            {
                return Strings.Text("Prava_pulka_d");
            }
        }

        public static string Pravy_pruh_d
        {
            get
            {
                return Strings.Text("Pravy_pruh_d");
            }
        }

        public static string Levy_pruh_d
        {
            get
            {
                return Strings.Text("Levy_pruh_d");
            }
        }

        public static string Pruhy_d
        {
            get
            {
                return Strings.Text("Pruhy_d");
            }
        }

        public static string Dolni_pulka_d
        {
            get
            {
                return Strings.Text("Dolni_pulka_d");
            }
        }

        public static string Dolni_pruh_d
        {
            get
            {
                return Strings.Text("Dolni_pruh_d");
            }
        }

        public static string Horni_pulka_d
        {
            get
            {
                return Strings.Text("Horni_pulka_d");
            }
        }

        public static string Horni_pruh_d
        {
            get
            {
                return Strings.Text("Horni_pruh_d");
            }
        }

        public static string Kosoctverec_d
        {
            get
            {
                return Strings.Text("Kosoctverec_d");
            }
        }

        public static string Svisly_pruh_d
        {
            get
            {
                return Strings.Text("Svisly_pruh_d");
            }
        }

        public static string Vodorovny_pruh_d
        {
            get
            {
                return Strings.Text("Vodorovny_pruh_d");
            }
        }

        public static string Dolni_zuby_d
        {
            get
            {
                return Strings.Text("Dolni_zuby_d");
            }
        }

        public static string Horni_zuby_d
        {
            get
            {
                return Strings.Text("Horni_zuby_d");
            }
        }

        public static string Pruh_doprava_dolu_d
        {
            get
            {
                return Strings.Text("Pruh_doprava_dolu_d");
            }
        }

        public static string Pruh_doleva_dolu_d
        {
            get
            {
                return Strings.Text("Pruh_doleva_dolu_d");
            }
        }

        public static string Trojuhelnik_dole_d
        {
            get
            {
                return Strings.Text("Trojuhelnik_dole_d");
            }
        }

        public static string Trojuhelnik_nahore_d
        {
            get
            {
                return Strings.Text("Trojuhelnik_nahore_d");
            }
        }

        public static string Ctverec_vpravo_dole_d
        {
            get
            {
                return Strings.Text("Ctverec_vpravo_dole_d");
            }
        }

        public static string Ctverec_vlevo_dole_d
        {
            get
            {
                return Strings.Text("Ctverec_vlevo_dole_d");
            }
        }

        public static string Ctverec_vlevo_nahore_d
        {
            get
            {
                return Strings.Text("Ctverec_vlevo_nahore_d");
            }
        }

        public static string Ctverec_vpravo_nahore_d
        {
            get
            {
                return Strings.Text("Ctverec_vpravo_nahore_d");
            }
        }

        public static string Ramecek_d
        {
            get
            {
                return Strings.Text("Ramecek_d");
            }
        }

        public static string Rovny_kriz_d
        {
            get
            {
                return Strings.Text("Rovny_kriz_d");
            }
        }

        public static string Stahuji_program
        {
            get
            {
                return Strings.Text("Stahuji_program");
            }
        }

        public static string Chyba_stahovani_programu
        {
            get
            {
                return Strings.Text("Chyba_stahovani_programu");
            }
        }

        public static string Stahovani_itemu
        {
            get
            {
                return Strings.Text("Stahovani_itemu");
            }
        }

        public static string Chyba_stahovani_item
        {
            get
            {
                return Strings.Text("Chyba_stahovani_item");
            }
        }

        public static string Stahovani_enchantu
        {
            get
            {
                return Strings.Text("Stahovani_enchantu");
            }
        }

        public static string Chyba_stahovani_enchant
        {
            get
            {
                return Strings.Text("Chyba_stahovani_enchant");
            }
        }

        public static string Stahovani_libnbt
        {
            get
            {
                return Strings.Text("Stahovani_libnbt");
            }
        }

        public static string Chyba_stahovani_libnbt
        {
            get
            {
                return Strings.Text("Chyba_stahovani_libnbt");
            }
        }

        public static string Minecraft_neni_nainstalovan
        {
            get
            {
                return Strings.Text("Minecraft_neni_nainstalovan");
            }
        }

        public static string Chybi_soubor_itemu
        {
            get
            {
                return Strings.Text("Chybi_soubor_itemu");
            }
        }
        public static string Novy_item_otevreno
        {
            get
            {
                return Strings.Text("Novy_item_otevreno");
            }
        }

        public static string Chcete_ulozit_zmeny
        {
            get
            {
                return Strings.Text("Chcete_ulozit_zmeny");
            }
        }

        public static string Aktualizace_se_stahuje
        {
            get
            {
                return Strings.Text("Aktualizace_se_stahuje");
            }
        }

        public static string Neznamy_item
        {
            get
            {
                return Strings.Text("Neznamy_item");
            }
        }

        public static string Napoveda_nestazena
        {
            get
            {
                return Strings.Text("Napoveda_nestazena");
            }
        }

        public static string Changelog_nestazen
        {
            get
            {
                return Strings.Text("Changelog_nestazen");
            }
        }

        public static string Priprava_k_instalaci
        {
            get
            {
                return Strings.Text("Priprava_k_instalaci");
            }
        }

        public static string Aktualizace_nemohla_zacit
        {
            get
            {
                return Strings.Text("Aktualizace_nemohla_zacit");
            }
        }

        public static string Aktualizace_dokoncena
        {
            get
            {
                return Strings.Text("Aktualizace_dokoncena");
            }
        }

        public static string Soubor_nebyl_nacten
        {
            get
            {
                return Strings.Text("Soubor_nebyl_nacten");
            }
        }

        public static string Stare_itemy
        {
            get
            {
                return Strings.Text("Stare_itemy");
            }
        }

        public static string Neulozeno
        {
            get
            {
                return Strings.Text("Neulozeno");
            }
        }

        public static string Bez_mezer
        {
            get
            {
                return Strings.Text("Bez_mezer");
            }
        }

        public static string Item_nelze_vlozit
        {
            get
            {
                return Strings.Text("Item_nelze_vlozit");
            }
        }

        public static string Aktualizace_LibNBT
        {
            get
            {
                return Strings.Text("Aktualizace_LibNBT");
            }
        }

        public static string Stahuji_LibNBT
        {
            get
            {
                return Strings.Text("Stahuji_LibNBT");
            }
        }

        public static string Stahuji_LibNBT_err
        {
            get
            {
                return Strings.Text("Stahuji_LibNBT_err");
            }
        }

        public static string Stahuji_LibNBT_err2
        {
            get
            {
                return Strings.Text("Stahuji_LibNBT_err2");
            }
        }

        public static string Odesilam_info_pad
        {
            get
            {
                return Strings.Text("Odesilam_info_pad");
            }
        }

        public static string Error_error
        {
            get
            {
                return Strings.Text("Error_error");
            }
        }

        public static string SaveEdit_bezi
        {
            get
            {
                return Strings.Text("SaveEdit_bezi");
            }
        }

        public static string Sestaveni_libnbt
        {
            get
            {
                return Strings.Text("Sestaveni_libnbt");
            }
        }

        public static string Chyba_bez_LibNBT
        {
            get
            {
                return Strings.Text("Chyba_bez_LibNBT");
            }
        }

        public static string Nahlasit_chybu
        {
            get
            {
                return Strings.Text("Nahlasit_chybu");
            }
        }

        public static string Poslat_napad
        {
            get
            {
                return Strings.Text("Poslat_napad");
            }
        }

        public static string Verze
        {
            get
            {
                return Strings.Text("Verze");
            }
        }

        public static string Verze_itemu
        {
            get
            {
                return Strings.Text("Verze_itemu");
            }
        }

        public static string Licence
        {
            get
            {
                return Strings.Text("Licence");
            }
        }

        public static string Nacitam_Save
        {
            get
            {
                return Strings.Text("Nacitam_Save");
            }
        }
    }
}
