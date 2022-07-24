namespace E_Commerce.Models
{
    public class ProductVariance : AbstractModel
    {
        private string name;
        private string description;
        private string photo;
        private string status;

        private long? organizerId;
        private Organizer organizer;
        private long? productId;
        private Product product;

        private ICollection<ReviewProduct> reviews;
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Photo { get => photo; set => photo = value; }
        public string Status { get => status; set => status = value; }
        public long? OrganizerId { get => organizerId; set => organizerId = value; }
        public Organizer Organizer { get => organizer; set => organizer = value; }
        public long? ProductId { get => productId; set => productId = value; }
        public Product Product { get => product; set => product = value; }
        public ICollection<ReviewProduct> Reviews { get => reviews; set => reviews = value; }
    }
}
