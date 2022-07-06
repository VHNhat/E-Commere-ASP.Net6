namespace E_Commerce.Models
{
    public class ProductSize : AbstractModel
    {
        private string name;
        private string value;

        private ICollection<Product_Size> product_sizes;

        public string Name { get => name; set => name = value; }
        public string Value { get => value; set => this.value = value; }
        public ICollection<Product_Size> Product_sizes { get => product_sizes; set => product_sizes = value; }
    }
}
