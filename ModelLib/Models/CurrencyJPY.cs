namespace ModelLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CurrencyJPY")]
    public partial class CurrencyJPY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte CId { get; set; }

        [Required]
        [StringLength(10)]
        public string Mon { get; set; }

        public decimal Currency { get; set; }

        [Required]
        [StringLength(8)]
        public string CurrencyType { get; set; }
    }
}
