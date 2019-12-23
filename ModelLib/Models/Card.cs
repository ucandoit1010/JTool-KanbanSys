namespace ModelLib.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Card")]
    public partial class Card
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short CardId { get; set; }

        public short CatId { get; set; }

        [Required]
        [StringLength(100)]
        public string CardName { get; set; }
    }
}
