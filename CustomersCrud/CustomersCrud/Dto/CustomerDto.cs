using CustomersCrud.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace CustomersCrud.Dto
{
    public class CustomerDto : Customer
    {
        [Required]
        public new string Name { get; set; }

        [Required]
        public new string Surname { get; set; }

        [StringLength(9)]
        [Required]
        public new string Phone { get; set; }
    }
}
