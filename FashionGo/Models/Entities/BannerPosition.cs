using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionGo.Models.Entities
{
    public partial class BannerPosition
    {
        [Key]
        public int BannerPositionId { get; set; }

        [Display(Name = "Banner Position")]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        public virtual IEnumerable<Banner> Banners { get; set; }

    }
}
