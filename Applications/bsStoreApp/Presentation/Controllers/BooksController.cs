using Entities.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BooksController(IServiceManager serviceManager, ILoggerService loggerService)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _serviceManager.BookService.GetAllBooks(false);
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var books = _serviceManager.BookService.GetOneBookById(id, false);
            return Ok(books);
        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book? book)
        {
            if (book is null)
            {
                return BadRequest();
            }
            _serviceManager.BookService.CreateOneBook(book);
            return StatusCode(201, book);
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {

            if (book is null)
            {
                return BadRequest();
            }
            _serviceManager.BookService.UpdateOneBook(id, book, true);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveOneBook([FromRoute(Name = "id")] int id)
        {

            _serviceManager.BookService.DeleteOneBook(id, false);
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Book> bookPatchDocument)
        {
            //Check Entity
            var entity = _serviceManager.BookService.GetOneBookById(id, true);
            bookPatchDocument.ApplyTo(entity);
            _serviceManager.BookService.UpdateOneBook(id, entity, true);
            return NoContent();

        }
    }
}
