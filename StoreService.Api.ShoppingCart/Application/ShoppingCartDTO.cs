﻿namespace StoreService.Api.ShoppingCart.Application
{
    public class ShoppingCartDTO
    {
        public int ShoppingCartId { get; set; }
        public DateTime? CreatedDateSession { get; set; }
        public ICollection<ShoppingDetailDTO>? Items { get; set; }
    }
}
