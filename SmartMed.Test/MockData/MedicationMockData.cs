using SmartMed.Domain.Entities;

namespace SmartMed.Test.MockData
{
    public class MedicationMockData
    {
        public static List<Medication> Get()
        {
            return new List<Medication>
            {
                new Medication
                {
                    Id = new Guid(),
                    Name = "Med 1",
                    Quantity = 5,
                    CreationDate = DateTime.Now
                },
                new Medication
                {
                    Id = new Guid(),
                    Name = "Med 2",
                    Quantity = 10,
                    CreationDate = DateTime.Now
                },
                new Medication
                {
                    Id = new Guid(),
                    Name = "Med 3",
                    Quantity = 20,
                    CreationDate = DateTime.Now
                }
            };
        }

        public static List<Medication> GetEmpty()
        {
            return new List<Medication>();
        }

        public static Medication GetMedication()
        {
            return new Medication
            {
                Id = new Guid(),
                Name = "Med 1",
                Quantity = 5,
                CreationDate = DateTime.Now
            };
        }
    }
}
