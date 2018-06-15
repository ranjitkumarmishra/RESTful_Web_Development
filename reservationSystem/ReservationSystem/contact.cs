namespace ReservationSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.ComponentModel;

    [Table("contact")]
    public partial class contact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public contact()
        {
            creditinfoes = new HashSet<creditinfo>();
        }

        [Key]
        public int cId { get; set; }

        public int bId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Last Name")]
        [RegularExpression(@"^[^;:!@#$%^*+?\\/<>0-9]+$", ErrorMessage ="Invalid Last Name")]
        
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("First Name")]
        [RegularExpression(@"^[^;:!@#$%^*+?\\/<>0-9]+$", ErrorMessage = "Invalid First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Street Number")]
        public string StreetNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("City:")]
        [RegularExpression(@"^[^;:!@#$%^*+?\\/<>0-9]+$", ErrorMessage = "Invalid City Name")]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Province")]
        [RegularExpression(@"^[^;:!@#$%^*+?\\/<>0-9]+$", ErrorMessage = "Invalid Province/State Name")]
        public string Province { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Country")]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.PostalCode)]
        [DisplayName("Postal Code")]
        [PostalValidate]
        public string PostalCode { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
       // [RegularExpression(@"^((1-)?\d{3}-)?\d{3}-\d{4}$", ErrorMessage = "Invalid Phone Number")]
        [RegularExpression(@"^[01]?[- .]?(\([2-9]\d{2}\)|[2-9]\d{2})[- .]?\d{3}[- .]?\d{4}$", ErrorMessage = "Invalid Phone Number")]
        
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$", ErrorMessage = "E-mail is not valid")]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        public virtual reservation reservation { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<creditinfo> creditinfoes { get; set; }
    }
}
