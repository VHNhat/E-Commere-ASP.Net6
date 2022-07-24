namespace E_Commerce.Models
{
    public class DiscountType : AbstractModel
    {
        private string name;
        private string type;
        private string status;

        private ICollection<Discount> discounts;

        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public ICollection<Discount> Discounts { get => discounts; set => discounts = value; }
        public string Status { get => status; set => status = value; }
    }
}
