using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionGo.Models.Entities
{
    public partial class BannerType
    {
        [Key]
        public int BannerTypeId { get; set; }

        [Display(Name = "Banner Type")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public virtual IEnumerable<Banner> Banners { get; set; }
    }
}
