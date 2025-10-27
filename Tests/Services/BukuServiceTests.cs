using Xunit;
using Perpustakaan.Models;
using Perpustakaan.Services;

namespace Perpustakaan.Tests.Services
{
    public class BukuServiceTests
    {
        [Fact]
        public void TambahBuku_ShouldAddBookToList()
        {
            // Arrange
            var service = new BukuService();
            var buku = new Buku(0, "Pemrograman C#", "Andi Rosiqah", "Kelompok Lima", 2025);
            
            // Act
            service.TambahBuku(buku);
            var allBooks = service.DapatkanSemuaBuku();
            
            // Assert
            Assert.Single(allBooks);
            Assert.Equal("Pemrograman C#", allBooks[0].Judul);
            Assert.Equal("Andi Rosiqah", allBooks[0].Pengarang);
        }
        
        [Fact]
        public void TambahBuku_WithNullBook_ShouldThrowException()
        {
            // Arrange
            var service = new BukuService();
            
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => service.TambahBuku(null));
        }
        
        [Fact]
        public void HapusBuku_WithValidId_ShouldRemoveBook()
        {
            // Arrange
            var service = new BukuService();
            var buku = new Buku(0, "Pemrograman C#", "Andi Rosiqah", "Kelompok Lima", 2025);
            service.TambahBuku(buku);
            var addedBook = service.DapatkanSemuaBuku()[0];
            
            // Act
            service.HapusBuku(addedBook.IdBuku);
            var allBooks = service.DapatkanSemuaBuku();
            
            // Assert
            Assert.Empty(allBooks);
        }
        
        [Fact]
        public void HapusBuku_WithInvalidId_ShouldThrowException()
        {
            // Arrange
            var service = new BukuService();
            
            // Act & Assert
            Assert.Throws<System.Collections.Generic.KeyNotFoundException>(() => 
                service.HapusBuku(999));
        }
        
        [Fact]
        public void DapatkanBukuById_WithValidId_ShouldReturnBook()
        {
            // Arrange
            var service = new BukuService();
            var buku = new Buku(0, "Pemrograman C#", "Andi Rosiqah", "Kelompok Lima", 2025);
            service.TambahBuku(buku);
            var addedBook = service.DapatkanSemuaBuku()[0];
            
            // Act
            var result = service.DapatkanBukuById(addedBook.IdBuku);
            
            // Assert
            Assert.NotNull(result);
            Assert.Equal("Pemrograman C#", result.Judul);
        }
        
        [Fact]
        public void DapatkanBukuById_WithInvalidId_ShouldReturnNull()
        {
            // Arrange
            var service = new BukuService();
            
            // Act
            var result = service.DapatkanBukuById(999);
            
            // Assert
            Assert.Null(result);
        }
    }
}