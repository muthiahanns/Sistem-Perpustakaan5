using System.Collections.Generic;
using Perpustakaan.Models;

namespace Perpustakaan.Interfaces
{
    public interface IPeminjamanService
    {
        void BuatPeminjaman(Anggota anggota, Buku buku);
        void KembalikanBuku(int idPeminjaman);
        List<Peminjaman> DapatkanSemuaPeminjaman();
        Peminjaman DapatkanPeminjamanById(int idPeminjaman);
    }
}