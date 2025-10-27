using System.Collections.Generic;
using System.Linq;
using Perpustakaan.Interfaces;
using Perpustakaan.Models;

namespace Perpustakaan.Repositories
{
    public class AnggotaRepository : IAnggotaRepository
    {
        private readonly List<Anggota> _anggotaList = new List<Anggota>();
        private int _idCounter = 1;

        public void Add(Anggota anggota)
        {
            anggota.IdAnggota = _idCounter++;
            _anggotaList.Add(anggota);
        }

        public List<Anggota> GetAll()
        {
            return new List<Anggota>(_anggotaList);
        }

        public Anggota GetById(int idAnggota)
        {
            return _anggotaList.FirstOrDefault(a => a.IdAnggota == idAnggota);
        }
    }
}