namespace E_Commerce.Models
{
    public class ProductBrand : AbstractModel
    {
        private string name;
        private string description;

        private ICollection<Product> products;
        private ICollection<Photo> photos;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public ICollection<Product> Products { get => products; set => products = value; }
        public ICollection<Photo> Photos { get => photos; set => photos = value; }
    }
}
