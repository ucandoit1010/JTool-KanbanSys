namespace ModelLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CardCatalog")]
    public partial class CardCatalog
    {
        [Key]
        public short CatId { get; set; }

        [Required]
        [StringLength(40)]
        public string CatalogName { get; set; }
    }
}
