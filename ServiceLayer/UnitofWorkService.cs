using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IUnitofWorkService 
    {
        ICategoryService CategoryService { get; }
        IArticleService ArticleService { get; }
    }
    public class UnitofWorkService : IUnitofWorkService
    {

        private ICategoryService _categoryService;
        private IArticleService _articleService;

        public UnitofWorkService(IUnitOfWorkRepository unitOfWorkRepository, ICategoryService categoryService, IArticleService articleService)
        {
            //_unitOfWorkRepository = unitOfWorkRepository;
            _categoryService = categoryService;
            _articleService = articleService;
        }

        public ICategoryService CategoryService { get { return _categoryService; } }
        public IArticleService ArticleService { get { return _articleService; } }

       
    }
}
