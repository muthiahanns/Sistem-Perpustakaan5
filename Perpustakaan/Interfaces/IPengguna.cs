using System.Collections.Generic;
using Perpustakaan.Models;

namespace Perpustakaan.Interfaces
{
    public interface IPengguna
    {
        void Login(string username, string password);
        void LihatBuku(); // Diubah menjadi void sesuai UML
    }
}