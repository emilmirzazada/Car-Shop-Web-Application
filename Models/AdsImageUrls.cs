using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace carshop.webui.Models
{
    public partial class AdsImageUrls
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public int? AdsId { get; set; }

        public virtual TbAds Ads { get; set; }
    }
}
