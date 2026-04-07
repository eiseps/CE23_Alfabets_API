/* Uzdevums nosacījumi
Izveidot latviešu vārdu sarakstu alfabēta secībā no ievadītajiem vārdiem.

Uzdevuma apraksts
Jums jāizveido programma, kurai, ievadot vārdu,
tas tiek novietots datu struktūrā atbilstoši latviešu alfabētam.
Vietu alfabētā nosaka ievadītā vārda pirmais burts.

Ja vārda pirmais burts atkārtojas, proti, tiek ievadīts vārds,
kura vieta sarakstā jau ir aizņemta, vārdu apmaina pret ievadīto.
Pārbaudīt lietotāja ievadi, lai lietotājs nevarētu ievadīt nederīgas vērtības.
Par derīgu vērtību tiek uzskatīts tikai viens latviešu vārds, kurš sākas ar lielo burtu.
Programmai jāpaziņo, ja ievadītā vērtība neatbilst minētajiem nosacījumiem,
tad programmai jāpieprasa ievadīt jaunu vērtību. Ievadot vārdu,
ir jāizvada programmas darbības soļi, piemēram, ja vārds vēl nav ievietots,
programma izvada teikumu „Pievienoju vārdu 1. vietā”.
Ņemt vērā, ka vārdu uzskaite alfabētā sākas ar kārtas skaitļa vietu Nr. 1.

Programma darbojas, līdz tiek pilnībā aizpildīts viss alfabēta saraksts.

Lai pārbaudītu programmas darbību, varat izmantot doto vārdu sarakstu:
Ainaži, Saulkrasti, Dobele, Sigulda, Tukums, Liepāja, Talsi, Ludza, Cēsis,
Gulbene, Ventspils, Vecumnieki, Engure, Ērgļi, Staicele, Kuldīga, Aizpute,
Krāslava, Madona, Jūrmala, Rīga.

Vērtēšana
Punkts par katru no šādām programmas darbībām:

Vārda ievads

Nodrošināt vārda ievadīšanu.
Pārbaudīt lietotāja ievadīto vērtību, vai tas ir vārds
(visas citas vērtības netiek ieskaitītas kā pareizas).
Katru reizi ievadīt tikai vienu vārdu, nevis vārdu virkni.
Pārbaudīt, vai vārda pirmais burts ir lielais burts.
Atkārtoti ievadīt vērtību, ja ievadītā vērtība bijusi kļūdaina.
Datu struktūra

Izveidot datu struktūru, kurā uzglabāt latviešu alfabētu
un tam atbilstošā sākumburtapozīcijas kārtas numuru.
Izveidot datu struktūru, kurā glabāt jauno izveidoto sarakstu.
Noteikt ievadītā vārda pirmo burtu.
Ja vārda pozīcija sarakstā jau ir aizņemta ar kādu vārdu, tad to aizvietot ar ievadīto vārdu.
Ja vārda pozīcijas sarakstā vārda nav, tad tajā tiek ievietots ievadītais vārds.
Pārbaudītais vārds tiek ievietots alfabēta secības atbilstošajā pozīcijā, ņemot vērā tā pirmo burtu.
Izdrukāt katru programmas darbību kā lasāmu teikumu.
Izvadīt kļūdas paziņojumu, ja ievadītais vārds neatbilst noteikumiem.
Datu struktūrā nedrīkst būt nultais elements.
Programma darbojas, līdz viss saraksts ir aizpildīts.
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.ComponentModel;

class Program
{

    //metode, kas pārbauda vai ievadītais vārds atbilst nosacījumiem
    public static bool VardaParbaude(string vards)
    {
        Console.WriteLine($"Pārbaudu vārdu - {vards}");
        if (string.IsNullOrEmpty(vards))
        {
            Console.WriteLine("Ievadiet derīgu vārdu.");
            return false;
        }
        if (!char.IsUpper(vards[0]))
        {
            Console.WriteLine("Vārda pirmajam burtam jābūt lielajam burtam.");
            return false;
        }
        bool atstarpe = vards.Contains(" ");
        if (atstarpe)
        {             Console.WriteLine("Ievadiet tikai vienu vārdu bez atstarpēm.");
            return false;
        }
        if (!vards.All(c => char.IsLetter(c)))
        {
            Console.WriteLine("Vārds nedrīkst saturēt ciparus vai speciālos simbolus.");
            return false;
        }
        return true;
    }
    // metode saraksta izvadīšanai alfabēta secībā, kur tiek izvadīts
    // katrs vārds un tā pozīcija sarakstā
    static void IzvaditSarakstu(Dictionary<int, string> izvade) 
    {
        Console.WriteLine("Latviešu vārdu saraksts alfabēta secībā:");
        foreach (var burts in izvade)
        {
            Console.WriteLine($"{burts.Key}. {burts.Value}");
        }
    }
    static void Main(string[] args)
    {
        //vārdnīca liekas visērtākā datu struktūra
        //jo tā ļauj saglabāt datus pāros (atslēga - vērtība) un
        //viegli piekļūt vērtībām izmantojot atslēgas
        //atslēga ir skaitlis un vērtība ir vai nu burts vai sākotnēji "tukšums"
        Dictionary<int, string> alfabets = new Dictionary<int, string>()// vārdnīca ar alfabētu
        {
                {1,"A"},
                {2,"Ā"},
                {3,"B"},
                {4,"C"},
                {5,"Č"},
                {6,"D"},
                {7,"E"},
                {8,"Ē"},
                {9,"F"},
                {10,"G"},
                {11,"Ģ"},
                {12,"H"},
                {13,"I"},
                {14,"Ī"},
                {15,"J"},
                {16,"K"},
                {17,"Ķ"},
                {18,"L"},
                {19,"Ļ"},
                {20,"M"},
                {21,"N"},
                {22,"Ņ"},
                {23,"O"},
                {24,"P"},
                {25,"R"},
                {26,"S"},
                {27,"Š"},
                {28,"T"},
                {29,"U"},
                {30,"Ū"},
                {31,"V"},
                {32,"Z"},
                {33,"Ž"}

        };
        // "tukša" vārdnīca kurā tiks ievietoti vārdi atbilstoši alfabēta secībai
        Dictionary<int, string> vardi = new Dictionary<int, string>()
        {
                {1,""},
                {2,""},
                {3,""},
                {4,""},
                {5,""},
                {6,""},
                {7,""},
                {8,""},
                {9,""},
                {10,""},
                {11,""},
                {12,""},
                {13,""},
                {14,""},
                {15,""},
                {16,""},
                {17,""},
                {18,""},
                {19,""},
                {20,""},
                {21,""},
                {22,""},
                {23,""},
                {24,""},
                {25,""},
                {26,""},
                {27,""},
                {28,""},
                {29,""},
                {30,""},
                {31,""},
                {32,""},
                {33,""}

        };
        while (vardi.ContainsValue(""))// kamēr vārdnīcā ir "tukšas" pozīcijas cikls strādā
        {
            Console.WriteLine("Ievadiet vārdus:");
            string vards = Console.ReadLine();
            if (VardaParbaude(vards))// vai vārds atbils nosacījumiem.
             // Ja jā tad tiek meklēta tā pozīcija alfabētā un ievietots sarakstā
            {
                Console.WriteLine("Vārds izturējis pārbaudi");
                int pozicija = 0;
                //ejam cauri sarakstam un meklējam pozīciju kurā ievietot vārdu
                //salīdzinot tā pirmo burtu ar alfabēta burtiem
                foreach (var atslega in alfabets.Keys)
                {
                    alfabets.TryGetValue(atslega, out string burts);
                    if (burts == vards[0].ToString())
                    {
                        if (string.IsNullOrEmpty(vardi[atslega]))
                        {
                            Console.WriteLine("Pievienoju vārdu - {0} Pozīcijā: {1}", vards, atslega);
                            vardi[atslega] = vards;
                        }
                        else
                        {
                            Console.WriteLine($"Pozīcija {atslega} jau ir aizņemta ar vārdu - {vardi[atslega]} Aizvietoju to ar - {vards}");
                            vardi[atslega] = vards;
                            break;
                        }
                    }
                }
            }
        }
        Console.WriteLine("Saraksts ir pilnībā aizpildīts!");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Izvada sarakstu...");
        IzvaditSarakstu(vardi);
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Paldies par programmas izmantošanu!");

    }
}
