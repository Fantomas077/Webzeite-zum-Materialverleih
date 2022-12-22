using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingPlatform.Models
{
    public class Admin
    {
        [Key]
        [DisplayName("Admin ID")]
        public string AdminID { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Erstellungsdatum")]
        public DateTime DateJoined { get; set; }= DateTime.Now;
    }
}
