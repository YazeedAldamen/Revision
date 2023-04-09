namespace DataLayer.Repositories
{
    public interface IUnitOfWorkRepository : IDisposable
    {
        ICategoryRepository _CategoryRepository { get; }
        IArticleRepository _ArticleRepository { get; }

        //ICategoryRepository GetCategoryRepository();
        //IArticleRepository GetArticleRepository();
    }

    public class UnitOfWork : IUnitOfWorkRepository
    {
        private readonly RevisionDbContext _context;
        private ICategoryRepository _categoryRepository;
        private IArticleRepository _articleRepository;

       

        public UnitOfWork(RevisionDbContext context, ICategoryRepository categoryRepository, IArticleRepository articleRepository)
        {
            _context = context;
            _categoryRepository = categoryRepository;
            _articleRepository = articleRepository;
        }


        public ICategoryRepository _CategoryRepository { get { return _categoryRepository; } }
        public IArticleRepository _ArticleRepository { get { return _articleRepository; } }

        //public ICategoryRepository GetCategoryRepository()
        //{
        //    return _categoryRepository;
        //}

        //public IArticleRepository GetArticleRepository()
        //{
        //    return _articleRepository;
        //}

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
