namespace E_Commerce.Models
{
    public class Role : AbstractModel
    {
        private string name;
        private ICollection<Permission> option_roles;
        private ICollection<Account> accounts;

        public string Name { get => name; set => name = value; }
        public ICollection<Permission> Option_roles { get => option_roles; set => option_roles = value; }
        public ICollection<Account> Accounts { get => accounts; set => accounts = value; }
    }
}
