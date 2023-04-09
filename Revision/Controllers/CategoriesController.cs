using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace Revision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(IUnitofWorkService unitofWorkService)
        {
            _categoryService = unitofWorkService.CategoryService;
        }

        [HttpGet]
        [Route("categories")]
        public async Task<IActionResult> GetAllCategoriesAsync(int skip, int take)
        {
            var data = await _categoryService.GetAllCategoriesAsync(skip, take);
            return Ok(data);
        }

        [HttpGet]
        [Route("singlecategory")]
        public async Task<IActionResult> GetCategoryByIdentifier(string identifer)
        {
            var data= _categoryService.GetCategoryByIdentifierAsync(identifer);
            return Ok(data);
        }
    }
}
