using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Photo : AbstractModel
    {
        private string url;
        private long productId;
        private Product product;
        public string Url { get => url; set => url = value; }
        public long ProductId { get => productId; set => productId = value; }
        public Product Product { get => product; set => product = value; }
    }
}
