namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IBookRepository BookRepository { get; }
        void Save();
    }
}
