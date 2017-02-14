namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Faq
    {

        public int Id { get; set; }

        [StringLength(250)]
        public string Slug { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Content { get; set; }

        public int? MenuOrder { get; set; }

    }
}
