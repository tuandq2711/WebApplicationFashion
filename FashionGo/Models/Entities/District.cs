namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class District
    {
        [Key]
        [StringLength(255)]
        public string DistrictId { get; set; }

        [StringLength(255)]
        [Display(Name = "Quận/Huyện")]
        public string Name { get; set; }

        [StringLength(255)]
        public string Type { get; set; }

        [StringLength(255)]
        public string Location { get; set; }

        [StringLength(255)]
        public string ProvinceId { get; set; }

        public virtual Province Province { get; set; }

        public virtual List<Transport> Transports  { get; set; }
    }
}
