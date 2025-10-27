using System;
using System.Collections.Generic;
using Perpustakaan.Interfaces;

namespace Perpustakaan.Models
{
    public class Admin : IPengguna
    {
        private string Username { get; set; }
        private string Password { get; set; }

        public Admin(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public void Login(string username, string password)
        {
            if (Username == username && Password == password)
            {
                Console.WriteLine("Login admin berhasil!");
            }
            else
            {
                throw new UnauthorizedAccessException("Kredensial admin salah");
            }
        }

        public List<Buku> LihatBuku()
        {
            // Implementasi akan dihubungkan dengan service
            return new List<Buku>();
        }

        public void TambahBuku(Buku buku, IBukuService bukuService)
        {
            bukuService.TambahBuku(buku);
        }

        public void HapusBuku(int idBuku, IBukuService bukuService)
        {
            bukuService.HapusBuku(idBuku);
        }

        public void AturAkunAnggota(Anggota anggota, string namaBaru = null, string passwordBaru = null)
        {
            if (!string.IsNullOrEmpty(namaBaru))
                // Dalam implementasi nyata, ini akan mengupdate properti
                Console.WriteLine($"Nama anggota diubah menjadi: {namaBaru}");
            
            if (!string.IsNullOrEmpty(passwordBaru))
                Console.WriteLine("Password anggota telah diubah");
        }
    }
}