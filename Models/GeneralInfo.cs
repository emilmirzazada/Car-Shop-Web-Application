using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace carshop.webui.Models
{
    [JsonObject(IsReference = true)]
    public partial class GeneralInfo
    {
        public GeneralInfo()
        {
            TbAdsBodyType = new HashSet<TbAds>();
            TbAdsCity = new HashSet<TbAds>();
            TbAdsColor = new HashSet<TbAds>();
            TbAdsCurrency = new HashSet<TbAds>();
            TbAdsEngineCapacity = new HashSet<TbAds>();
            TbAdsFuelType = new HashSet<TbAds>();
            TbAdsGearbox = new HashSet<TbAds>();
            TbAdsTransmission = new HashSet<TbAds>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TypeId { get; set; }

        public virtual GeneralType Type { get; set; }
        public virtual ICollection<TbAds> TbAdsBodyType { get; set; }
        public virtual ICollection<TbAds> TbAdsCity { get; set; }
        public virtual ICollection<TbAds> TbAdsColor { get; set; }
        public virtual ICollection<TbAds> TbAdsCurrency { get; set; }
        public virtual ICollection<TbAds> TbAdsEngineCapacity { get; set; }
        public virtual ICollection<TbAds> TbAdsFuelType { get; set; }
        public virtual ICollection<TbAds> TbAdsGearbox { get; set; }
        public virtual ICollection<TbAds> TbAdsTransmission { get; set; }
    }
}
