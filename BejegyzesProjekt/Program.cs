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
        static void f2()
        {
            List<Bejegyzes> bejegyzesek = new List<Bejegyzes>();
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
            
            string[] sorok = File.ReadAllLines("bejegyzesek.csv");
            foreach (string i in sorok)
            {
                string[] reszek = i.Split(';');
                    string szerzo = reszek[0];
                    string tartalom = reszek[1];
                    bejegyzesek.Add(new Bejegyzes(szerzo, tartalom));
            }
            
            Random rnd = new Random();
            int likeki = bejegyzesek.Count * 20;
            for (int i = 0; i < likeki; i++)
            {
                int index = rnd.Next(bejegyzesek.Count);
                bejegyzesek[index].Like();
            }

            Console.Write("Adja meg a második bejegyzés új tartalmát: ");
            string uj = Console.ReadLine();
            bejegyzesek[1].Tartalom = uj;

            foreach (Bejegyzes item in bejegyzesek)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            f2();
            Console.ReadLine();

        }
    }
}
