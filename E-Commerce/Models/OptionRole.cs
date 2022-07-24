namespace E_Commerce.Models
{
    public class OptionRole : AbstractModel
    {
        private string name;
        private ICollection<Permission> option_roles;

        public string Name { get => name; set => name = value; }
        public ICollection<Permission> Option_roles { get => option_roles; set => option_roles = value; }
       
    }
}
