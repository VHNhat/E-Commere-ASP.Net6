namespace E_Commerce.Models
{
    public class Wishlist : AbstractModel
    {
        private double price;

        private long? userId;
        private User user;

        private ICollection<Wishlist_Product> wishlist_Products;

        public double Price { get => price; set => price = value; }
        public long? UserId { get => userId; set => userId = value; }
        public User User { get => user; set => user = value; }
        public ICollection<Wishlist_Product> Wishlist_Products { get => wishlist_Products; set => wishlist_Products = value; }
    }
}
