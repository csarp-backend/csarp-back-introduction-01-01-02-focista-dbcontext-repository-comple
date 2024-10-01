using FociProjekt.Context;
using FociProjekt.Entities;

namespace FociProjekt.Repos
{
    public class BajnoksagRepo<TEntity> : IRepo<TEntity>, IBajnoksagRepo where TEntity : Bajnoksag
    {
        AppDbContext _appDbContext;

        public BajnoksagRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Bajnoksag> GetOsszesBajnoksag() => _appDbContext.Bajnoksagok;

        public int GetBajnoksagokSzama() => _appDbContext.Bajnoksagok.Count;

        public void Hozzad(TEntity entity)
        {
            _appDbContext.Bajnoksagok.Add(entity);
        }

        public void Modosit(TEntity entity)
        {
            Bajnoksag? bajnoksag = _appDbContext.Bajnoksagok.Find(b => b.Nev == entity.Nev);

            if (bajnoksag is not null)
            {
                bajnoksag.ResztvevoKlubok = entity.ResztvevoKlubok;
                bajnoksag.BajnoksagKezdete = entity.BajnoksagKezdete;
            }
        }

        public void Torol(TEntity entity)
        {
            _appDbContext.Bajnoksagok.Remove(entity);
        }
    }
}
