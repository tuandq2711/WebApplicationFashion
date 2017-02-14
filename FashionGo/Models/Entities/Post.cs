namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Post
    {

        public int Id { get; set; }

        public int? CatId { get; set; }

        [StringLength(250)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Slug { get; set; }

        [Column(TypeName = "ntext")]
        public string Content { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public DateTime? createDate { get; set; }

        public string UserId { get; set; }

        public bool Active { get; set; }

        [Display(Name = "Tiêu đề")]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả")]
        public string MetaDescription { get; set; }

        [Display(Name = "Từ khóa")]
        public string MetaKeyword { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Category Category { get; set; }

    }
}
