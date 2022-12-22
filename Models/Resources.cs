using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace BookingPlatform.Models
{
    public class Resources
    {
        [Key]
        public int ResourceID { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Anzahl")]
        public int Quantity { get; set; }

        [Required]
        [DisplayName("Beschreibung")]
        [MaxLength(200)]
        public string Description { get; set; }

        [NotMapped]
        [DisplayName("Image")]
        public IFormFile ImageFile { get; set; }

        public string? ImageName { get; set; }
        //Relationship
        [ValidateNever]
        public List<Booking> Buchungen { get; set; }

    }
}
