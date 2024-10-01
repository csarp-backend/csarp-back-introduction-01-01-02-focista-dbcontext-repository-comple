using FociProjekt.Entities;

namespace FociProjekt.Repos
{
    public interface IFociKlubokRepo
    {
        int GetFociKlubokSzama();
        List<FociKlub> GetOsszesFociKlub();
    }
}
