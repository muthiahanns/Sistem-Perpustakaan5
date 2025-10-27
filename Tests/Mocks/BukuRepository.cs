using System.Collections.Generic;
using System.Linq;
using Perpustakaan.Interfaces;
using Perpustakaan.Models;

namespace Perpustakaan.Repositories
{
    public class BukuRepository : IBukuRepository
    {
        // Database palsu (List) sekarang pindah ke sini
        private readonly List<Buku> _bukuList = new List<Buku>();
        private int _idCounter = 1;

        public void Add(Buku buku)
        {
            buku.IdBuku = _idCounter++; // Atur ID di sini
            _bukuList.Add(buku);
        }

        public void Delete(int idBuku)
        {
            var buku = GetById(idBuku);
            if (buku != null)
            {
                _bukuList.Remove(buku);
            }
        }

        public List<Buku> GetAll()
        {
            return new List<Buku>(_bukuList); // Kembalikan salinan
        }

        public Buku GetById(int idBuku)
        {
            return _bukuList.FirstOrDefault(b => b.IdBuku == idBuku);
        }

        public void Update(Buku bukuUpdate)
        {
            var buku = GetById(bukuUpdate.IdBuku);
            if (buku != null)
            {
                // Update propertinya (contoh)
                buku.Judul = bukuUpdate.Judul;
                buku.Tersedia = bukuUpdate.Tersedia;
                // ...
            }
        }
    }
}