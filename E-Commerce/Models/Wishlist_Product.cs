namespace E_Commerce.Models
{
    public class Wishlist_Product
    {
        private long? wishlistId;
        private long? productId;
        private DateTime createdAt;
        private DateTime lastModifiedAt;

        private Wishlist wishlist;
        private Product product;

        public long? WishlistId { get => wishlistId; set => wishlistId = value; }
        public long? ProductId { get => productId; set => productId = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public DateTime LastModifiedAt { get => lastModifiedAt; set => lastModifiedAt = value; }
        public Wishlist Wishlist { get => wishlist; set => wishlist = value; }
        public Product Product { get => product; set => product = value; }
    }
}
