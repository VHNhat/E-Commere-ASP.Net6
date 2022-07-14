namespace E_Commerce.Models
{
    public class ProductType : AbstractModel
    {
        private string name;
        private string description;

        private ICollection<Product> products;
        private string photo;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public ICollection<Product> Products { get => products; set => products = value; }
        public string Photo { get => photo; set => photo = value; }
    }
}
