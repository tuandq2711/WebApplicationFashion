using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionGo.Models.Entities
{
    public enum DiscountObject 
    {
        Product, Order, Transport
    };

    public partial class Coupon
    {
        [Key]
        public string Code { set; get; }

        public string Name  { get; set; }

        public int Discount  { get; set; }

        public DiscountObject DiscountFor { get; set; } // Product, Order, Transport

        public int? DiscountForId { get; set; } // Product, Order, Transport

        public int LimitedUsed  { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }
    }
}
