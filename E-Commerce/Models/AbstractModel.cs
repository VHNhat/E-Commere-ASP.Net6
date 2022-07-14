using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class AbstractModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        private long id;
        private DateTime createdAt = DateTime.Now;
        private DateTime lastModifiedAt = DateTime.Now;

        public long Id { get => id; set => id = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public DateTime LastModifiedAt { get => lastModifiedAt; set => lastModifiedAt = value; }
    }
}
