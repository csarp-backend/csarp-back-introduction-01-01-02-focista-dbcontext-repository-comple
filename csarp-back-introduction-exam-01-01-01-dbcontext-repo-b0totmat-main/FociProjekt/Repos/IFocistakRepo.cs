using FociProjekt.Entities;

namespace FociProjekt.Repos
{
    public interface IFocistakRepo
    {
        int GetFocistakSzama();
        List<Focista> KivalasztOsszesFocistat();
    }
}
