namespace StoreService.Api.ShoppingCart.RemoteModel
{
    public class RemoteBook
    {
        public Guid? LibraryId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid AutorBook { get; set; }
    }
}
