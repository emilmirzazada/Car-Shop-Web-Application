using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using carshop.webui.Extensions;
using carshop.webui.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace carshop.webui.Controllers
{
    public class ShopController : Controller
    {
        TurboContext context = new TurboContext();

        public IActionResult List()
        {
                ProductListViewModel model = new ProductListViewModel()
            {
                TbAdses = context.TbAds
                       .Include(i => i.Brand)
                       .Include(i => i.Model)
                       .Include(i => i.AdsImageUrls)
                       .Include(i => i.Currency)
                       .ThenInclude(i => i.TbAdsCurrency)
                       .Include(i => i.EngineCapacity)
                       .ThenInclude(i => i.TbAdsEngineCapacity)
                       
                       .ToList()
            };


            List<CarBrands> brandList = context.CarBrands
                                        .OrderBy(i => i.BrandName)
                                        .ToList();
            var brandModel = (from b in brandList
                              select new SelectListItem
                              {
                                  Value = b.Id.ToString(),
                                  Text = b.BrandName
                              }).ToList();

            ViewBag.Brands = brandModel;
            ViewBag.City = GetGeneralInfo(7);
            ViewBag.Currency = GetGeneralInfo(3);

            
            try
            {
                model.TbAdses = JsonConvert.DeserializeObject<List<TbAds>>(HttpContext.Session.GetString("searchData"));
                HttpContext.Session.Clear();
                return View(model);
            }
            catch (Exception)
            {
                return View(model);
            }
            
        }

        public List<SelectListItem> GetGeneralInfo(int typeId)
        {
            List<GeneralInfo> itemList = context.GeneralInfo
                                         .Include(i => i.Type)
                                         .Where(i => i.TypeId == typeId)
                                        .ToList();

            var model = (from b in itemList
                         select new SelectListItem
                         {
                             Value = b.Id.ToString(),
                             Text = b.Name
                         }).ToList();
            
            if (typeId == 7)
                model.RemoveAt(0);
            return model;
        }
        public IActionResult AdPlace(int? BrandId)
        {

            List<CarBrands> brandList = context.CarBrands
                                        .OrderBy(i => i.BrandName)
                                        .ToList();
            var brandModel = (from b in brandList
                              select new SelectListItem
                              {
                                  Value = b.Id.ToString(),
                                  Text = b.BrandName
                              }).ToList();
            ViewBag.Brands = brandModel;

            ViewBag.Currency = context.GeneralInfo
                            .Include(i => i.Type)
                            .Where(i => i.TypeId == 3)
                            .ToList();
            ViewBag.BodyType = GetGeneralInfo(1);
            ViewBag.Color = GetGeneralInfo(2);
            ViewBag.FuelType = GetGeneralInfo(4);
            ViewBag.Transmission = GetGeneralInfo(5);
            ViewBag.Gearbox = GetGeneralInfo(6);
            ViewBag.City = GetGeneralInfo(7);
            ViewBag.EngineCapacity = GetGeneralInfo(8);
            return View();
        }

        public JsonResult ModelList(int Bid)
        {
            List<CarModels> ModelList = context.CarModels
                                        .Where(i => i.BrandId == Bid)
                                        .OrderBy(i => i.ModelName)
                                        .ToList();
            List<SelectListItem> itemList = (from m in ModelList
                                             select new SelectListItem
                                             {
                                                 Value = m.Id.ToString(),
                                                 Text = m.ModelName
                                             }).ToList();
            return Json(itemList);
        }

        [HttpPost]
        public async Task<IActionResult> AdPlace(int? BrandId, TbAds adsModel, List<IFormFile> imgfiles)
        {
            List<CarBrands> brandList = context.CarBrands
                                        .OrderBy(i => i.BrandName)
                                        .ToList();
            var brandModel = (from b in brandList
                              select new SelectListItem
                              {
                                  Value = b.Id.ToString(),
                                  Text = b.BrandName
                              }).ToList();
            ViewBag.Brands = brandModel;

            ViewBag.Currency = context.GeneralInfo
                            .Include(i => i.Type)
                            .Where(i => i.TypeId == 3)
                            .ToList();
            ViewBag.BodyType = GetGeneralInfo(1);
            ViewBag.Color = GetGeneralInfo(2);
            ViewBag.FuelType = GetGeneralInfo(4);
            ViewBag.Transmission = GetGeneralInfo(5);
            ViewBag.Gearbox = GetGeneralInfo(6);
            ViewBag.City = GetGeneralInfo(7);
            ViewBag.EngineCapacity = GetGeneralInfo(8);

            if (ModelState.IsValid)
            {
                var entity = new TbAds()
                {
                    BrandId = adsModel.BrandId,
                    ModelId = adsModel.ModelId,
                    BodyTypeId = adsModel.BodyTypeId,
                    Walk = adsModel.Walk,
                    ColorId = adsModel.ColorId,
                    Price = adsModel.Price,
                    CurrencyId = adsModel.CurrencyId,
                    Credit = adsModel.Credit,
                    Barter = adsModel.Barter,
                    FuelTypeId = adsModel.FuelTypeId,
                    TransmissionId = adsModel.TransmissionId,
                    GearboxId = adsModel.GearboxId,
                    GraduationYear = adsModel.GraduationYear,
                    EngineCapacityId = adsModel.EngineCapacityId,
                    Hp = adsModel.Hp,
                    Note = adsModel.Note,
                    AlloyWheels = adsModel.AlloyWheels,
                    CentralClosure = adsModel.CentralClosure,
                    LeatherSalon = adsModel.LeatherSalon,
                    SeatVentilation = adsModel.SeatVentilation,
                    Usa = adsModel.Usa,
                    ParkingRadar = adsModel.ParkingRadar,
                    Xenon = adsModel.Xenon,
                    Luke = adsModel.Luke,
                    Conditioner = adsModel.Conditioner,
                    RearCamera = adsModel.RearCamera,
                    RainSensor = adsModel.RainSensor,
                    SeatHeating = adsModel.SeatHeating,
                    SideCurtains = adsModel.SideCurtains,
                    Name = adsModel.Name,
                    CityId = adsModel.CityId,
                    Email = adsModel.Email

                };

                context.TbAds.Add(entity);
                context.SaveChanges();

                int adsId = entity.Id;

                foreach (var file in imgfiles)
                {
                    if (file != null)
                    {
                        var extension = Path.GetExtension(file.FileName);
                        var randomName = string.Format($"{Guid.NewGuid()}{extension}");
                        adsModel.AdsImageUrls.Add(new AdsImageUrls() { ImageUrl = randomName, AdsId = adsId });
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }

                context.AdsImageUrls.AddRange(adsModel.AdsImageUrls);
                context.SaveChanges();

                return RedirectToAction("List");
            }
            return View(adsModel);
        }


        [HttpPost]
        public IActionResult List(ProductListViewModel Pmodel, string Search, string DetailedSearch)
        {
                ProductListViewModel model = new ProductListViewModel();

                model.TbAdses = context.TbAds
                         .Include(i=>i.AdsImageUrls)
                         .Include(i => i.Brand)
                         .Include(i => i.Model)
                         .Include(i => i.EngineCapacity)
                         .ThenInclude(i => i.TbAdsEngineCapacity)
                         .ToList();

                if (Pmodel.BrandId != null)
                    model.TbAdses = model.TbAdses.Where(i => i.BrandId == Pmodel.BrandId).ToList();
                if (Pmodel.CurrencyId != null)
                    model.TbAdses = model.TbAdses.Where(i => i.CurrencyId == Pmodel.CurrencyId).ToList();
                if (Pmodel.ModelId != null)
                    model.TbAdses = model.TbAdses.Where(i => i.ModelId == Pmodel.ModelId).ToList();
                if (Pmodel.CityId != null)
                    model.TbAdses = model.TbAdses.Where(i => i.CityId == Pmodel.CityId).ToList();
                if (Pmodel.minPrice != null)
                    model.TbAdses = model.TbAdses.Where(i => i.Price >= Pmodel.minPrice).ToList();
                if (Pmodel.maxPrice != null)
                    model.TbAdses = model.TbAdses.Where(i => i.Price <= Pmodel.maxPrice).ToList();
                if (Pmodel.minYear != null)
                    model.TbAdses = model.TbAdses.Where(i => i.GraduationYear >= Pmodel.minYear).ToList();
                if (Pmodel.maxYear != null)
                    model.TbAdses = model.TbAdses.Where(i => i.GraduationYear == Pmodel.maxYear).ToList();
                if (Pmodel.Credit)
                    model.TbAdses = model.TbAdses.Where(i => i.Credit == true).ToList();
                if (Pmodel.Barter)
                    model.TbAdses = model.TbAdses.Where(i => i.Barter == true).ToList();

                List<CarBrands> brandList = context.CarBrands
                                            .OrderBy(i => i.BrandName)
                                            .ToList();
                var brandModel = (from b in brandList
                                  select new SelectListItem
                                  {
                                      Value = b.Id.ToString(),
                                      Text = b.BrandName
                                  }).ToList();

                ViewBag.City = GetGeneralInfo(7);
                ViewBag.Currency = GetGeneralInfo(3);
                ViewBag.Brands = brandModel;

                if (Search == null)
                {
                    return RedirectToAction("DetailedSearch");
                }

                return View(model);
            
        }
        public IActionResult DetailedSearch()
        {
            List<CarBrands> brandList = context.CarBrands
                                        .OrderBy(i => i.BrandName)
                                        .ToList();
            var brandModel = (from b in brandList
                              select new SelectListItem
                              {
                                  Value = b.Id.ToString(),
                                  Text = b.BrandName
                              }).ToList();
            ViewBag.Brands = brandModel;

            ViewBag.Currency = GetGeneralInfo(3);
            ViewBag.BodyType = GetGeneralInfo(1);
            ViewBag.Color = GetGeneralInfo(2);
            ViewBag.FuelType = GetGeneralInfo(4);
            ViewBag.Transmission = GetGeneralInfo(5);
            ViewBag.Gearbox = GetGeneralInfo(6);
            ViewBag.City = GetGeneralInfo(7);
            ViewBag.EngineCapacity = GetGeneralInfo(8);
            return View();
        }
        [HttpPost]
        public IActionResult DetailedSearch(ProductListViewModel Pmodel)
        {
            var model = new ProductListViewModel();

            model.TbAdses = context.TbAds
                     .Include(i => i.Brand)
                     .Include(i => i.Model)
                     .Include(i=>i.AdsImageUrls)
                     .ToList();

            if (Pmodel.BrandId != null)
                model.TbAdses = model.TbAdses.Where(i => i.BrandId == Pmodel.BrandId).ToList();
            if (Pmodel.FuelTypeId != null)
                model.TbAdses = model.TbAdses.Where(i => i.FuelTypeId == Pmodel.FuelTypeId).ToList();
            if (Pmodel.ColorId != null)
                model.TbAdses = model.TbAdses.Where(i => i.ColorId == Pmodel.ColorId).ToList();
            if (Pmodel.Walk != null)
                model.TbAdses = model.TbAdses.Where(i => i.Walk == Pmodel.Walk).ToList();
            if (Pmodel.BodyTypeId != null)
                model.TbAdses = model.TbAdses.Where(i => i.BodyTypeId == Pmodel.BodyTypeId).ToList();
            if (Pmodel.TransmissionId != null)
                model.TbAdses = model.TbAdses.Where(i => i.TransmissionId == Pmodel.TransmissionId).ToList();
            if (Pmodel.GearboxId != null)
                model.TbAdses = model.TbAdses.Where(i => i.GearboxId == Pmodel.GearboxId).ToList();
            if (Pmodel.minCapacity != null)
                model.TbAdses = model.TbAdses.Where(i => i.EngineCapacityId >= Pmodel.minCapacity).ToList();
            if (Pmodel.maxCapacity != null)
                model.TbAdses = model.TbAdses.Where(i => i.EngineCapacityId <= Pmodel.maxCapacity).ToList();
            if (Pmodel.CurrencyId != null)
                model.TbAdses = model.TbAdses.Where(i => i.CurrencyId == Pmodel.CurrencyId).ToList();
            if (Pmodel.ModelId != null)
                model.TbAdses = model.TbAdses.Where(i => i.ModelId == Pmodel.ModelId).ToList();
            if (Pmodel.CityId != null)
                model.TbAdses = model.TbAdses.Where(i => i.CityId == Pmodel.CityId).ToList();
            if (Pmodel.minPrice != null)
                model.TbAdses = model.TbAdses.Where(i => i.Price >= Pmodel.minPrice).ToList();
            if (Pmodel.maxPrice != null)
                model.TbAdses = model.TbAdses.Where(i => i.Price <= Pmodel.maxPrice).ToList();
            if (Pmodel.minYear != null)
                model.TbAdses = model.TbAdses.Where(i => i.GraduationYear >= Pmodel.minYear).ToList();
            if (Pmodel.maxYear != null)
                model.TbAdses = model.TbAdses.Where(i => i.GraduationYear == Pmodel.maxYear).ToList();
            if (Pmodel.Credit)
                model.TbAdses = model.TbAdses.Where(i => i.Credit == true).ToList();
            if (Pmodel.Barter)
                model.TbAdses = model.TbAdses.Where(i => i.Barter == true).ToList();

            List<CarBrands> brandList = context.CarBrands
                                        .OrderBy(i => i.BrandName)
                                        .ToList();
            var brandModel = (from b in brandList
                              select new SelectListItem
                              {
                                  Value = b.Id.ToString(),
                                  Text = b.BrandName
                              }).ToList();


            ViewBag.Currency = GetGeneralInfo(3);
            ViewBag.BodyType = GetGeneralInfo(1);
            ViewBag.Color = GetGeneralInfo(2);
            ViewBag.FuelType = GetGeneralInfo(4);
            ViewBag.Transmission = GetGeneralInfo(5);
            ViewBag.Gearbox = GetGeneralInfo(6);
            ViewBag.City = GetGeneralInfo(7);
            ViewBag.EngineCapacity = GetGeneralInfo(8);

            ViewBag.Brands = brandModel;

            List<TbAds> searchData = model.TbAdses;
            HttpContext.Session.SetString("searchData", JsonConvert.SerializeObject(searchData));

            return RedirectToAction("List");
        }
        public IActionResult CarDetails(int id)
        {
            var model = context.TbAds
                     .Include(i => i.Brand)
                     .Include(i => i.Model)
                     .Include(i=>i.AdsImageUrls)
                     .Where(i => i.Id == id)
                     .Include(i => i.EngineCapacity)
                     .ThenInclude(i => i.TbAdsEngineCapacity)
                     .Include(i => i.City)
                     .ThenInclude(i => i.TbAdsCity)
                     .Include(i => i.BodyType)
                     .ThenInclude(i => i.TbAdsBodyType)
                     .Include(i => i.Gearbox)
                     .ThenInclude(i => i.TbAdsGearbox) 
                     .Include(i => i.Color)
                     .ThenInclude(i => i.TbAdsColor)
                     .Include(i => i.FuelType)  
                     .ThenInclude(i => i.TbAdsFuelType)
                     .Include(i => i.Transmission)
                     .ThenInclude(i => i.TbAdsTransmission)
                     .Include(i=>i.Currency)
                     .ThenInclude(i=>i.TbAdsCurrency)
                     .FirstOrDefault();
            return View(model);
        }
    }
}