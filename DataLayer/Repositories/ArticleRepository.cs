using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllArticlesAsync(int skip, int take);
        Task<Article> GetArticleByIdentifier(string identifier);
    }
    public class ArticleRepository : IArticleRepository
    {
        private readonly RevisionDbContext _context;
        private readonly FactoryDbContext _factoryContext;
        public ArticleRepository( FactoryDbContext factoryContext)
        {
            _context = factoryContext.CreateDbContext();
        }
        public async Task<IEnumerable<Article>> GetAllArticlesAsync(int skip,int take)
        {
            using (_context)
            {
                var data = await _context.Articles.Skip(skip).Take(take).Include(y => y.Category).ToListAsync();
                return data;
            }
            
        }

        public async Task<Article> GetArticleByIdentifier(string identifier)
        {
            using (_context)
            {
                var data = await _context.Articles.Where(x => x.Identifier == identifier).Include(y => y.Category).FirstOrDefaultAsync();
                return data;
            }
        }
    }
}
