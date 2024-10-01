namespace FociProjekt.Entities
{
    public class Edzo
    {
        public string Nev { get; set; } = string.Empty;
        public int Fizetes { get; set; }
        public FociKlub? FociKlub { get; set; }

        public Edzo(string nev, int fizetes, FociKlub? fociKlub)
        {
            Nev = nev;
            Fizetes = fizetes;
            fociKlub = FociKlub;
        }
    }
}
