using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BejegyzesProjekt
{
    internal class Program
    {
        static List<Bejegyzes> bejegyzesek = new List<Bejegyzes>();
        static void hozzaad()
        {
            bejegyzesek.Add(new Bejegyzes("Immanuel Kant", "Szép az, ami érdek nélkül tetszik."));
            bejegyzesek.Add(new Bejegyzes("Georg Wilhelm Friedrich Hegel", "Szavakban gondolkodunk, mert a gondolat a szónak köszönheti legmagasabb rendű és legigazibb létét."));
            
            Console.Write("Adja meg a bejegyzések számát: ");
            int bejegyzesSzam=Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < bejegyzesSzam; i++)
                {
                    Console.Write($"Adja meg a bejegyzés szerzőjét: ");
                    string szerzo = Console.ReadLine();
                    Console.Write($"Adja meg a bejegyzés tartalmát: ");
                    string tartalom = Console.ReadLine();
                    bejegyzesek.Add(new Bejegyzes(szerzo, tartalom));
                }
             }
        static void beolvas()
        {
            StreamReader sr = new StreamReader("bejegyzesek.csv");
            while (!sr.EndOfStream)
            {
                string[] adatok = sr.ReadLine().Split(';');
                string a = adatok[0];
                string b = adatok[1];
                Bejegyzes bej=new Bejegyzes(a,b);
                bejegyzesek.Add(bej);
            }
        }
        static void like()
        {
            Random rnd = new Random();
            int likeki = bejegyzesek.Count * 20;
            for (int i = 0; i < likeki; i++)
            {
                int index = rnd.Next(bejegyzesek.Count);
                bejegyzesek[index].Like();
            }
        }    
        static void masodikbejegyzesmodositasa()
        {
            Console.Write("Adja meg a második bejegyzés új tartalmát: ");
            string uj = Console.ReadLine();
            bejegyzesek[1].Tartalom = uj;
        }

        static void kiir()
        {
            foreach (Bejegyzes item in bejegyzesek)
            {
                Console.WriteLine(item);
            }
        }
        

        static void f3()
        {
            int legnepszerubb = 0;
            foreach (var item in bejegyzesek)
            {
                if (item.Likeok>legnepszerubb)
                {
                    legnepszerubb = item.Likeok;
                }
            }
            Console.WriteLine($"Legnépszerübb bejegyzés likeainak száma: {legnepszerubb}.");


            bool a = false;
            foreach (var item in bejegyzesek)
            {
                if (item.Likeok>35)
                {
                    a = true;
                }
            }
            if (a==true)
            {
                Console.WriteLine("Van olyan bejegyzés, ami 35-nél több likeot kapott.");
            }
            else
            {
                Console.WriteLine("Nincs olyan bejegyzés, ami 35-nél több likeot kapott.");
            }

            int b = 0;
            foreach (var item in bejegyzesek)
            {
                if (item.Likeok < 15)
                {
                    b++;
                }
            }
            Console.WriteLine($"{b} olyan bejegyzés van, ami 15-nél kevesebb likeot kapott");

            Console.WriteLine("------------------------------------------------------------------------------");

            var rendezett = bejegyzesek.OrderByDescending(c => c.Likeok).ToList();
            foreach (var item in rendezett)
            {
                Console.WriteLine(item);
            }
            StreamWriter sw = new StreamWriter("bejegyzesek_rendezett.txt");
            foreach (var item in rendezett)
            {
                sw.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            hozzaad();
            beolvas();
            like();
            masodikbejegyzesmodositasa();
            kiir();
            f3();
            Console.ReadLine();

        }
    }
}
