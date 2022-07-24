namespace E_Commerce.Models
{
    public class SizeCategory : AbstractModel
    {
        private string name;

        private long? organizerId;
        private Organizer organizer;

        private ICollection<Size> sizes;

        public string Name { get => name; set => name = value; }
        public long? OrganizerId { get => organizerId; set => organizerId = value; }
        public Organizer Organizer { get => organizer; set => organizer = value; }
        public ICollection<Size> Sizes { get => sizes; set => sizes = value; }
    }
}
