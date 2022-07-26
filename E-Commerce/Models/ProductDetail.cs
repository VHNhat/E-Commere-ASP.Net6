using E_Commerce.Utility.Status;

namespace E_Commerce.Models
{
    public class ProductDetail
    {
        private long? productId;
        private long? productVarianceId;
        private long? sizeId;
        private long? discountId;

        private int quantity;
        private double price;
        private string status;
        private string photo;
        private DateTime createdAt;
        private DateTime lastModifiedAt;

        private Product product;
        private ProductVariance productVariance;
        private Size productSize;
        private Discount discount;

        private ICollection<CartProduct> cartDetails;

        public long? ProductId { get => productId; set => productId = value; }
        public long? ProductVarianceId { get => productVarianceId; set => productVarianceId = value; }
        public long? SizeId { get => sizeId; set => sizeId = value; }
        public long? DiscountId { get => discountId; set => discountId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Price { get => price; set => price = value; }
        public string Status { get => status; set => status = value; }
        public string Photo { get => photo; set => photo = value; }
        public Product Product { get => product; set => product = value; }
        public ProductVariance ProductVariance { get => productVariance; set => productVariance = value; }
        public Size ProductSize { get => productSize; set => productSize = value; }
        public Discount Discount { get => discount; set => discount = value; }
        public ICollection<CartProduct> CartDetails { get => cartDetails; set => cartDetails = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public DateTime LastModifiedAt { get => lastModifiedAt; set => lastModifiedAt = value; }
    }
}
