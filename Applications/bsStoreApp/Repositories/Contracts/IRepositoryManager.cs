namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICategoryRepository Category { get; }
        IBookRepository Book { get; }
        Task SaveAsync();
    }
}