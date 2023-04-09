using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface IArticleService
    {
        Task<IEnumerable<ArticleDTO>> GetAllArticlesAsync(int skip, int take);
        Task<ArticleDTO> GetArticleByIdentifier(string identifier);
    }
    public class ArticleService : IArticleService
    {
        //private readonly IArticleRepository _articleRepository;
        //public ArticleService(IArticleRepository articleRepository)
        //{
        //    _articleRepository = articleRepository;
        //}

        private readonly IArticleRepository _articleRepository;
        public ArticleService(IUnitOfWorkRepository unitOfWork) {
            _articleRepository = unitOfWork._ArticleRepository;
        }

        public async Task<IEnumerable<ArticleDTO>> GetAllArticlesAsync(int skip, int take)
        {
            var data = await _articleRepository.GetAllArticlesAsync(skip, take);
            var model = data.Select(x => new ArticleDTO()
            {
                Id = x.Id,
                Title = x.Title,
                ArticleBody = x.ArticleBody,
                LastUpdate = x.LastUpdate,
                PublishDate = x.PublishDate,
                Identifier = x.Identifier,
                ShortDescription = x.ShortDescription,
                ReadingTime = x.ReadingTime,
                MetaDescription = x.MetaDescription,
                IsBlocked = x.IsBlocked,
                CategoryId = x.Category.Id
            }).ToList();
            return model;
        }

        public async Task<ArticleDTO> GetArticleByIdentifier(string identifier)
        {
            var data = await _articleRepository.GetArticleByIdentifier(identifier);
            var model = new ArticleDTO()
            {
                Id = data.Id,
                Title = data.Title,
                ArticleBody = data.ArticleBody,
                LastUpdate = data.LastUpdate,
                PublishDate = data.PublishDate,
                Identifier = data.Identifier,
                ShortDescription = data.ShortDescription,
                ReadingTime = data.ReadingTime,
                MetaDescription = data.MetaDescription,
                IsBlocked = data.IsBlocked,
                CategoryId = data.Category.Id

            };
            return model;
        }

    }
}
