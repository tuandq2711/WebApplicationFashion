namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public enum Target
    {
        _blank, _self, _parent, _top, framename
    };

    public partial class Menu
    {
        

        [Key]
        public int Id { get; set; }

        public int? LocationId { get; set; }

        [StringLength(250)]
        public string Text { get; set; }

        [StringLength(250)]
        public string Url { get; set; }

        public Target Target  { get; set; }

        public virtual MenuLocation MenuLocation { get; set; }
    }
}
