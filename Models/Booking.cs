using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingPlatform.Models
{
    public class Booking
    {
        //BuchungsNr wird automatisch genariert(Auto_Increment) : Jede Buchung hat eine unique Nummer
        [Key]
        [DisplayName("Booking ID")]
        public int BookingID { get; set; }

        //Wird von text box in Login-Seite in runtime gespeichert, wenn Ldap der Login autorisiert.
        //Wenn eine Buchung gemacht wird, wird dann in der Buchung Tabelle in der DB gespeichert.
        [Required]
        [DisplayName("Matrikelnummer")]
        public string MatrikelNr { get; set; }

        //Man legt das fest,wenn man bucht
        [DisplayName("Reservierungsdatum")]
        public DateTime StartDate { get; set; }

        [DisplayName("Rückgabedatum")]
        public DateTime EndDate { get; set; }

        //immer falsch bis des Ablaufsdatum überschritten wird
        public bool WarningEmailState { get; set; }

        //Zustand
        // bei einer neuen Buchung fängt =reserviert an
        // -> wenn abgeholt, dann =gebucht
        // -> wenn zurückgegeben, dann =zurückgegeben
        // -> wenn nicht zurückgegeben, Ablaufsdatum überschritten und gebucht, dann =abgelaufen
        [DisplayName("Buchungszustand")]
        public string BookingCondition { get; set; }

        //Relationship
        [DisplayName("Ressource ID")]
        public int ResourceID { get; set; }
        [ForeignKey("ResourceID")]
        [ValidateNever]
        public Resources Resource { get; set; }

    }
}
