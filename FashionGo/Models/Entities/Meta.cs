namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Meta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Meta()
        {
            ProductMetas = new HashSet<ProductMeta>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public int? TypeId { get; set; }

        [Column(TypeName = "text")]
        public string Options { get; set; }

        [Column(TypeName = "text")]
        public string Value { get; set; }

        public virtual MetaType MetaType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductMeta> ProductMetas { get; set; }
    }
}
