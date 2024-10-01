using FociProjekt.Entities;

namespace FociProjekt.Context
{
    // AppDbContext az adattáblák tárolására
    public class AppDbContext
    {
        private List<Focista> _focistak;
        private List<FociKlub> _fociKlubok;
        private List<Edzo> _edzok;
        private List<Bajnoksag> _bajnoksagok;

        public AppDbContext()
        {
            _focistak = new List<Focista>();
            _fociKlubok = new List<FociKlub>();
            _edzok = new List<Edzo>();
            _bajnoksagok = new List<Bajnoksag>();
        }

        public List<Focista> Focistak => _focistak; // get
        public List<FociKlub> FociKlubok => _fociKlubok;
        public List<Edzo> Edzok => _edzok;
        public List<Bajnoksag> Bajnoksagok => _bajnoksagok;
    }
}
