using StoreService.Api.ShoppingCart.RemoteModel;

namespace StoreService.Api.ShoppingCart.RemoteInterfaces
{
    public interface IBookService
    {
        Task<(bool result, RemoteBook? remoteBook, string? errorMessage)> GetBook(Guid bookId);
    }
}
