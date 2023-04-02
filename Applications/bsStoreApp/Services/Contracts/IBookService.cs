using Entities.DTOs;
using Entities.Models;

namespace Services.Contracts
{
    public interface IBookService
    {
        IEnumerable<BookDto> GetAllBooks(bool trackChanges);
        BookDto GetOneBookById(int id, bool trackChanges);
        BookDto CreateOneBook(BookDtoForInsertion book);
        void UpdateOneBook(int id, BookDtoForUpdate bookDto, bool trackChanges);
        void DeleteOneBook(int id, bool trackChanges);

        (BookDtoForUpdate bookDtoForUpdate, Book book) GetOneBookForPatch(int id, bool trackChanges);

        void SaveChangesForPatch(BookDtoForUpdate bookDtoForUpdate, Book book);
    }
}