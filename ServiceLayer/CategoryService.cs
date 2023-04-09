using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Repositories;
using Microsoft.EntityFrameworkCore.Metadata;
using Mysqlx.Expr;

namespace ServiceLayer
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTO>> GetAllCategoriesAsync(int skip,int take);
        public Task<CategoryDTO> GetCategoryByIdentifierAsync(string identifier);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        //public CategoryService(ICategoryRepository categoryRepository)
        //{
        //    _categoryRepository = categoryRepository;
        //}

        public CategoryService (IUnitOfWorkRepository unitOfWork)
        {
            _categoryRepository = unitOfWork._CategoryRepository;
        }

        public async Task<List<CategoryDTO>> GetAllCategoriesAsync(int skip, int take)
        {
            var data = await _categoryRepository.GetAllCategoriesAsync(skip, take);
            var model = data.Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
                Identifier = x.Identifier,
                Description = x.Description,
                Articles = x.Articles != null ? x.Articles.Select(y => new ArticleDTO
                {

                    Id = y.Id,
                    Title = y.Title,
                    ArticleBody = y.ArticleBody,
                    LastUpdate = y.LastUpdate,
                    Identifier = y.Identifier,
                    ShortDescription = y.ShortDescription,
                    ReadingTime = y.ReadingTime,
                    MetaDescription = y.MetaDescription,
                    IsBlocked = y.IsBlocked
                }).ToList() : new List<ArticleDTO>()
            }).ToList();
            return model;
        }
        public async Task<CategoryDTO> GetCategoryByIdentifierAsync(string identifier)
        {
            var data = await _categoryRepository.GetCategoryByIdentifier(identifier);

            var model = new CategoryDTO
            {
                Id = data.Id,
                Identifier = data.Identifier,
                Name = data.Name,
                Description = data.Description,
                Articles = data.Articles != null ? data.Articles.Select(y => new ArticleDTO
                {
                    Id = y.Id,
                    Title = y.Title,
                    ArticleBody = y.ArticleBody,
                    LastUpdate = y.LastUpdate,
                    Identifier = y.Identifier,
                    ShortDescription = y.ShortDescription,
                    ReadingTime = y.ReadingTime,
                    MetaDescription = y.MetaDescription,
                    IsBlocked = y.IsBlocked
                }).ToList() : new List<ArticleDTO>()
            };
            return model;
        }
    }
}
