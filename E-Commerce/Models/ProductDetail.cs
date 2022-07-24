using E_Commerce.Utility.Status;

namespace E_Commerce.Models
{
    public class ProductDetail : AbstractModel
    {
        private long? productId;
        private long? productCategoryId;
        private long? sizeId;
        private long? discountId;

        private int quantity;
        private double price;
        private string status;
        private string photo;

        private Product product;
        private ProductCategory productCategory;
        private Size productSize;
        private Discount discount;

        private ICollection<CartDetail> cartDetails;

        public long? ProductId { get => productId; set => productId = value; }
        public long? ProductVarianceId { get => productCategoryId; set => productCategoryId = value; }
        public long? SizeId { get => sizeId; set => sizeId = value; }
        public long? DiscountId { get => discountId; set => discountId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public string Status { get => status; set => status = value; }
        public string Photo { get => photo; set => photo = value; }
        public Product Product { get => product; set => product = value; }
        public ProductCategory ProductVariance { get => productCategory; set => productCategory = value; }
        public Size ProductSize { get => productSize; set => productSize = value; }
        public Discount Discount { get => discount; set => discount = value; }
        public ICollection<CartDetail> CartDetails { get => cartDetails; set => cartDetails = value; }
    }
}
