using FociProjekt.Context;
using FociProjekt.Entities;

namespace FociProjekt.Repos
{
    public class FocistakRepo<TEntity> : IRepo<TEntity>, IFocistakRepo where TEntity : Focista
    {
        private AppDbContext _appDbContext;
        public FocistakRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int GetFocistakSzama()
        {
            return _appDbContext.Focistak.Count;
        }

        public void Hozzad(TEntity entity)
        {
            _appDbContext.Focistak.Add(entity);   
        }

        public Focista KeresFocista(string nev)
        {
            return _appDbContext.Focistak.Find(f => f.Nev == nev) ?? new Focista();
        }

        public List<Focista> KivalasztOsszesFocistat() 
        {
            return _appDbContext.Focistak;
        }

        public void Modosit(TEntity entity)
        {
            Focista? modositandoFocista = _appDbContext.Focistak.Find(focista => focista.Nev==entity.Nev);
            if (modositandoFocista is not null)
            {
                modositandoFocista.Suly = entity.Suly;
                modositandoFocista.JobbLabas = entity.JobbLabas;
                modositandoFocista.Mezszam = entity.Mezszam;
                modositandoFocista.Magassag = entity.Magassag;
            }
        }

        public void Torol(TEntity entity)
        {
            _appDbContext.Focistak.Remove(entity);
        }
    }
}
