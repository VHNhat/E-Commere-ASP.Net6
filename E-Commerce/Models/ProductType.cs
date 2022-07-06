namespace E_Commerce.Models
{
    public class ProductType : AbstractModel
    {
        private string name;
        private string description;
        private string photoURL;

        private ICollection<Product> products;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string PhotoURL { get => photoURL; set => photoURL = value; }
        public ICollection<Product> Products { get => products; set => products = value; }
    }
}
