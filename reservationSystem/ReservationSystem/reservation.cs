namespace ReservationSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;
    using System.Web.Mvc;

    [Table("reservation")]
    public partial class reservation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public reservation()
        {            
            contacts = new HashSet<contact>();
            creditinfoes = new HashSet<creditinfo>();
        }

        [Key]
        public int bId { get; set; }
        [Required]
        [Column(TypeName = "date")]
        [DisplayName("Check-In Date")]
        [CheckInDateValidate]
        public DateTime checkInDate { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [DisplayName("Check-Out Date")]
        [CheckOutDateValidate]
        public DateTime checkOutDate { get; set; }

        [Required]
        [DisplayName("Number of Guests")]
        public int noOfGuest { get; set; }

        [Required]
        [DisplayName("Number of Rooms")]
        public int noOfRooms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contact> contacts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<creditinfo> creditinfoes { get; set; }

        // This property will hold all available states for selection
        public IEnumerable<SelectListItem> counts { get; set; }
    }
}
