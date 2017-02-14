namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transporter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Transporter()
        {
            Transports = new HashSet<Transport>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        [Display(Name ="Nhà vận chuyển")]
        public string Name { get; set; }

        [StringLength(255)]
        public string Logo { get; set; }

        [StringLength(50)]
        public string Phone { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(50)]
        public string ContactName { get; set; }

        public bool Active  { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transport> Transports { get; set; }

        
    }
}
