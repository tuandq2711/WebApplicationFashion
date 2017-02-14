using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FashionGo.Models.Entities
{
    public partial class PaymentMethod
    {
        [Key]
        public int Id { get; set; }

        [StringLength(255)]
        [Display(Name = "Phương thức thanh toán")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [Display(Name = "Mô tả")]
        public string Description  { get; set; }

        public bool? Actived { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
