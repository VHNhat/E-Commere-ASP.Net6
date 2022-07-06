namespace E_Commerce.Models
{
    public class Discount : AbstractModel
    {
        private string code;
        private string name;
        private int qunatity;
        private DateTime expiredAt;
        private ICollection<Product> products;
        private DiscountValue value;
        private Guid valueId;

        public string Code { get => code; set => code = value; }
        public string Name { get => name; set => name = value; }
        public int Qunatity { get => qunatity; set => qunatity = value; }
        public DateTime ExpiredAt { get => expiredAt; set => expiredAt = value; }
        public ICollection<Product> Products { get => products; set => products = value; }
        public DiscountValue Value { get => value; set => this.value = value; }
        public Guid ValueId { get => valueId; set => valueId = value; }
    }
}
