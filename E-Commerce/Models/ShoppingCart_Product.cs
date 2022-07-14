namespace E_Commerce.Models
{
    public class ShoppingCart_Product
    {
        private long? shoppingCartId;
        private long? productId;
        private DateTime createdDate;
        private string tilteSize;
        private int count;
        

        private ShoppingCart shoppingCart;

        private Product product;

        public long? ShoppingCartId { get => shoppingCartId; set => shoppingCartId = value; }
        public long? ProductId { get => productId; set => productId = value; }
        public DateTime CreatedDate { get => createdDate; set => createdDate = value; }
        public string TilteSize { get => tilteSize; set => tilteSize = value; }
        public int Count { get => count; set => count = value; }
        public ShoppingCart ShoppingCart { get => shoppingCart; set => shoppingCart = value; }
        public Product Product { get => product; set => product = value; }
    }
}
