using System.ComponentModel.DataAnnotations;

namespace CustomersCrud.Data.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [StringLength(9)]
        [Required]
        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
