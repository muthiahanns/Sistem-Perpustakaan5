namespace Perpustakaan.Models
{
    public class Buku
    {
        public int IdBuku { get; private set; }
        public string Judul { get; private set; }
        public string Pengarang { get; private set; }
        public string Penerbit { get; private set; }
        public int TahunTerbit { get; private set; }
        public bool Tersedia { get; private set; }

        public Buku(int idBuku, string judul, string pengarang, string penerbit, int tahunTerbit)
        {
            IdBuku = idBuku;
            Judul = judul;
            Pengarang = pengarang;
            Penerbit = penerbit;
            TahunTerbit = tahunTerbit;
            Tersedia = true;
        }

        public string GetInfo()
        {
            return $"ID: {IdBuku}, Judul: {Judul}, Pengarang: {Pengarang}, " +
                   $"Penerbit: {Penerbit}, Tahun: {TahunTerbit}, Tersedia: {(Tersedia ? "Ya" : "Tidak")}";
        }

        public void UbahStatus(bool ketersediaan)
        {
            Tersedia = ketersediaan;
        }
    }
}