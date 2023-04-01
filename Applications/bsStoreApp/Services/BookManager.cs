using AutoMapper;
using Entities.DTOs;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;

        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<BookDto> GetAllBooks(bool trackChanges)
        {
            var books = _manager.BookRepository.GetAllBooks(trackChanges);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public Book GetOneBookById(int id, bool trackChanges)
        {
            var book = _manager.BookRepository.GetOneBookById(id, trackChanges);
            if (book is null)
            {
                throw new BookNotFoundException(id);
            }
            return book;
        }

        public Book CreateOneBook(Book book)
        {
            _manager.BookRepository.CreateOneBook(book);
            _manager.Save();
            return book;
        }

        public void UpdateOneBook(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var entity = _manager.BookRepository.GetOneBookById(id, true);
            if (entity is null)
            {
                throw new BookNotFoundException(id);
            }

            if (bookDto is null)
                throw new ArgumentNullException(nameof(bookDto));

            _mapper.Map<Book>(bookDto);
            _manager.BookRepository.UpdateOneBook(entity);
            _manager.Save();

        }

        public void DeleteOneBook(int id, bool trackChanges)
        {
            var entity = _manager.BookRepository.GetOneBookById(id, false);
            if (entity is null)
            {
                throw new BookNotFoundException(id);
            }
            else
            {
                _manager.BookRepository.DeleteOneBook(entity);
                _manager.Save();
            }
        }
    }
}
