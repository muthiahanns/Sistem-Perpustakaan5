using System;
using System.Collections.Generic;
using System.Linq;
using Perpustakaan.Interfaces;
using Perpustakaan.Models;

namespace Perpustakaan.Services
{
    public class BukuService : IBukuService
    {
        private List<Buku> _bukuList = new List<Buku>();
        private int _idCounter = 1;

        public void TambahBuku(Buku buku)
        {
            if (buku == null)
                throw new ArgumentNullException(nameof(buku));
            
            buku = new Buku(_idCounter++, buku.Judul, buku.Pengarang, buku.Penerbit, buku.TahunTerbit);
            _bukuList.Add(buku);
        }

        public void HapusBuku(int idBuku)
        {
            var buku = _bukuList.FirstOrDefault(b => b.IdBuku == idBuku);
            if (buku != null)
            {
                _bukuList.Remove(buku);
            }
            else
            {
                throw new KeyNotFoundException("Buku tidak ditemukan");
            }
        }

        public List<Buku> DapatkanSemuaBuku()
        {
            return new List<Buku>(_bukuList);
        }

        public Buku DapatkanBukuById(int idBuku)
        {
            return _bukuList.FirstOrDefault(b => b.IdBuku == idBuku);
        }
    }
}