using System.Collections.Generic;
using System.Linq;
using Perpustakaan.Models;

namespace Perpustakaan.Services
{
    public class BukuService : IBukuService
    {
        private List<Buku> _bukuList;

        public BukuService()
        {
            _bukuList = new List<Buku>();
            // Data dummy
            _bukuList.Add(new Buku(1, "Pemrograman C#", "John Doe", "IT Publisher", 2023));
            _bukuList.Add(new Buku(2, "Design Patterns", "Jane Smith", "Tech Books", 2022));
        }

        public void TambahBuku(Buku buku)
        {
            var existingBook = _bukuList.Find(b => b.IdBuku == buku.IdBuku);
            if (existingBook != null)
            {
                throw new System.Exception("Buku dengan ID tersebut sudah ada");
            }
            _bukuList.Add(buku);
        }

        public void HapusBuku(int id)
        {
            var buku = _bukuList.Find(b => b.IdBuku == id);
            if (buku != null)
            {
                _bukuList.Remove(buku);
            }
            else
            {
                throw new System.Exception("Buku tidak ditemukan");
            }
        }

        public List<Buku> GetAllBuku()
        {
            return _bukuList;
        }

        public Buku GetBukuById(int id)
        {
            return _bukuList.FirstOrDefault(b => b.IdBuku == id);
        }
    }
}