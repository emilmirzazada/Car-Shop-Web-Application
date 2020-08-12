using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace carshop.webui.Models
{
    [JsonObject(IsReference = true)]
    public partial class TbAds
    {
        public TbAds()
        {
            AdsImageUrls = new HashSet<AdsImageUrls>();
        }
        public int Id { get; set; }

        [Required(ErrorMessage ="Marka göstərilməlidir")]
        public int? BrandId { get; set; }

        [Required(ErrorMessage = "Model göstərilməlidir")]
        public int? ModelId { get; set; }

        [Required(ErrorMessage = "Ban növü göstərilməlidir")]
        public int? BodyTypeId { get; set; }

        [Required(ErrorMessage = "Yürüş göstərilməlidir")]
        public int? Walk { get; set; }

        [Required(ErrorMessage = "Rəng göstərilməlidir")]
        public int? ColorId { get; set; }

        [Required(ErrorMessage = "Qiymət göstərilməlidir")]
        [Range(1,maximum:1000000,ErrorMessage ="1-1000000 aralığında olmalıdır")]
        public int? Price { get; set; }

        [Required(ErrorMessage = "Valyuta göstərilməlidir")]
        public int? CurrencyId { get; set; }
        public bool Credit { get; set; }
        public bool Barter { get; set; }
        [Required(ErrorMessage = "Yanacağın növü göstərilməlidir")]
        public int? FuelTypeId { get; set; }

        [Required(ErrorMessage = "Ötürücü göstərilməlidir")]
        public int? TransmissionId { get; set; }

        [Required(ErrorMessage = "Sürətlər qutusu göstərilməlidir")]
        public int? GearboxId { get; set; }

        [Required(ErrorMessage = "Buraxılış ili göstərilməlidir")]
        public int? GraduationYear { get; set; }

        [Required(ErrorMessage = "Mühərrikin həcmi göstərilməlidir")]
        public int? EngineCapacityId { get; set; }

        [Required(ErrorMessage = "Mühərrikin gücü göstərilməlidir")]
        public int? Hp { get; set; }
        public string Note { get; set; }
        public bool AlloyWheels { get; set; }
        public bool CentralClosure { get; set; }
        public bool LeatherSalon { get; set; }
        public bool SeatVentilation { get; set; }
        public bool Usa { get; set; }
        public bool ParkingRadar { get; set; }
        public bool Xenon { get; set; }
        public bool Luke { get; set; }
        public bool Conditioner { get; set; }
        public bool RearCamera { get; set; }
        public bool RainSensor { get; set; }
        public bool SeatHeating { get; set; }
        public bool SideCurtains { get; set; }
        [Required(ErrorMessage = "Ad göstərilməlidir")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Şəhər göstərilməlidir")]
        public int? CityId { get; set; }
        [Required(ErrorMessage = "Email göstərilməlidir")]
        [EmailAddress]
        public string Email { get; set; }
        public virtual GeneralInfo BodyType { get; set; }
        public virtual CarBrands Brand { get; set; }
        public virtual GeneralInfo City { get; set; }
        public virtual GeneralInfo Color { get; set; }
        public virtual GeneralInfo Currency { get; set; }
        public virtual GeneralInfo EngineCapacity { get; set; }
        public virtual GeneralInfo FuelType { get; set; }
        public virtual GeneralInfo Gearbox { get; set; }
        public virtual CarModels Model { get; set; }
        public virtual GeneralInfo Transmission { get; set; }
        public virtual ICollection<AdsImageUrls> AdsImageUrls { get; set; }

    }
}
