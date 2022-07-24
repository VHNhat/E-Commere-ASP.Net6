namespace E_Commerce.Models
{
    public class Size : AbstractModel
    {
        private string name;
        private string value;
        private string status;

        private long? sizeCategoryId;
        private SizeCategory sizeCategory;

        private ICollection<ProductDetail> productDetails;

        public string Name { get => name; set => name = value; }
        public string Value { get => value; set => this.value = value; }
        public string Status { get => status; set => status = value; }
        public long? SizeCategoryId { get => sizeCategoryId; set => sizeCategoryId = value; }
        public SizeCategory SizeCategory { get => sizeCategory; set => sizeCategory = value; }
        public ICollection<ProductDetail> ProductDetails { get => productDetails; set => productDetails = value; }
    }
}
