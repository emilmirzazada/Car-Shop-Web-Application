using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace carshop.webui.Models
{
    [JsonObject(IsReference = true)]
    public partial class CarModels
    {
        public CarModels()
        {
            TbAds = new HashSet<TbAds>();
        }

        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Code { get; set; }
        public string ModelName { get; set; }

        public virtual ICollection<TbAds> TbAds { get; set; }
    }
}
