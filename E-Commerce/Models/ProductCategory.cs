using E_Commerce.Utility.Status;

namespace E_Commerce.Models
{
    public class ProductCategory : AbstractModel
    {
        private string name;
        private string photo;
        private string description;
        private string status;
        private int addBy;
        private bool isParent;
        private long? parentId;

        private long? organizerId;
        private Organizer organizer;

        private ICollection<Product> products;

        public string Name { get => name; set => name = value; }
        public string Photo { get => photo; set => photo = value; }
        public string Description { get => description; set => description = value; }
        public string Status { get => status; set => status = value; }
        public int AddBy { get => addBy; set => addBy = value; }
        public bool IsParent { get => isParent; set => isParent = value; }
        public long? ParentId { get => parentId; set => parentId = value; }
        public long? OrganizerId { get => organizerId; set => organizerId = value; }
        public Organizer Organizer { get => organizer; set => organizer = value; }
        public ICollection<Product> Products { get => products; set => products = value; }
    }
}
