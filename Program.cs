using System;
using System.Runtime.CompilerServices;

namespace Konyv
{
    internal class Program
    {

        static List<Konyv> konyvek = new List<Konyv>();
        static void Main(string[] args)
        {
            var adat = File.ReadAllLines("konyvek.txt");
            foreach (var item in adat)
            {
                konyvek.Add(new Konyv(item));
            }
            SzerzoKereso();
            LegnagyobbOldal();
            KiadasEvSzerint();
            KonyvSzam();
            KonyvSzamOsszes();
        }


        static void SzerzoKereso()
        {
            Console.Write("Keressen ra egy szerzo nevere: ");
            string keresettSzerzo = Console.ReadLine();
            Console.WriteLine($"\nA keresett szerző által írt könyvek:");
            foreach (var item in konyvek)
            {
                var elem = item.Szerzo;
                if (keresettSzerzo == elem)
                {
                    Console.WriteLine($"-{item.Cim}");
                }
            }


        }

        static void LegnagyobbOldal()
        {
            int legtobb = 0;
            string cim = konyvek[0].Cim;

            foreach (var item in konyvek)
            {
                if (item.Oldalszam > legtobb)
                {
                    legtobb = item.Oldalszam;
                    cim = item.Cim;
                }

            }
            Console.WriteLine($"\nA könyv címe a legtöbb oldalszámmal: {cim}, oldalszám: {legtobb}\n");
        }

        static void KiadasEvSzerint()
        {
            List<Konyv> konyvRendezes = konyvek.OrderBy(x => x.KiadasDatuma).ToList();

            foreach (var konyv in konyvRendezes)
            {
                Console.WriteLine($"-{konyv.Cim}");
            }
        }

        static void KonyvSzam()
        {
            Console.Write("\nKeress ra egy mufajra: ");
            string keresettMufaj = Console.ReadLine();
            int talalt = 0;
            foreach (var item in konyvek)
            {
                var elem = item.Mufaj;
                if (keresettMufaj == elem)
                {
                    talalt++;
                }
            }
            Console.WriteLine($"\nA keresett műfajra talált könyvek száma: {talalt}");

        }

        static void KonyvSzamOsszes()
        {
            var mufajok = konyvek.GroupBy(k => k.Mufaj);

            foreach (var mufaj in mufajok)
            {
                Console.WriteLine($"\nMűfaj: {mufaj.Key}, Könyvek száma: {mufaj.Count()}");
                foreach (var konyv in mufaj)
                {
                    Console.WriteLine($"  Cím: {konyv.Cim}, Szerző: {konyv.Szerzo}, Kiadás dátuma: {konyv.KiadasDatuma}, Oldalszám: {konyv.Oldalszam}");
                }
            }
        }
    }
}