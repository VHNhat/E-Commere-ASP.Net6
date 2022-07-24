namespace E_Commerce.Models
{
    public class Discount : AbstractModel
    {
        private string code;
        private string title;
        private string status;
        private string photo;
        private int quantity;
        private double value;
        private DateTime expiredAt;

        private long? typeId;
        private DiscountType discountType;
        private long? organizerId;
        private Organizer organizer;

        private ICollection<Product> products;
        private ICollection<ProductDetail> productDetails;

        public string Code { get => code; set => code = value; }
        public string Title { get => title; set => title = value; }
        public string Status { get => status; set => status = value; }
        public string Photo { get => photo; set => photo = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public double Value { get => value; set => this.value = value; }
        public DateTime ExpiredAt { get => expiredAt; set => expiredAt = value; }
        public long? TypeId { get => typeId; set => typeId = value; }
        public DiscountType DiscountType { get => discountType; set => discountType = value; }
        public long? OrganizerId { get => organizerId; set => organizerId = value; }
        public Organizer Organizer { get => organizer; set => organizer = value; }
        public ICollection<Product> Products { get => products; set => products = value; }
        public ICollection<ProductDetail> ProductDetails { get => productDetails; set => productDetails = value; }
    }
}
