namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Page
    {
        
        public int Id { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Slug { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [Display(Name = "Tiêu đề")]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả")]
        public string MetaDescription { get; set; }

        [Display(Name = "Từ khóa")]
        public string MetaKeyword { get; set; }
    }
}
