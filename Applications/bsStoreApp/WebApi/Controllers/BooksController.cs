using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _repositoryContext;

        public BooksController(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            try
            {
                var books = _repositoryContext.Books.ToList();
                return Ok(books);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetBook([FromRoute(Name = "id")] int id)
        {

            try
            {
                var books = _repositoryContext.Books.FirstOrDefault(x => x.Id == id);

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

                _repositoryContext.Books.Add(book);
                _repositoryContext.SaveChanges();
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
            var entity = _repositoryContext.Books.SingleOrDefault(x => x.Id == id);
            if (entity is null)
            {
                return NotFound();
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            entity.Title = book.Title;
            entity.Price = book.Price;
            _repositoryContext.SaveChanges();
            return Ok(book);
        }


        [HttpDelete("{id:int}")]
        public IActionResult RemoveOneBook([FromRoute(Name = "id")] int id)
        {

            try
            {
                var entity = _repositoryContext.Books.FirstOrDefault(x => x.Id == id);
                if (entity != null)
                {
                    _repositoryContext.Books.Remove(entity);
                    _repositoryContext.SaveChanges();
                }

                else
                {
                    return NotFound(new { statusCode = 404, message = $"Book with id: {id} could not found." });
                }

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
            var entity = _repositoryContext.Books.FirstOrDefault(x => x.Id == id);
            if (entity is null)
            {
                return NotFound();
            }

            bookPatchDocument.ApplyTo(entity);
            return NoContent();

        }
    }
}
