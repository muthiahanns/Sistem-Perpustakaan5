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

        // IMPLEMENTASI INTERFACE - void LihatBuku() sesuai UML
        public void LihatBuku()
        {
            Console.WriteLine("Admin melihat daftar buku");
            // Dalam implementasi nyata, ini akan terhubung ke service
        }

        // METHOD TAMBAHAN sesuai UML
        public void TambahBuku(Buku buku)
        {
            Console.WriteLine($"Admin menambah buku: {buku.Judul}");
            // Dalam implementasi nyata, ini akan terhubung ke service
        }

        public void HapusBuku(int id)
        {
            Console.WriteLine($"Admin menghapus buku dengan ID: {id}");
            // Dalam implementasi nyata, ini akan terhubung ke service
        }

        public void AturAkunAnggota()
        {
            Console.WriteLine("Admin mengatur akun anggota");
            // Dalam implementasi nyata, ini akan mengatur data anggota
        }
    }
}