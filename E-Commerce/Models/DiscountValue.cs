namespace E_Commerce.Models
{
    public class DiscountValue : AbstractModel
    {
        private string name;
        private string type;

        private ICollection<Discount> discounts;

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public ICollection<Discount> Discounts { get => discounts; set => discounts = value; }
    }
}
