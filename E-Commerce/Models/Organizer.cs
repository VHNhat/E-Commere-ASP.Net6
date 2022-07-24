namespace E_Commerce.Models
{
    public class Organizer : AbstractModel
    {
        private string name;
        private string phone;
        private string email;
        private string address;
        private string detail;
        private bool isCompany;
        private string photo;

        private User user;
        private long? userId;

        private ICollection<Voucher> vouchers;
        private ICollection<Discount> discounts;
        private ICollection<ProductCategory> productCategories;
        private ICollection<Product> products;
        private ICollection<ProductVariance> productVariances;
        private ICollection<ReviewProduct> reviews;

        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Email { get => email; set => email = value; }
        public string Address { get => address; set => address = value; }
        public string Detail { get => detail; set => detail = value; }
        public bool IsCompany { get => isCompany; set => isCompany = value; }
        public string Photo { get => photo; set => photo = value; }
        public User User { get => user; set => user = value; }
        public long? UserId { get => userId; set => userId = value; }
        public ICollection<Voucher> Vouchers { get => vouchers; set => vouchers = value; }
        public ICollection<Discount> Discounts { get => discounts; set => discounts = value; }
        public ICollection<ProductCategory> ProductCategories { get => productCategories; set => productCategories = value; }
        public ICollection<Product> Products { get => products; set => products = value; }
        public ICollection<ProductVariance> ProductVariances { get => productVariances; set => productVariances = value; }
        public ICollection<ReviewProduct> Reviews { get => reviews; set => reviews = value; }
    }
}