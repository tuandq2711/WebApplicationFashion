namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ProductCategory")]
    public partial class ProductCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProductCategory()
        {
            SubCategories = new HashSet<ProductCategory>();
            Products = new HashSet<Product>();
        }

        [Key]
        public int CatId { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Danh mục")]
        public string Name { get; set; }

        [StringLength(250)]
        public string Slug { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(250)]
        public string Banner { get; set; }

        public int? DisplayOrder  { get; set; }

        public int? ParentId { get; set; }

        [Display(Name = "Tiêu đề")]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả")]
        public string MetaDescription  { get; set; }

        [Display(Name = "Từ khóa")]
        public string MetaKeyword  { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductCategory> SubCategories { get; set; }

        public virtual ProductCategory ParentCategory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Products { get; set; }
    }
}
