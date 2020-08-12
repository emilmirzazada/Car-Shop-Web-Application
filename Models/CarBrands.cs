using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace carshop.webui.Models
{
    [JsonObject(IsReference = true)]
    public partial class CarBrands
    {
        public CarBrands()
        {
            TbAds = new HashSet<TbAds>();
        }

        public int Id { get; set; }
        public string Code { get; set; }
        public string BrandName { get; set; }

        public virtual ICollection<TbAds> TbAds { get; set; }
    }
}
