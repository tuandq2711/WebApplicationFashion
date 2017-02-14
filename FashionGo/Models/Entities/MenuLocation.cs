namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MenuLocation
    {
        public MenuLocation()
        {
            Menus = new HashSet<Menu>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        public virtual ICollection<Menu> Menus { get; set; }
    }
}
