using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CategoriesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            return Ok(await _serviceManager.CategoryService.GetAllCategoriesAsync(false));
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOneCategoryByIdAsync([FromRoute] int id)
        {
            return Ok(await _serviceManager.CategoryService.GetOneCategoryByIdAsync(id, false));
        }
    }
}
