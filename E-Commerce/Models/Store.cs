namespace E_Commerce.Models
{
    public class Store : AbstractModel
    {
        private string name;
        private string address;
        private string map;
        private string detail;

        private ICollection<Product_Store> product_stores;
        private ICollection<User> users;
        private ICollection<Photo> photos;

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Map { get => map; set => map = value; }
        public string Detail { get => detail; set => detail = value; }
        public ICollection<Product_Store> Product_stores { get => product_stores; set => product_stores = value; }
        public ICollection<User> Users { get => users; set => users = value; }
        public ICollection<Photo> Photos { get => photos; set => photos = value; }
    }
}
