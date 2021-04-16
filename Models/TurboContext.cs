using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace carshop.webui.Models
{
    public partial class TurboContext : DbContext
    {
        public TurboContext()
        {
        }

        public TurboContext(DbContextOptions<TurboContext> options)
            : base(options)
        {
        }
        public virtual DbSet<AdsImageUrls> AdsImageUrls { get; set; }
        public virtual DbSet<CarBrands> CarBrands { get; set; }
        public virtual DbSet<CarModels> CarModels { get; set; }
        public virtual DbSet<GeneralInfo> GeneralInfo { get; set; }
        public virtual DbSet<GeneralType> GeneralType { get; set; }
        public virtual DbSet<TbAds> TbAds { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-B3K0ARS\\SQLEXPRESS;Database=Turbo;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<CarBrands>(entity =>
            {
                entity.ToTable("Car_Brands");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrandName)
                    .IsRequired()
                    .HasColumnName("Brand_Name")
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<CarModels>(entity =>
            {
                entity.ToTable("Car_Models");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BrandId)
                    .HasColumnName("Brand_ID")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(125)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.ModelName)
                    .IsRequired()
                    .HasColumnName("Model_Name")
                    .HasMaxLength(125)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('')");
            });

            modelBuilder.Entity<GeneralInfo>(entity =>
            {
                entity.ToTable("General_Info");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.TypeId).HasColumnName("Type_ID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.GeneralInfo)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_Gen_Name_General_Type");
            });

            modelBuilder.Entity<GeneralType>(entity =>
            {
                entity.ToTable("General_Type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TbAds>(entity =>
            {
                entity.ToTable("TB_ADS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AlloyWheels).HasColumnName("Alloy_Wheels");

                entity.Property(e => e.BodyTypeId).HasColumnName("Body_Type_ID");

                entity.Property(e => e.BrandId).HasColumnName("Brand_ID");

                entity.Property(e => e.CentralClosure).HasColumnName("Central_Closure");

                entity.Property(e => e.CityId).HasColumnName("City_ID");

                entity.Property(e => e.ColorId).HasColumnName("Color_ID");

                entity.Property(e => e.CurrencyId).HasColumnName("Currency_ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.EngineCapacityId).HasColumnName("Engine_Capacity_ID");

                entity.Property(e => e.FuelTypeId).HasColumnName("Fuel_Type_ID");

                entity.Property(e => e.GearboxId).HasColumnName("Gearbox_ID");

                entity.Property(e => e.GraduationYear).HasColumnName("Graduation_Year");

                entity.Property(e => e.Hp).HasColumnName("HP");

                entity.Property(e => e.LeatherSalon).HasColumnName("Leather_Salon");

                entity.Property(e => e.ModelId).HasColumnName("Model_ID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                

                entity.Property(e => e.Note).HasMaxLength(300);

                entity.Property(e => e.ParkingRadar).HasColumnName("Parking_Radar");

                entity.Property(e => e.RainSensor).HasColumnName("Rain_Sensor");

                entity.Property(e => e.RearCamera).HasColumnName("Rear_Camera");

                entity.Property(e => e.SeatHeating).HasColumnName("Seat_Heating");

                entity.Property(e => e.SeatVentilation).HasColumnName("Seat_Ventilation");

                entity.Property(e => e.SideCurtains).HasColumnName("Side_Curtains");

                entity.Property(e => e.TransmissionId).HasColumnName("Transmission_ID");

                entity.Property(e => e.Usa).HasColumnName("USA");

                entity.HasOne(d => d.BodyType)
                    .WithMany(p => p.TbAdsBodyType)
                    .HasForeignKey(d => d.BodyTypeId)
                    .HasConstraintName("FK_TB_ADS_Body_TB_ADS");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.TbAds)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_TB_ADS_Car_Brands");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.TbAdsCity)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TB_ADS_City_General_Type1");

                entity.HasOne(d => d.Color)
                    .WithMany(p => p.TbAdsColor)
                    .HasForeignKey(d => d.ColorId)
                    .HasConstraintName("FK_TB_ADS_Color_General_Type");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.TbAdsCurrency)
                    .HasForeignKey(d => d.CurrencyId)
                    .HasConstraintName("FK_TB_ADS_Currency");

                entity.HasOne(d => d.EngineCapacity)
                    .WithMany(p => p.TbAdsEngineCapacity)
                    .HasForeignKey(d => d.EngineCapacityId)
                    .HasConstraintName("FK_TB_ADS_Engine_General_Type1");

                entity.HasOne(d => d.FuelType)
                    .WithMany(p => p.TbAdsFuelType)
                    .HasForeignKey(d => d.FuelTypeId)
                    .HasConstraintName("FK_TB_ADS_Fuel_General_Type");

                entity.HasOne(d => d.Gearbox)
                    .WithMany(p => p.TbAdsGearbox)
                    .HasForeignKey(d => d.GearboxId)
                    .HasConstraintName("FK_TB_ADS_Gearbox_General_Type");

                entity.HasOne(d => d.Model)
                    .WithMany(p => p.TbAds)
                    .HasForeignKey(d => d.ModelId)
                    .HasConstraintName("FK_TB_ADS_Model_Car_Models");

                entity.HasOne(d => d.Transmission)
                    .WithMany(p => p.TbAdsTransmission)
                    .HasForeignKey(d => d.TransmissionId)
                    .HasConstraintName("FK_TB_ADS_Transmission_General_Type");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
