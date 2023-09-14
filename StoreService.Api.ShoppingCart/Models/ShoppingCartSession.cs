namespace StoreService.Api.ShoppingCart.Models
{
    public class ShoppingCartSession
    {
        public int ShoppingCartSessionId { get; set; }
        public DateTime? CreatedAt { get; set; }

        public ICollection<ShoppingCartSessionDetail> Details { get; set; }
    }
}
