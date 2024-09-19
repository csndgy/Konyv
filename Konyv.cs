using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyv
{
    internal class Konyv
    {
        string cim, szerzo, mufaj;
        int kiadasDatuma, oldalszam;

        public Konyv(string cim, string szerzo, string mufaj, int kiadasDatuma, int oldalszam)
        {
            this.cim = cim;
            this.szerzo = szerzo;
            this.mufaj = mufaj;
            this.kiadasDatuma = kiadasDatuma;
            this.oldalszam = oldalszam;
        }

        public string Cim { get => cim; set => cim = value; }
        public string Szerzo { get => szerzo; set => szerzo = value; }
        public string Mufaj { get => mufaj; set => mufaj = value; }
        public int KiadasDatuma { get => kiadasDatuma; set => kiadasDatuma = value; }
        public int Oldalszam { get => oldalszam; set => oldalszam = value; }

        public Konyv(string fajlNev)
        {
            string[] sor = fajlNev.Split(',');
            this.cim = sor[0];
            this.szerzo = sor[1];
            this.mufaj = sor[4];
            this.kiadasDatuma =int.Parse(sor[2]);
            this.oldalszam = int.Parse(sor[3]);


        }
    }
}
