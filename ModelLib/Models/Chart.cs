namespace ModelLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chart")]
    public partial class Chart
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chart()
        {
            KBProjects = new HashSet<KBProject>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte ChartId { get; set; }

        [Required]
        [StringLength(20)]
        public string ChartType { get; set; }

        [Required]
        [StringLength(800)]
        public string ChartScript { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KBProject> KBProjects { get; set; }
    }
}
