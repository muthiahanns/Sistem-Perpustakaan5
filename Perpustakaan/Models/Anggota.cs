using System;
using System.Collections.Generic;
using System.Linq;
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

        // IMPLEMENTASI INTERFACE - void LihatBuku() sesuai UML
        public void LihatBuku()
        {
            Console.WriteLine($"Anggota {Nama} melihat daftar buku");
            // Dalam implementasi nyata, ini akan terhubung ke service
        }

        // METHOD TAMBAHAN sesuai UML
        public void PinjamBuku(Buku buku)
        {
            Console.WriteLine($"Anggota {Nama} meminjam buku: {buku.Judul}");
            // Dalam implementasi nyata, ini akan terhubung ke service peminjaman
        }

        public void KembalikanBuku(int idPeminjaman)
        {
            Console.WriteLine($"Anggota {Nama} mengembalikan buku dengan ID peminjaman: {idPeminjaman}");
            // Dalam implementasi nyata, ini akan terhubung ke service peminjaman
        }
    }
}