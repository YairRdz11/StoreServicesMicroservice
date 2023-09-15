namespace StoreService.Api.ShoppingCart.Application
{
    public class ShoppingDetailDTO
    {
        public Guid? BookId { get; set; }
        public string TitleBook { get; set; }
        public string AutorBook { get; set; }
        public DateTime? PublishDate { get; set; }
    }
}
