namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Manufact")]
    public partial class Manufact
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Manufact()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        [Display(Name ="Nhà Sx")]
        public string Name { get; set; }

        [StringLength(250)]
        public string Logo { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
