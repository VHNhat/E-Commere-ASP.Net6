namespace E_Commerce.Models
{
    public class Store : AbstractModel
    {
        private string name;
        private string address;
        private string map;
        private string photoURL;
        private string detail;

        private ICollection<Product> products;
        private ICollection<User> users;

        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Map { get => map; set => map = value; }
        public string PhotoURL { get => photoURL; set => photoURL = value; }
        public string Detail { get => detail; set => detail = value; }
        public ICollection<Product> Products { get => products; set => products = value; }
        public ICollection<User> Users { get => users; set => users = value; }
    }
}
