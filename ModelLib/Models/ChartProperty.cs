namespace ModelLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChartProperty")]
    public partial class ChartProperty
    {
        [Key]
        public int CPId { get; set; }

        public byte ChartId { get; set; }

        [Required]
        [StringLength(50)]
        public string CPName { get; set; }

        public virtual Chart Chart { get; set; }
    }
}
