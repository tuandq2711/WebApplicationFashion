namespace FashionGo.Models.Entities
{
    using Entities;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductMetas = new HashSet<ProductMeta>();
            Orders = new HashSet<Order>();
        }

        [Key]
        public int Id { get; set; }

        [Display(Name="Danh mục sp")]
        public int? CatId { get; set; }

        [StringLength(255)]
        [Display(Name = "Tên SP")]
        public string Name { get; set; }

        [StringLength(255)]
        public string Slug { get; set; }

        [Display(Name = "Nhà SX")]
        public int? ManufactId { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Đặc điểm nổi bật")]
        public string Featured { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Điều kiện sử dụng")]
        public string Condition { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Chi tiết")]
        public string Detail { get; set; }

        [Display(Name = "Số lượng")]
        public int? Amount { get; set; }

        [Display(Name = "Kiểu SP")]
        public int? TypeId { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Hình ảnh khác")]
        public string Images { get; set; }

        [StringLength(255)]
        [Display(Name = "Hình đại diện")]
        public string FeaturedImage { get; set; }

        [Display(Name = "Giá gốc")]
        public double? Price { get; set; }

        [Display(Name = "Giảm giá (%)")]
        public int? Discount { get; set; }

        [Display(Name = "Giá bán")]
        public double? PriceAfter { get; set; }

        [Display(Name = "Ngày hết hạn")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? EndDate { get; set; }

        [Display(Name = "Người đăng")]
        public string UserId { get; set; }

        [Display(Name = "Ngày đăng")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? CreateDate { get; set; }

        [Display(Name = "Khuyến mãi cộng thêm")]
        public double? ExtraDiscount { get; set; }

        [Display(Name="Sản phẩm mới")]
        public bool? IsNew { get; set; }

        [Display(Name = "Đánh dấu nổi bật")]
        public bool? IsFeatured { get; set; }

        [Display(Name = "Sản phẩm bán chạy")]
        public bool? IsSpecial  { get; set; }

        [Display(Name = "Kích hoạt sản phẩm")]
        public bool? Actived { get; set; }

        [Display(Name="Lượt xem")]
        public int Views { get; set; }

        [Display(Name = "Tiêu đề")]
        public string MetaTitle { get; set; }

        [Display(Name = "Mô tả")]
        public string MetaDescription { get; set; }

        [Display(Name = "Từ khóa")]
        public string MetaKeyword { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual Manufact Manufact { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual ProductCategory ProductCategory { get; set; }

        public virtual ProductType ProductType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductMeta> ProductMetas { get; set; }

        public virtual ICollection<Order> Orders  { get; set; }

    }
}
