using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasData(
                new Book { Id = 1, CategoryId = 1, Title = "Karegöz ve Hacivat", Price = 75 },
                new Book { Id = 2, CategoryId = 2, Title = "Mesnevi", Price = 175 },
                new Book { Id = 3, CategoryId = 1, Title = "Devlet", Price = 375 }
            );
        }
    }
}
