using FociProjekt.Context;
using FociProjekt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FociProjekt.Repos
{
    public class EdzoRepo<TEntity> : IRepo<TEntity>, IEdzoRepo where TEntity : Edzo
    {
        AppDbContext _appDbContext;

        public EdzoRepo(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int GetEdzokSzama() => _appDbContext.Edzok.Count;
        public List<Edzo> GetOsszesEdzo() => _appDbContext.Edzok;

        public void Hozzad(TEntity entity)
        {
            _appDbContext.Edzok.Add(entity);
        }

        public void Modosit(TEntity entity)
        {
            Edzo? edzo = _appDbContext.Edzok.Find(e => e.Nev == entity.Nev && e.FociKlub == entity.FociKlub);

            if(edzo is not null)
            {
                edzo.FociKlub = entity.FociKlub;
                edzo.Fizetes = entity.Fizetes;
            }
        }

        public void Torol(TEntity entity)
        {
            _appDbContext.Edzok.Remove(entity);
        }
    }
}
