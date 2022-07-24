namespace E_Commerce.Models
{
    public class User : AbstractModel
    {
        private string fullName;
        private int gender;
        private string phone;
        private string avatar;

        private long? accountId;
        private Account account;
        private long? organizerId;
        private Organizer organizer;

        private ICollection<Wishlist> wishlists;
        private ICollection<ReviewProduct> reviews;

        public string FullName { get => fullName; set => fullName = value; }
        public int Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public long? AccountId { get => accountId; set => accountId = value; }
        public Account Account { get => account; set => account = value; }
        public long? OrganizerId { get => organizerId; set => organizerId = value; }
        public Organizer Organizer { get => organizer; set => organizer = value; }
        public ICollection<Wishlist> Wishlists { get => wishlists; set => wishlists = value; }
        public ICollection<ReviewProduct> Reviews { get => reviews; set => reviews = value; }
    }
}
