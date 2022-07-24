namespace E_Commerce.Models
{
    public class CartProduct
    {
        private long? cartId;
        private long? productId;

        private Cart cart;
        private Product product;

        public long? CartId { get => cartId; set => cartId = value; }
        public long? ProductId { get => productId; set => productId = value; }
        public Cart Cart { get => cart; set => cart = value; }
        public Product Product { get => product; set => product = value; }
    }
}
