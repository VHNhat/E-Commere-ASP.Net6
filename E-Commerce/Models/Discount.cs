namespace E_Commerce.Models
{
    public class Discount : AbstractModel
    {
        private string code;
        private string name;
        private int quantity;
        private DateTime expiredAt;
        private ICollection<Product> products;
        private DiscountValue value;
        private Guid? valueId;
        private ICollection<Photo> photos;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime ExpiredAt { get => expiredAt; set => expiredAt = value; }
        public ICollection<Product> Products { get => products; set => products = value; }
        public DiscountValue Value { get => value; set => this.value = value; }
        public Guid? ValueId { get => valueId; set => valueId = value; }
        public ICollection<Photo> Photos { get => photos; set => photos = value; }
    }
}
