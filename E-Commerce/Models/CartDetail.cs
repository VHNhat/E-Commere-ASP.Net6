namespace E_Commerce.Models
{
    public class CartDetail
    {
        private long? cartId;
        private long? productDetailId;

        private Cart cart;
        private ProductDetail productDetail;

        public long? CartId { get => cartId; set => cartId = value; }
        public long? ProductDetailId { get => productDetailId; set => productDetailId = value; }
        public Cart Cart { get => cart; set => cart = value; }
        public ProductDetail ProductDetail { get => productDetail; set => productDetail = value; }
    }
}
