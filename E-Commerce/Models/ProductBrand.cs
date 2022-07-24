namespace E_Commerce.Models
{
    public class ProductBrand : AbstractModel
    {
        private string name;
        private string description;
        private string status;
        private string photo;

        private long? organizerId;
        private Organizer organizer;

        private ICollection<Product> products;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Status { get => status; set => status = value; }
        public string Photo { get => photo; set => photo = value; }
        public long? OrganizerId { get => organizerId; set => organizerId = value; }
        public Organizer Organizer { get => organizer; set => organizer = value; }
        public ICollection<Product> Products { get => products; set => products = value; }
    }
}
