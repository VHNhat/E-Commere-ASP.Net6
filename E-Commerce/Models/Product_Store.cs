namespace E_Commerce.Models
{
    public class Product_Store
    {
        private long? storeId;
        private long? productId;
        private DateTime createdAt;
        private DateTime lastModifiedAt;

        private Store store;
        private Product product;

        public long? StoreId { get => storeId; set => storeId = value; }
        public long? ProductId { get => productId; set => productId = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public DateTime LastModifiedAt { get => lastModifiedAt; set => lastModifiedAt = value; }
        public Store Store { get => store; set => store = value; }
        public Product Product { get => product; set => product = value; }
    }
}
