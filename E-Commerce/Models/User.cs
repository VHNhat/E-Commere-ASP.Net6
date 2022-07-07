namespace E_Commerce.Models
{
    public class User : AbstractModel
    {
        private string name;
        private int gender;
        private string phone;
        private Account account;
        private Guid? accountId;
        private Store store;
        private Guid? storeId;
        private ICollection<Photo> photos;

        public string Name { get => name; set => name = value; }
        public int Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public Account Account { get => account; set => account = value; }
        public Guid? AccountId { get => accountId; set => accountId = value; }
        public Store Store { get => store; set => store = value; }
        public Guid? StoreId { get => storeId; set => storeId = value; }
        public ICollection<Photo> Photos { get => photos; set => photos = value; }
    }
}
