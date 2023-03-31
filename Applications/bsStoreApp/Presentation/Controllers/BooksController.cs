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
            try
            {
                var books = _serviceManager.BookService.GetAllBooks(false);
                return Ok(books);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {

            try
            {
                var books = _serviceManager.BookService.GetOneBookById(id, false);

                if (books is null)
                {
                    return NotFound();
                }

                return Ok(books);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        [HttpPost]
        public IActionResult CreateOneBook([FromBody] Book? book)
        {
            try
            {
                if (book is null)
                {
                    return BadRequest();
                }

                _serviceManager.BookService.CreateOneBook(book);
                return StatusCode(201, book);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            try
            {
                if (book is null)
                {
                    return BadRequest();
                }
                _serviceManager.BookService.UpdateOneBook(id, book, true);
                return NoContent();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        [HttpDelete("{id:int}")]
        public IActionResult RemoveOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                _serviceManager.BookService.DeleteOneBook(id, false);
                return NoContent();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }



        }
        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id,
            [FromBody] JsonPatchDocument<Book> bookPatchDocument)
        {
            //Check Entity
            var entity = _serviceManager.BookService.GetOneBookById(id, true);
            if (entity is null)
            {
                return NotFound();
            }

            bookPatchDocument.ApplyTo(entity);
            _serviceManager.BookService.UpdateOneBook(id, entity, true);
            return NoContent();

        }
    }
}
