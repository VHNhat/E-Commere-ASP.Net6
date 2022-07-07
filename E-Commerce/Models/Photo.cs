using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Photo : AbstractModel
    {
        private string url;

        public string Url { get => url; set => url = value; }
    }
}
