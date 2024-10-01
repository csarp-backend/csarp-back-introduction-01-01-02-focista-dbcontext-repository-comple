namespace FociProjekt.Entities
{
    public class Focista
    {
        public string Nev { get; set; }
        public int Mezszam { get; set; }
        public int Magassag { get; set; }
        public int Suly { get; set; }
        public bool JobbLabas { get; set; }
        public FociKlub FociKlub { get; set; }

        public Focista(string nev,
            int mezszam, int magassag, int suly,
            bool jobbLabas, FociKlub fociKlub)
        {
            Nev = nev;
            Mezszam = mezszam;
            Magassag = magassag;
            Suly = suly;
            JobbLabas = jobbLabas;
            FociKlub = fociKlub;
        }
    }
}
