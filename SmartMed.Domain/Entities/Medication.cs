using System.ComponentModel.DataAnnotations;

namespace SmartMed.Domain.Entities
{
    public class Medication
    { 
        public Guid Id { get; set; }

        [Required]
        [MaxLength(200, ErrorMessage = "Maximum 200 characters allowed for Name")]
        public string Name { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than 0")]
        public int Quantity { get; set; }

        [Required]
        public DateTime CreationDate { get; set; }
    }
}
