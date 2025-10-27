using System;
using Perpustakaan.Models;

namespace Perpustakaan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEM PERPUSTAKAAN SEDERHANA ===");
            
            // Buat objek sesuai UML
            var admin = new Admin("admin", "password123");
            var anggota = new Anggota(1, "Andi Rosiqah", "heci", "pass123");
            
            // Buat beberapa buku
            var buku1 = new Buku(1, "Pemrograman C#", "Andi Rosiqah", "Kelompok Lima", 2025);
            var buku2 = new Buku(2, "Struktur Data", "Nahdah Fauziah", "IT Publisher", 2024);
            var buku3 = new Buku(3, "Aljabar Linear", "Siti Nur Aulia", "Erlangga", 2023);

            try
            {
                // 1. TEST LOGIN
                Console.WriteLine("\n1. TEST LOGIN");
                admin.Login("admin", "password123");
                anggota.Login("heci", "pass123");
                
                // 2. ADMIN TAMBAH BUKU
                Console.WriteLine("\n2. ADMIN TAMBAH BUKU");
                admin.TambahBuku(buku1);
                admin.TambahBuku(buku2);
                admin.TambahBuku(buku3);
                
                // 3. ADMIN LIHAT BUKU
                Console.WriteLine("\n3. ADMIN LIHAT BUKU");
                admin.LihatBuku();
                
                // 4. ANGGOTA LIHAT BUKU
                Console.WriteLine("\n4. ANGGOTA LIHAT BUKU");
                anggota.LihatBuku();
                
                // 5. ANGGOTA PINJAM BUKU
                Console.WriteLine("\n5. ANGGOTA PINJAM BUKU");
                anggota.PinjamBuku(buku1);
                
                // Buat objek peminjaman
                var peminjaman = new Peminjaman(1, anggota, buku1);
                peminjaman.BuatPeminjaman(anggota, buku1);
                buku1.UbahStatus(false);
                
                // Tampilkan info peminjaman
                Console.WriteLine("\nINFO PEMINJAMAN:");
                Console.WriteLine($"- ID: {peminjaman.IdPeminjaman}");
                Console.WriteLine($"- Anggota: {peminjaman.Anggota.Nama}");
                Console.WriteLine($"- Buku: {peminjaman.Buku.Judul}");
                Console.WriteLine($"- Tanggal Pinjam: {peminjaman.TanggalPinjam:dd-MM-yyyy}");
                Console.WriteLine($"- Tanggal Kembali: {peminjaman.TanggalKembali:dd-MM-yyyy}");
                Console.WriteLine($"- Status: {peminjaman.Status}");
                Console.WriteLine($"- Info Buku: {buku1.GetInfo()}");
                
                // 6. ADMIN ATUR AKUN ANGGOTA
                Console.WriteLine("\n6. ADMIN ATUR AKUN ANGGOTA");
                admin.AturAkunAnggota();
                
                // 7. ANGGOTA KEMBALIKAN BUKU
                Console.WriteLine("\n7. ANGGOTA KEMBALIKAN BUKU");
                anggota.KembalikanBuku(peminjaman.IdPeminjaman);
                peminjaman.KembalikanBuku();
                
                // 8. HITUNG DENDA
                Console.WriteLine("\n8. HITUNG DENDA");
                var denda = peminjaman.HitungDenda();
                if (denda > 0)
                {
                    Console.WriteLine($"Denda yang harus dibayar: Rp {denda}");
                }
                else
                {
                    Console.WriteLine("Tidak ada denda");
                }
                
                // 9. STATUS BUKU SETELAH DIKEMBALIKAN
                Console.WriteLine("\n9. STATUS BUKU SETELAH DIKEMBALIKAN");
                Console.WriteLine(buku1.GetInfo());
                
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            
            Console.WriteLine("\n=== PROGRAM SELESAI ===");
        }
    }
}