namespace E_Commerce.Models
{
    public class Banner : AbstractModel
    {
        private string name;
        private string description;
        private string photo;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Photo { get => photo; set => photo = value; }
    }
}
