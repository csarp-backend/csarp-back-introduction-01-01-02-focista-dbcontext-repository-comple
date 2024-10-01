using FociProjekt.Context;
using FociProjekt.Entities;

namespace FociProjekt.Repos
{
    public class FociKlubokRepo<TEntity> : IRepo<TEntity>, IFociKlubokRepo where TEntity : FociKlub
    {
        // Kapcsolat a Context és a Repo réteg között
        private AppDbContext _appDbContext;
        public FociKlubokRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int GetFociKlubokSzama() => _appDbContext.FociKlubok.Count;
        public List<FociKlub> GetOsszesFociKlub() => _appDbContext.FociKlubok;

        public void Hozzad(TEntity entity)
        {
            _appDbContext.FociKlubok.Add(entity);
        }

        public void Modosit(TEntity entity)
        {
            FociKlub? fociKlub = _appDbContext.FociKlubok.Find(fk => fk.Nev == entity.Nev);

            if(fociKlub is not null)
            {
                fociKlub.AlapitasiIdo = entity.AlapitasiIdo;
                fociKlub.Koltsegvetes = entity.Koltsegvetes;
            }
        }
        public void Torol(TEntity entity)
        {
            _appDbContext.FociKlubok.Remove(entity);
        }
    }
}
