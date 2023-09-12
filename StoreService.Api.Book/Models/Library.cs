namespace StoreService.Api.Book.Models
{
    public class Library
    {
        public Guid? LibraryId { get; set; }
        public string Title { get; set; }
        public DateTime PublishDate { get; set; }
        public Guid AutorBook { get; set; }
    }
}
