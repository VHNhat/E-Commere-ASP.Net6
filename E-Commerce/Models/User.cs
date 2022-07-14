namespace E_Commerce.Models
{
    public class User : AbstractModel
    {
        private string name;
        private int gender;
        private string phone;
        private Account account;
        private long? accountId;
        private Store store;
        private long? storeId;
        private string photo;

        public string Name { get => name; set => name = value; }
        public int Gender { get => gender; set => gender = value; }
        public string Phone { get => phone; set => phone = value; }
        public Account Account { get => account; set => account = value; }
        public long? AccountId { get => accountId; set => accountId = value; }
        public Store Store { get => store; set => store = value; }
        public long? StoreId { get => storeId; set => storeId = value; }
        public string Photo { get => photo; set => photo = value; }
    }
}
