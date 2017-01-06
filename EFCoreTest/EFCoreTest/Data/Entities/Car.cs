namespace EFCoreTest.Data.Entities
{
    public class Car : BaseEntity
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int ProductionYear { get; set; }

        public int HorsePower { get; set; }

        public Owner Owner { get; set; }

        public int OwnerId { get; set; }
    }
}