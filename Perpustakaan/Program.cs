using System;
using Perpustakaan.Models;
using Perpustakaan.Services;

namespace Perpustakaan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SISTEM PERPUSTAKAAN SEDERHANA ===\n");
            
            try
            {
                // Inisialisasi services
                var bukuService = new BukuService();
                var peminjamanService = new PeminjamanService();
                
                // Buat admin dan anggota
                var admin = new Admin("admin", "password123");
                var anggota = new Anggota(1, "Kelompok lima", "kelompok5", "pass123");

                // 1. Demo login
                Console.WriteLine("1. PROSES LOGIN");
                Console.WriteLine("----------------");
                admin.Login("admin", "password123");
                anggota.Login("kelompok5", "pass123");
                Console.WriteLine();

                // 2. Admin menambah buku
                Console.WriteLine("2. ADMIN MENAMBAH BUKU");
                Console.WriteLine("----------------------");
                
                var buku1 = new Buku(0, "Pemrograman C#", "John Doe", "IT Publisher", 2023);
                var buku2 = new Buku(0, "Struktur Data", "Jane Smith", "Tech Books", 2022);
                var buku3 = new Buku(0, "Database Systems", "Mike Johnson", "CS Publishing", 2021);
                
                admin.TambahBuku(buku1, bukuService);
                Console.WriteLine($"✓ Buku ditambahkan: {buku1.Judul}");
                
                admin.TambahBuku(buku2, bukuService);
                Console.WriteLine($"✓ Buku ditambahkan: {buku2.Judul}");
                
                admin.TambahBuku(buku3, bukuService);
                Console.WriteLine($"✓ Buku ditambahkan: {buku3.Judul}");
                Console.WriteLine();

                // 3. Tampilkan semua buku
                Console.WriteLine("3. DAFTAR BUKU TERSEDIA");
                Console.WriteLine("-----------------------");
                var semuaBuku = bukuService.DapatkanSemuaBuku();
                foreach (var buku in semuaBuku)
                {
                    Console.WriteLine($"  - {buku.Judul} oleh {buku.Pengarang} ({buku.TahunTerbit})");
                }
                Console.WriteLine();

                // 4. Anggota meminjam buku
                Console.WriteLine("4. PROSES PEMINJAMAN");
                Console.WriteLine("---------------------");
                
                // Dapatkan buku yang akan dipinjam dari service
                var bukuUntukDipinjam = bukuService.DapatkanBukuById(1);
                if (bukuUntukDipinjam != null)
                {
                    anggota.PinjamBuku(bukuUntukDipinjam, peminjamanService);
                    Console.WriteLine($"✓ {anggota.Nama} berhasil meminjam: {bukuUntukDipinjam.Judul}");
                    Console.WriteLine($"  Status ketersediaan: {(bukuUntukDipinjam.Tersedia ? "Tersedia" : "Tidak Tersedia")}");
                }
                Console.WriteLine();

                // 5. Tampilkan status peminjaman
                Console.WriteLine("5. STATUS PEMINJAMAN");
                Console.WriteLine("---------------------");
                var peminjamanAktif = peminjamanService.DapatkanSemuaPeminjaman();
                if (peminjamanAktif.Count > 0)
                {
                    foreach (var peminjaman in peminjamanAktif)
                    {
                        Console.WriteLine($"  - Peminjaman ID: {peminjaman.IdPeminjaman}");
                        Console.WriteLine($"    Anggota: {peminjaman.Anggota.Nama}");
                        Console.WriteLine($"    Buku: {peminjaman.Buku.Judul}");
                        Console.WriteLine($"    Status: {peminjaman.Status}");
                        Console.WriteLine($"    Tanggal Kembali: {peminjaman.TanggalKembali:dd/MM/yyyy}");
                    }
                }
                else
                {
                    Console.WriteLine("  Tidak ada peminjaman aktif");
                }
                Console.WriteLine();

                // 6. Demo pengembalian buku
                Console.WriteLine("6. PENGEMBALIAN BUKU");
                Console.WriteLine("---------------------");
                if (peminjamanAktif.Count > 0)
                {
                    anggota.KembalikanBuku(1, peminjamanService);
                    Console.WriteLine($"✓ Buku berhasil dikembalikan");
                    
                    // Cek status buku setelah dikembalikan
                    var bukuDikembalikan = bukuService.DapatkanBukuById(1);
                    Console.WriteLine($"  Status {bukuDikembalikan.Judul}: {(bukuDikembalikan.Tersedia ? "Tersedia" : "Dipinjam")}");
                }
                Console.WriteLine();

                // 7. Demo perhitungan denda
                Console.WriteLine("7. PERHITUNGAN DENDA");
                Console.WriteLine("---------------------");
                // Buat peminjaman khusus untuk demo denda
                var bukuDenda = new Buku(0, "Buku Demo Denda", "Author", "Publisher", 2023);
                admin.TambahBuku(bukuDenda, bukuService);
                
                var peminjamanDenda = new Peminjaman(99, anggota, bukuDenda);
                // Set tanggal kembali ke 5 hari yang lalu untuk simulasi keterlambatan
                var peminjamanType = typeof(Peminjaman);
                var tanggalKembaliField = peminjamanType.GetField("_tanggalKembali", 
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                
                if (tanggalKembaliField != null)
                {
                    tanggalKembaliField.SetValue(peminjamanDenda, DateTime.Now.AddDays(-5));
                }
                
                var denda = peminjamanDenda.HitungDenda();
                Console.WriteLine($"  Denda untuk keterlambatan 5 hari: Rp {denda:F0}");
                Console.WriteLine();

                Console.WriteLine("=== SEMUA DEMO BERHASIL DIEKSEKUSI ===");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n❌ ERROR: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }

            Console.WriteLine("\nTekan enter untuk keluar...");
            Console.ReadLine();
        }
    }
}