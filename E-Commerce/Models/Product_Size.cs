namespace E_Commerce.Models
{
    public class Product_Size
    {
        private Guid productId;
        private Guid sizeId;
        private DateTime createdAt;
        private DateTime lastModifiedAt;

        private Product product;
        private ProductSize size;

        public Guid ProductId { get => productId; set => productId = value; }
        public Guid SizeId { get => sizeId; set => sizeId = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public DateTime LastModifiedAt { get => lastModifiedAt; set => lastModifiedAt = value; }
        public Product Product { get => product; set => product = value; }
        public ProductSize Size { get => size; set => size = value; }
    }
}
