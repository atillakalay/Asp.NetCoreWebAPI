using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    //[ApiVersion("2.0", Deprecated = true)]
    [ApiController]
    [Route("api/books")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class BooksV2Controller : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BooksV2Controller(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBookAsync()
        {
            var books = await _serviceManager.BookService.GetAllBooksAsync(false);
            var booksV2 = books.Select(b => new
            {
                Title = b.Title,
                Id = b.Id,
            });
            return Ok(booksV2);
        }
    }
}
