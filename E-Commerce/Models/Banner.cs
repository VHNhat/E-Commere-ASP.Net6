namespace E_Commerce.Models
{
    public class Banner : AbstractModel
    {
        private string title;
        private string description;
        private string photo;
        private string status;

        public string Title { get => title; set => title = value; }
        public string Description { get => description; set => description = value; }
        public string Photo { get => photo; set => photo = value; }
        public string Status { get => status; set => status = value; }
    }
}
