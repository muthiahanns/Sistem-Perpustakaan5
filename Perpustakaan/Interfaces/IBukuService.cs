using System.Collections.Generic;
using Perpustakaan.Models;

namespace Perpustakaan.Interfaces
{
    public interface IBukuService
    {
        void TambahBuku(Buku buku);
        void HapusBuku(int idBuku);
        List<Buku> DapatkanSemuaBuku();
        Buku DapatkanBukuById(int idBuku);
    }
}