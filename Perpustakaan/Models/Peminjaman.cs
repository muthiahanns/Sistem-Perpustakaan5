using System;

namespace Perpustakaan.Models
{
    public class Peminjaman
    {
        public int IdPeminjaman { get; private set; }
        public Anggota Anggota { get; private set; }
        public Buku Buku { get; private set; }
        public DateTime TanggalPinjam { get; private set; }
        public DateTime TanggalKembali { get; private set; }
        public string Status { get; private set; }

        public Peminjaman(int idPeminjaman, Anggota anggota, Buku buku)
        {
            IdPeminjaman = idPeminjaman;
            Anggota = anggota;
            Buku = buku;
            TanggalPinjam = DateTime.Now;
            TanggalKembali = DateTime.Now.AddDays(14);
            Status = "Dipinjam";
        }

        public void BuatPeminjaman(Anggota anggota, Buku buku)
        {
            Console.WriteLine($"Membuat peminjaman: {anggota.Nama} - {buku.Judul}");
        }

        public void KembalikanBuku()
        {
            Status = "Dikembalikan";
            Buku.UbahStatus(true);
            Console.WriteLine("Buku telah dikembalikan");
        }

        public double HitungDenda()
        {
            if (Status == "Dipinjam" && DateTime.Now > TanggalKembali)
            {
                var hariTerlambat = (DateTime.Now - TanggalKembali).Days;
                return hariTerlambat * 2000;
            }
            return 0;
        }
    }
}