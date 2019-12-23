namespace ModelLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Conn")]
    public partial class Conn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Conn()
        {
            KBProjects = new HashSet<KBProject>();
        }

        [Key]
        public int CId { get; set; }

        [Required]
        [StringLength(20)]
        public string DBType { get; set; }

        [Required]
        [StringLength(500)]
        public string ConnStr { get; set; }

        [Required]
        [StringLength(50)]
        public string AliasName { get; set; }

        public bool IsEnable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KBProject> KBProjects { get; set; }
    }
}
