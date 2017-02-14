namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderStatus")]
    public partial class OrderStatus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        [Display(Name = "Trạng thái")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "Css Class")]
        public string Class { get; set; }

        [Column(TypeName = "ntext")]
        public string Note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}
