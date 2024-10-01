using FociProjekt.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FociProjekt.Repos
{
    public interface IBajnoksagRepo
    {
        int GetBajnoksagokSzama();
        List<Bajnoksag> GetOsszesBajnoksag();
    }
}
