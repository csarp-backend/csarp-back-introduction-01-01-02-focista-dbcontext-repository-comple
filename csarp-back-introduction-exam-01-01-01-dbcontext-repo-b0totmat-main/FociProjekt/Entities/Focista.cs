namespace FociProjekt.Entities
{
    public class Focista
    {
        public Focista()
        {
            Nev = string.Empty;
            Mezszam = -1;
            Magassag = -1;
            Suly = -1;
            JobbLabas = false;
            FociKlub = null;
        }

        public Focista(string nev, int mezszam, int magassag, int suly, bool jobblabas)
        {
            Nev = nev;
            Mezszam = mezszam;
            Magassag = magassag;
            Suly = suly;
            JobbLabas = jobblabas;
            FociKlub = null;
        }

        public Focista(string nev, int mezszam, int magassag, int suly, bool jobbLavas, FociKlub fociKlub)
        {
            Nev = nev;
            Mezszam = mezszam;
            Magassag = magassag;
            Suly = suly;
            JobbLabas = jobbLavas;
            FociKlub = fociKlub;
        }

        public string Nev { get; set; }
        public int Mezszam { get; set; }
        public int Magassag { get; set; }
        public int Suly { get; set; }
        public bool JobbLabas { get; set; }
        public FociKlub? FociKlub { get; set; }
    }
}
