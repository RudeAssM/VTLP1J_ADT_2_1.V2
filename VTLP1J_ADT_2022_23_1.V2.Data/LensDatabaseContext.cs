using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore.Proxies;
using Microsoft.EntityFrameworkCore;
using VTLP1J_ADT_2022_23_1.V2.Models;

 
namespace VTLP1J_ADT_2022_23_1.V2.Data
{

    public class LensDatabaseContext : DbContext
    {
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<Lens> Lens { get; set; }
        public virtual DbSet<LensMount> LensMounts { get; set; }
        
        public LensDatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        public LensDatabaseContext(DbContextOptions<LensDatabaseContext> options) : base(options)
        {
            
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               optionsBuilder
                   .UseLazyLoadingProxies()
                   .UseInMemoryDatabase("LensDatabase");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            

            #region Manufacturers

            int ManufacturerId = 0;
            Manufacturer Canon = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Canon",
                CountryOfOrigin = "Japan",
                Established = new DateOnly(1937,08,10)};
            Canon.Lenses = new List<Lens>();
            
            Manufacturer Nikon = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Nikon",
                CountryOfOrigin = "Japan",
                Established = new DateOnly(1917,07,25)};
            Nikon.Lenses = new List<Lens>();
            
            Manufacturer Sigma = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Sigma",
                CountryOfOrigin = "Japan",
                Established = new DateOnly(1961,09,01)};
            Sigma.Lenses = new List<Lens>();   
            
            Manufacturer Tamron = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Tamron",
                CountryOfOrigin = "Japan",
                Established = new DateOnly(1950,01,01)};
            Tamron.Lenses = new List<Lens>();
            
            Manufacturer Tokina = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Tokina",
                CountryOfOrigin = "Japan",
                Established = new DateOnly(1950,01,01)};
            Tokina.Lenses = new List<Lens>();
            
            Manufacturer Leica = new Manufacturer() {  ManufacturerId = ManufacturerId++,
                Name = "Leica",
                CountryOfOrigin = "Germany",
                Established = new DateOnly(1913, 01, 01)};
            Leica.Lenses = new List<Lens>();
            
            Manufacturer Zeiss = new Manufacturer() {  ManufacturerId = ManufacturerId++,
                Name = "Zeiss",
                CountryOfOrigin = "Germany",
                Established = new DateOnly(1846, 01, 01)};
            Zeiss.Lenses = new List<Lens>();
            
            Manufacturer FED = new Manufacturer() {  ManufacturerId = ManufacturerId++,
                Name = "FED",
                CountryOfOrigin = "Russia",
                Established = new DateOnly(1932, 01, 01)};
            FED.Lenses = new List<Lens>();
            #endregion

            #region Lens Mounts
            int LensMountIDCounter = 0;


            LensMount EF = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "EF", 
                Manufacturer = Canon, 
                FlangeDistence = 44};
            LensMount EF_S = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "EF-S", 
                Manufacturer = Canon, 
                FlangeDistence = 44};
            LensMount EF_M = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "EF-M", 
                Manufacturer = Canon, 
                FlangeDistence = 18};
            LensMount RF = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "RF", 
                Manufacturer = Canon, 
                FlangeDistence = 20};
            LensMount FD = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "FD", 
                Manufacturer = Canon, 
                FlangeDistence = 42};
            LensMount F = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "F", 
                Manufacturer = Nikon, 
                FlangeDistence = 46};
            LensMount Z = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "Z",
                Manufacturer = Nikon, 
                FlangeDistence = 16};
            LensMount M42 = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "M42", 
                Manufacturer = FED, 
                FlangeDistence = 45.46};
            LensMount M39 = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "M39",
                Manufacturer = FED, 
                FlangeDistence = 28.80};
            LensMount M = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "M", 
                Manufacturer = Leica, 
                FlangeDistence = 27.8};
            LensMount L = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "L",
                Manufacturer = Leica, 
                FlangeDistence = 20};
            LensMount R = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "R",
                Manufacturer = Zeiss,
                FlangeDistence = 46};
            LensMount SA = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "SA", 
                Manufacturer = Sigma, 
                FlangeDistence = 44};
            
            #endregion

            #region LensMountsConnection
            ICollection<LensMount> CanonMounts = new List<LensMount>(){EF, EF_S, EF_M, RF, FD};
            ICollection<LensMount> NikonMounts = new List<LensMount>(){F, Z};
            ICollection<LensMount> SigmaMounts = new List<LensMount>(){SA,EF, EF_S, EF_M, RF, F, Z,FD};
            ICollection<LensMount> TamronMounts = new List<LensMount>(){EF, EF_S, EF_M, RF, F, Z,FD};
            ICollection<LensMount> TokinaMounts = new List<LensMount>(){FD,M42,F,EF};
            ICollection<LensMount> LeicaMounts = new List<LensMount>(){M, L, M39};
            ICollection<LensMount> ZeissMounts = new List<LensMount>(){R,L,M,M42};
            ICollection<LensMount> FEDMounts = new List<LensMount>(){M42,M39};

            #endregion
            int LensIDCounter = 0;
            #region Fixed Lenses
            #region 50mm
            Lens _50mm_f1_8 = new Lens() { LensId = LensIDCounter++,
                FocalLength = 50, 
                Aperture = 1.8, 
                FilterSize = 55, 
                Mounts = CanonMounts,
                ManufacturerId = Canon.ManufacturerId};
            
            Lens _50mm_f1_4_ssc = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){FD},
                ManufacturerId = Canon.ManufacturerId}; 
            
            Lens _50mm_f1_4_usm = new Lens() { LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){EF},
                ManufacturerId = Canon.ManufacturerId};
            
            Lens _50mm_f1_4 = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){F},
                ManufacturerId = Nikon.ManufacturerId};
            
            Lens _50mm_f1_4_afs = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId};
            
            Lens _50mm_f1_4_afs_g = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId};
            
            Lens noctilux_50mm_f0_95 = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 0.95,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            
            Lens summilux_50mm_f1_4_ASPH = new Lens() { LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            
            Lens Summicron = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 2,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            
            Lens _50mm_f1_4_DG_HSM = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 77,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.ManufacturerId};

            Lens SP_45mm_f_1_8_Di_VC_USD = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 45,
                Aperture = 1.8,
                FilterSize = 67,
                Mounts = TamronMounts,
                ManufacturerId = Tamron.ManufacturerId};
            
            Lens Opera_50mm_f_1_4 = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 72,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.ManufacturerId};
            
            Lens atx_m_56_1_4_plus_e = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 56,
                Aperture = 1.4,
                FilterSize = 52,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.ManufacturerId};
            #endregion

            #region 35mm
            Lens _35mm_f2_is_usm = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Mounts = CanonMounts,
                ManufacturerId = Canon.ManufacturerId};
            
            Lens _35mm_f1_4_l_usm = new Lens(){  LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = CanonMounts,
                ManufacturerId = Canon.ManufacturerId};
            
            Lens _35mm_f2_afs = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId};

            Lens _35mm_f1_4_afs_g = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId};

            Lens _35mm_f1_2_DG_DN = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.2,
                FilterSize = 77,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.ManufacturerId};
            
            Lens _35mm_f1_4_DG_HSM = new Lens(){  LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 77,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.ManufacturerId};
            
            Lens atx_m_35_1_4_plus_e = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 52,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.ManufacturerId};
            
            Lens _35mm_f1_4_Di_VC_USD = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 67,
                Mounts = TamronMounts,
                ManufacturerId = Tamron.ManufacturerId};
            
            
            Lens Summicron_M_f_2_ASPH = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            
    
            Lens Summilux_M_f_1_4_ASPH = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            
            
            
            #endregion
            

            #endregion
            
            #region Variable Focal

/*
            ILens _24_70mm_f2_8_is_usm = new VariableFocalLengthLens(){Id = 24,
                FocalLengthMin = 24,
                FocalLengthMax = 70,
                Aperture = 2.8,
                FilterSize = 77,
                Manufacturer = Canon,
                Mounts = CanonMounts,
                ManufacturerId = Canon.Id};
            Canon.Lenses.Add(_24_70mm_f2_8_is_usm);

            ILens _24_70mm_f2_8_afs = new VariableFocalLengthLens(){Id = 25,
                FocalLengthMin = 24,
                FocalLengthMax = 70,
                Aperture = 2.8,
                FilterSize = 77,
                Manufacturer = Nikon,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.Id};
            Nikon.Lenses.Add(_24_70mm_f2_8_afs);
            
            ILens _24_70mm_f2_8_afs_g = new VariableFocalLengthLens(){ Id = 26,
                FocalLengthMin = 24,
                FocalLengthMax = 70,
                Aperture = 2.8,
                FilterSize = 77,
                Manufacturer = Nikon,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.Id};
            Nikon.Lenses.Add(_24_70mm_f2_8_afs_g);
            
            
            ILens Tri_Elmar_M_28_35_50mm_f_4_asph = new VariableFocalLengthLens(){Id = 27,
                FocalLengthMin = 28,
                FocalLengthMax = 50,
                Aperture = 4,
                FilterSize = 55,
                Manufacturer = Leica,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.Id};
            Leica.Lenses.Add(Tri_Elmar_M_28_35_50mm_f_4_asph);
            
            ILens _14_24mm_f2_8_is_usm = new VariableFocalLengthLens(){Id = 28,
                FocalLengthMin = 14,
                FocalLengthMax = 24,
                Aperture = 2.8,
                FilterSize = 77,
                Manufacturer = Canon,
                Mounts = CanonMounts,
                ManufacturerId = Canon.Id};
            Canon.Lenses.Add(_14_24mm_f2_8_is_usm);
            
            ILens _14_24mm_f2_8_afs = new VariableFocalLengthLens(){Id = 29,
                FocalLengthMin = 14,
                FocalLengthMax = 24,
                Aperture = 2.8,
                FilterSize = 77,
                Manufacturer = Nikon,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.Id};
            Nikon.Lenses.Add(_14_24mm_f2_8_afs);
            
            ILens _24_105mm_f4_dg_hs_osm = new VariableFocalLengthLens(){Id = 30,
                FocalLengthMin = 24,
                FocalLengthMax = 105,
                Aperture = 4,
                FilterSize = 77,
                Manufacturer = Sigma,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.Id};
            Sigma.Lenses.Add(_24_105mm_f4_dg_hs_osm);
            

*/

            #endregion
            
            modelBuilder.Entity<Lens>(entity =>
            {
                entity
                    .HasOne(lens => lens.Manufacturer)
                    .WithMany(manf => manf.Lenses)
                    .HasForeignKey(lens => lens.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });


            modelBuilder.Entity<Manufacturer>().HasData(
                Canon,
                Nikon,
                Sigma,
                Tamron,
                Tokina,
                Leica
            );
            /*
            modelBuilder.Entity<LensMount>().HasData(
                CanonMounts, 
                NikonMounts, 
                SigmaMounts, 
                TamronMounts, 
                TokinaMounts, 
                LeicaMounts, 
                ZeissMounts,
                FEDMounts
            );
            
            */
            modelBuilder.Entity<Lens>().HasData(
                
                _35mm_f1_4_Di_VC_USD,
                summilux_50mm_f1_4_ASPH,
                Summilux_M_f_1_4_ASPH,
                Summicron_M_f_2_ASPH,
                SP_45mm_f_1_8_Di_VC_USD,
                _35mm_f1_4_afs_g,
                _35mm_f1_4_l_usm,
                _35mm_f2_afs,
                _35mm_f2_is_usm,
                _50mm_f1_4,
                _50mm_f1_4_afs,
                _50mm_f1_4_afs_g,
                _50mm_f1_4_usm,
                _35mm_f1_2_DG_DN,
                atx_m_35_1_4_plus_e,
                atx_m_56_1_4_plus_e,
                Opera_50mm_f_1_4,
                noctilux_50mm_f0_95,
                _50mm_f1_8,
                _50mm_f1_4_ssc,
                _35mm_f1_4_DG_HSM,
                _50mm_f1_4_DG_HSM
            );


        }


    }
}

