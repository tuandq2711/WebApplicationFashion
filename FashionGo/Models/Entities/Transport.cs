namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transport()
        {
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        public int? TransporterId { get; set; }

        public int? TransportTypeId  { get; set; }

        [StringLength(255)]
        public string DistrictId { get; set; }

        [Display(Name = "Phí vận chuyển")]
        public double? Cost { get; set; }

        public float TransportTime { get; set; }

        [Column(TypeName = "ntext")]
        public string Note { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual District District { get; set; }

        public virtual Transporter Transporter { get; set; }

        public virtual TransportType TransportType  { get; set; }

    }
}
