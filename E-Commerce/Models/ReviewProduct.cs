namespace E_Commerce.Models
{
    public class ReviewProduct : AbstractModel
    {
        private long? userId;
        private User user;
        private long? productId;
        private Product product;
        private long? productVarianceId;
        private ProductVariance productVariance;
        private long? organizerId;
        private Organizer organizer;

        private double rating;
        private string comment;
        private string photo;
        private long? parentId;

        public long? UserId { get => userId; set => userId = value; }
        public User User { get => user; set => user = value; }
        public long? ProductId { get => productId; set => productId = value; }
        public Product Product { get => product; set => product = value; }
        public long? ProductVarianceId { get => productVarianceId; set => productVarianceId = value; }
        public ProductVariance ProductVariance { get => productVariance; set => productVariance = value; }
        public long? OrganizerId { get => organizerId; set => organizerId = value; }
        public Organizer Organizer { get => organizer; set => organizer = value; }
        public double Rating { get => rating; set => rating = value; }
        public string Comment { get => comment; set => comment = value; }
        public string Photo { get => photo; set => photo = value; }
        public long? ParentId { get => parentId; set => parentId = value; }
    }
}
