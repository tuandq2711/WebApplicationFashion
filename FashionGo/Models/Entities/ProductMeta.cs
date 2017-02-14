namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductMeta")]
    public partial class ProductMeta
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MetaId { get; set; }

        [Column(TypeName = "text")]
        public string Value { get; set; }

        [Column(TypeName = "text")]
        public string Note { get; set; }

        public virtual Meta Meta { get; set; }

        public virtual Product Product { get; set; }
    }
}
