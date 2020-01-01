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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KBProject()
        {
            ProjectMappings = new HashSet<ProjectMapping>();
        }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectMapping> ProjectMappings { get; set; }
    }
}
