namespace FociProjekt.Entities
{
    public class Bajnoksag
    {
        public string Nev { get; set; }
        public List<FociKlub> ResztvevoKlubok { get; set; }
        public DateTime BajnoksagKezdete { get; set; }

        public Bajnoksag(string nev, List<FociKlub> resztvevoKlubok, DateTime nyitoDatum)
        {
            Nev = nev;
            ResztvevoKlubok = resztvevoKlubok;
            BajnoksagKezdete = nyitoDatum;
        }
    }
}
