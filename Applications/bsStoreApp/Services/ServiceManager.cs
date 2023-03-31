using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        public IBookService BookService => _bookService.Value;
        private readonly Lazy<IBookService> _bookService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger)
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, logger));
        }
    }
}
