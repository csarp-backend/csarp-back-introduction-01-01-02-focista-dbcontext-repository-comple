using FociProjekt.Entities;

namespace FociProjekt.Repos
{
    public interface IEdzoRepo
    {
        int GetEdzokSzama();
        List<Edzo> GetOsszesEdzo();
    }
}
