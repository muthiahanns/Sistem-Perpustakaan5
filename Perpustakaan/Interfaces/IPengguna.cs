using System.Collections.Generic;
using Perpustakaan.Models;

namespace Perpustakaan.Interfaces
{
    public interface IPengguna
    {
        void Login(string username, string password);
        List<Buku> LihatBuku();
    }
}