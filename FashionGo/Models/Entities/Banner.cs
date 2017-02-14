using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashionGo.Models.Entities
{
    public enum Sections
    {
        Homepage, ProductCategory, Product, Blog , PostDetail
    };

    public partial class Banner
    {
        [Key]
        public int BannerId { get; set; }

        public string Name { get; set; }

        public int BannerTypeId { get; set; }

        public Sections ItemFor { get; set; }

        public int ItemForId  { get; set; }

        public int BannerPositionId { get; set; }

        [Column(TypeName = "nText")]
        public string Description { get; set; }

        [Column(TypeName = "nText")]
        public string Content { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Active { get; set; }

        public virtual BannerType BannerType { get; set; }

        public virtual BannerPosition BannerPosition { get; set; }
    }
}
