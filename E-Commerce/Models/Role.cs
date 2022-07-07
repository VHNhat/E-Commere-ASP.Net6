namespace E_Commerce.Models
{
    public class Role : AbstractModel
    {
        private string name;
        private ICollection<Option_Role> option_roles;
        private ICollection<Account> accounts;

        public string Name { get => name; set => name = value; }
        public ICollection<Option_Role> Option_roles { get => option_roles; set => option_roles = value; }
        public ICollection<Account> Accounts { get => accounts; set => accounts = value; }
    }
}
