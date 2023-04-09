using Microsoft.EntityFrameworkCore;
using Mysqlx.Expr;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllCategoriesAsync(int skip, int take);
        public Task<Category> GetCategoryByIdentifier(string identifier);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RevisionDbContext _context;
        private readonly FactoryDbContext _factoryDbContext;

        public CategoryRepository(FactoryDbContext factoryDbContext)
        {
            _context = factoryDbContext.CreateDbContext();
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(int skip, int take)
        {
            using (_context)
            {
                var data = await _context.Categories.Skip(skip).Take(take).Include(y => y.Articles).ToListAsync();

                return data;
            }
           
        }

        public async Task<Category> GetCategoryByIdentifier(string identifier)
        {
            using (_context)
            {
                var data = await _context.Categories.Where(x => x.Identifier == identifier).Include(c => c.Articles).FirstOrDefaultAsync();
                return data;
            }
        }
    }
}
