namespace ModelLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProjectMapping")]
    public partial class ProjectMapping
    {
        [Key]
        public int PMId { get; set; }

        public int ProjectId { get; set; }

        [StringLength(40)]
        public string PropertyName { get; set; }

        public int CPId { get; set; }

        public virtual KBProject KBProject { get; set; }
    }
}
