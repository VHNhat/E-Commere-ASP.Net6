namespace E_Commerce.Models
{
    public class Notification : AbstractModel
    {
        private string title;
        private string content;
        private string type;
        private string status;        
        private DateTime readAt;

        public string Title { get => title; set => title = value; }
        public string Content { get => content; set => content = value; }
        public string Type { get => type; set => type = value; }
        public string Status { get => status; set => status = value; }
        public DateTime ReadAt { get => readAt; set => readAt = value; }
    }
}
