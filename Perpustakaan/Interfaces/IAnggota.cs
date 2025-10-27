using Perpustakaan.Models;

namespace Perpustakaan.Interfaces
{
    public interface IAnggota : IPengguna
    {
        void PinjamBuku(Buku buku);
        void KembalikanBuku(int idPeminjaman);
    }
}