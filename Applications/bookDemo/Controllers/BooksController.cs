using bookDemo.Data;
using bookDemo.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace bookDemo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = ApplicationContext.Books;
            return Ok(books);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBook([FromRoute(Name = "id")] int id)
        {
            var books = ApplicationContext.Books.FirstOrDefault(x => x.Id == id);

            if (books is null)
            {
                return NotFound();
            }
            return Ok(books);
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
                ApplicationContext.Books.Add(book);
                return StatusCode(201);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] Book book)
        {
            var entity = ApplicationContext.Books.Find(x => x.Id == id);
            if (entity is null)
            {
                return NotFound();
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            ApplicationContext.Books.Remove(entity);
            book.Id = entity.Id;
            ApplicationContext.Books.Add(book);
            return Ok(book);
        }

        [HttpDelete("{id:int}")]
        public IActionResult RemoveOneBook([FromRoute(Name = "id")] int id)
        {
            var entity = ApplicationContext.Books.FirstOrDefault(x => x.Id == id);
            if (entity != null) ApplicationContext.Books.Remove(entity);
            else
            {
                return NotFound(new { statusCode = 404, message = $"Book with id: {id} could not found." });
            }
            return NoContent();
        }

        [HttpDelete]
        public IActionResult RemoveAllBooks()
        {
            ApplicationContext.Books.Clear();
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        public IActionResult PartiallyUpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] JsonPatchDocument<Book> bookPatchDocument)
        {
            //Check Entity
            var entity = ApplicationContext.Books.FirstOrDefault(x => x.Id == id);
            if (entity is null)
            {
                return NotFound();
            }

            bookPatchDocument.ApplyTo(entity);
            return NoContent();
        }

    }
}
