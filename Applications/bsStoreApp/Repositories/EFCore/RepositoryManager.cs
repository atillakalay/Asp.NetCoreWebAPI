using Repositories.Contracts;

namespace Repositories.EFCore
{
    public class RepositoryManager : IRepositoryManager
    {

        private readonly RepositoryContext _context;
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;

        public RepositoryManager(RepositoryContext context,
            IBookRepository bookRepository,
            ICategoryRepository categoryRepository)
        {
            _context = context;
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;
        }

        public IBookRepository Book => _bookRepository;

        public ICategoryRepository Category => _categoryRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}