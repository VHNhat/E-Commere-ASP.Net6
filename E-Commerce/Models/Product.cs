using E_Commerce.Utility.Status;

namespace E_Commerce.Models
{
    public class Product : AbstractModel
    {
        private string name;
        private string decription;
        private string status;
        private int gender;

        private long? brandId;
        private ProductBrand brand;
        private long? categoryId;
        private ProductCategory category;
        /*private long? subCategoryId;
        private ProductCategory subCategory;*/
        private long? organizerId;
        private Organizer organizer;

        private ICollection<ProductVariance> variances;
        private ICollection<Photo> photos;
        private ICollection<Cart> carts;
        private ICollection<ReviewProduct> reviews;
        private ICollection<Wishlist_Product> wishlist_Products;
        private ICollection<ProductDetail> productDetails;
        private ICollection<CartProduct> cartProducts;

        public string Name { get => name; set => name = value; }
        public string Decription { get => decription; set => decription = value; }
        public string Status { get => status; set => status = value; }
        public int Gender { get => gender; set => gender = value; }
        public long? BrandId { get => brandId; set => brandId = value; }
        public ProductBrand Brand { get => brand; set => brand = value; }
        public long? CategoryId { get => categoryId; set => categoryId = value; }
        public ProductCategory Category { get => category; set => category = value; }
        /*public long? SubCategoryId { get => subCategoryId; set => subCategoryId = value; }
        public ProductCategory SubCategory { get => subCategory; set => subCategory = value; }*/
        public long? OrganizerId { get => organizerId; set => organizerId = value; }
        public Organizer Organizer { get => organizer; set => organizer = value; }
        public ICollection<ProductVariance> Variances { get => variances; set => variances = value; }
        public ICollection<Photo> Photos { get => photos; set => photos = value; }
        public ICollection<Cart> Carts { get => carts; set => carts = value; }
        public ICollection<ReviewProduct> Reviews { get => reviews; set => reviews = value; }
        public ICollection<Wishlist_Product> Wishlist_Products { get => wishlist_Products; set => wishlist_Products = value; }
        public ICollection<ProductDetail> ProductDetails { get => productDetails; set => productDetails = value; }
        public ICollection<CartProduct> CartProducts { get => cartProducts; set => cartProducts = value; }
    }
}
