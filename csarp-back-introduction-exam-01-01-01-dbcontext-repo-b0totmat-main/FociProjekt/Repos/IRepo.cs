namespace FociProjekt.Repos
{
    public interface IRepo<TEntity>  where TEntity : class
    {
        void Hozzad(TEntity entity);
        void Modosit(TEntity entity);
        void Torol(TEntity entity);
    }
}
