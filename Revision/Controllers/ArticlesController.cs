using DataLayer.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using ServiceLayer;

namespace Revision.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleservice;
        public ArticlesController(IUnitofWorkService unitofWorkService)
        {
            _articleservice = unitofWorkService.ArticleService;
        }

        [HttpGet]
        [Route("articles")]
        public async Task<IActionResult> GetAllArticles(int skip, int take)
        {
            var data = await _articleservice.GetAllArticlesAsync(skip, take);
            return Ok(data);
        }

        [HttpGet]
        [Route("singlearticle")]
        public async Task<IActionResult> GetArticleByIdentifier(string identifier)
        {
            var data = await _articleservice.GetArticleByIdentifier(identifier);
            return Ok(data);
        }
    }
}
