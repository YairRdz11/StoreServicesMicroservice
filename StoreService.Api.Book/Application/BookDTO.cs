namespace StoreService.Api.Book.Application
{
    public class BookDTO
    {
        public Guid? LibraryId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid AutorBook { get; set; }
    }
}
