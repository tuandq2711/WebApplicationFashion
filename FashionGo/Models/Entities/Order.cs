namespace FashionGo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        
        [Display(Name = "Khách hàng")]
        public string UserId { get; set; }

        [Display(Name = "Trạng thái")]
        public int? StatusId { get; set; }

        [Display(Name = "Mã Giảm giá")]
        public string Coupon  { get; set; }

        [Display(Name = "Giảm giá")]
        public double? Discount { get; set; }

        [Display(Name = "Khuyến mãi thêm")]
        public double? ExtraDiscount { get; set; }

        [Display(Name = "Tổng tiền hàng(đ)")]
        public double? TotalAmount { get; set; }

        [Display(Name = "Tổng đơn hàng(đ)")]
        public double? TotalOrder { get; set; }

        [Required]
        public int? TransportId { get; set; }

        public int? PaymentMethodId { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Bạn chưa nhập tên người nhận.")]
        [Display(Name = "Người nhận")]
        public string ReceiveName { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập địa chỉ nhận hàng.")]
        [StringLength(255)]
        public string ReceiveAddress { get; set; }

        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại người nhận.")]
        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        public string ReceivePhone { get; set; }

        [Column(TypeName ="ntext")]
        [Display(Name = "Ghi chú đơn hàng")]
        public string Note { get; set; }

        [Display(Name = "Ngày đặt")]
        public DateTime? OrderDate { get; set; }

        [Display(Name = "Ngày giao")]
        public DateTime? RequireDate { get; set; }

        public virtual ApplicationUser User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public virtual OrderStatus OrderStatus { get; set; }

        public virtual Transport Transport { get; set; }

        public virtual PaymentMethod PaymentMethod { get; set; }

        public virtual ICollection<Product> Products { get; private set; }
    }
}
