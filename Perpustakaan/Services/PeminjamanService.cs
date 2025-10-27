using System;
using System.Collections.Generic;
using System.Linq;
using Perpustakaan.Interfaces;
using Perpustakaan.Models;

namespace Perpustakaan.Services
{
    public class PeminjamanService : IPeminjamanService
    {
        private List<Peminjaman> _peminjamanList = new List<Peminjaman>();
        private int _idCounter = 1;

        public void BuatPeminjaman(Anggota anggota, Buku buku)
        {
            if (anggota == null || buku == null)
                throw new ArgumentNullException("Anggota dan buku harus diisi");
            
            if (!buku.Tersedia)
                throw new InvalidOperationException("Buku tidak tersedia untuk dipinjam");
            
            var peminjaman = new Peminjaman(_idCounter++, anggota, buku);
            _peminjamanList.Add(peminjaman);
            buku.UbahStatus(false);
        }

        public void KembalikanBuku(int idPeminjaman)
        {
            var peminjaman = _peminjamanList.FirstOrDefault(p => p.IdPeminjaman == idPeminjaman);
            if (peminjaman != null)
            {
                peminjaman.KembalikanBuku();
            }
            else
            {
                throw new KeyNotFoundException("Peminjaman tidak ditemukan");
            }
        }

        public List<Peminjaman> DapatkanSemuaPeminjaman()
        {
            return new List<Peminjaman>(_peminjamanList);
        }

        public Peminjaman DapatkanPeminjamanById(int idPeminjaman)
        {
            return _peminjamanList.FirstOrDefault(p => p.IdPeminjaman == idPeminjaman);
        }
    }
}