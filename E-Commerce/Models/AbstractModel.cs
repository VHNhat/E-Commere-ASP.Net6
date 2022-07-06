using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Commerce.Models
{
    public class AbstractModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        private Guid id;
        private DateTime created_date;
        private DateTime modified_date;

        public Guid Id { get => id; set => id = value; }
        public DateTime Created_date { get => created_date; set => created_date = value; }
        public DateTime Modified_date { get => modified_date; set => modified_date = value; }
    }
}
