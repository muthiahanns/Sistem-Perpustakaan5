using Perpustakaan.Models;

namespace Perpustakaan.Interfaces
{
    public interface IAdmin : IPengguna
    {
        void TambahBuku(Buku buku);
        void HapusBuku(int id);
        void AturAkunAnggota();
    }
}