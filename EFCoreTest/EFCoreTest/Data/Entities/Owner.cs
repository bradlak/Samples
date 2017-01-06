using System.Collections.Generic;

namespace EFCoreTest.Data.Entities
{
    public class Owner : BaseEntity
    {
        public Owner()
        {       
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}