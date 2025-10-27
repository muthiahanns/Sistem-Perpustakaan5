using System.Collections.Generic;
using Perpustakaan.Models;

namespace Perpustakaan.Services
{
    public interface IBukuService
    {
        void TambahBuku(Buku buku);
        void HapusBuku(int id);
        List<Buku> GetAllBuku();
        Buku GetBukuById(int id);
    }
}