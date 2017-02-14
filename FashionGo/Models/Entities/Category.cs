namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category()
        {
            SubCategories = new HashSet<Category>();
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Slug { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int? DisplayOrder { get; set; }

        [Display(Name = "Tiêu đề")]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả")]
        public string MetaDescription { get; set; }

        [Display(Name = "Từ khóa")]
        public string MetaKeyword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category> SubCategories { get; set; }

        public virtual Category ParentCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}
