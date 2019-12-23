namespace ModelLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KBProject")]
    public partial class KBProject
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectName { get; set; }

        [Required]
        public string ProjectSQL { get; set; }

        public int CId { get; set; }

        public bool IsEnable { get; set; }

        public byte ChartId { get; set; }

        [StringLength(50)]
        public string Url { get; set; }

        public virtual Chart Chart { get; set; }

        public virtual Conn Conn { get; set; }
    }
}
