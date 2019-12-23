namespace ModelLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CurrencyTest")]
    public partial class CurrencyTest
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string Mon { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal Currency { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(8)]
        public string CurrencyType { get; set; }
    }
}
