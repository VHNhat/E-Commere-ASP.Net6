namespace E_Commerce.Models
{
    public class ReviewProduct : AbstractModel
    {
        private int like;
        private int dislike;
        private string comment;

        private Product product;
        private long? productId;

        public int Dislike { get => dislike; set => dislike = value; }
        public string Comment { get => comment; set => comment = value; }
        public Product Product { get => product; set => product = value; }
        public long? ProductId { get => productId; set => productId = value; }
        public int Like { get => like; set => like = value; }
    }
}
