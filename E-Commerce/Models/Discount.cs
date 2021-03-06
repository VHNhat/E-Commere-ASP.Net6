namespace E_Commerce.Models
{
    public class Discount : AbstractModel
    {
        private string code;
        private string name;
        private int quantity;
        private DateTime expiredAt;
        private double value;
        private ICollection<Product> products;
        private DiscountValue discountValue;
        private long? valueId;
        private string photo;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public DateTime ExpiredAt { get => expiredAt; set => expiredAt = value; }
        public ICollection<Product> Products { get => products; set => products = value; }
        public DiscountValue DiscountValue { get => discountValue; set => this.discountValue = value; }
        public long? ValueId { get => valueId; set => valueId = value; }
        public string Photo { get => photo; set => photo = value; }
        public double Value1 { get => value; set => this.value = value; }
    }
}
