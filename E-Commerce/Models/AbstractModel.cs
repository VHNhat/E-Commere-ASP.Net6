using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class AbstractModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        private Guid id;
        private DateTime createdAt;
        private DateTime lastModifiedAt;

        public Guid Id { get => id; set => id = value; }
        public DateTime CreatedAt { get => createdAt; set => createdAt = value; }
        public DateTime LastModifiedAt { get => lastModifiedAt; set => lastModifiedAt = value; }
    }
}
