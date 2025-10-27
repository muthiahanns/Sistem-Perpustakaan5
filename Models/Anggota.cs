using System;
using System.Collections.Generic;
using Perpustakaan.Interfaces;

namespace Perpustakaan.Models
{
    public class Anggota : IPengguna
    {
        public int IdAnggota { get; private set; }
        public string Nama { get; private set; }
        public string Username { get; private set; }
        private string Password { get; set; }

        public Anggota(int idAnggota, string nama, string username, string password)
        {
            IdAnggota = idAnggota;
            Nama = nama;
            Username = username;
            Password = password;
        }

        public void Login(string username, string password)
        {
            if (Username == username && Password == password)
            {
                Console.WriteLine($"Login berhasil! Selamat datang {Nama}");
            }
            else
            {
                throw new UnauthorizedAccessException("Username atau password salah");
            }
        }

        public List<Buku> LihatBuku()
        {
            // Implementasi akan dihubungkan dengan service
            return new List<Buku>();
        }

        public void PinjamBuku(Buku buku, IPeminjamanService peminjamanService)
        {
            if (!buku.Tersedia)
                throw new InvalidOperationException("Buku tidak tersedia");
            
            peminjamanService.BuatPeminjaman(this, buku);
            buku.UbahStatus(false);
        }

        public void KembalikanBuku(int idPeminjaman, IPeminjamanService peminjamanService)
        {
            peminjamanService.KembalikanBuku(idPeminjaman);
        }
    }
}