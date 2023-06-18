namespace Services.Contracts
{
    public interface IServiceManager
    {
        IBookService BookService { get; }
        ICategoryService CategoryService { get; }
        IAuthenticationService AuthenticationService { get; }
    }
}
