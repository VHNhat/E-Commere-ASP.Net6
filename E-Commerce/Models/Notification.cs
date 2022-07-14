namespace E_Commerce.Models
{
    public class Notification : AbstractModel
    {
        private string name;
        private string content;
        private bool isActive;

        public string Name { get => name; set => name = value; }
        public string Content { get => content; set => content = value; }
        public bool IsActive { get => isActive; set => isActive = value; }
    }
}
