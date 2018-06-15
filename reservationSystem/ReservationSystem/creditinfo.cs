namespace ReservationSystem
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("creditinfo")]
    public partial class creditinfo
    {
        public int cId { get; set; }

        [Key]
        public int creditId { get; set; }

        public int bId { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Card Type")]
        public string cardType { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Name on Credit Card")]
        [RegularExpression(@"^[^;:!@#$%^*+?\\/<>0-9]+$", ErrorMessage = "Invalid Name")]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Credit Card Number")]
        [CreditCardValidation]
        [DisplayFormat(DataFormatString = "^4[0-9]{12}(?:[0-9]{3})?$")]
        public string cardNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Empty Character not allowed")]
        [Column(TypeName = "date")]
        [DisplayName("Expiration Date")]
        [CheckInDateValidate]
        public DateTime expDate { get; set; }

        public virtual contact contact { get; set; }

        public virtual reservation reservation { get; set; }
    }
}
