using System;
using System.Collections.Generic;
using System.IO.Enumeration;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using VTLP1J_ADT_2022_23_1.V2.Models;


namespace VTLP1J_ADT_2022_23_1.V2.Data
{

    public class LensDatabaseContext : DbContext
    {
        public DbSet<Manufacturer> Manufacturers;
        public DbSet<ILens> Lens;
        public DbSet<LensMount> LensMounts;

        public LensDatabaseContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;
                                                                AttachDbFilename=|DataDirectory|\Database_1.mdf;
                                                                Integrated Security=True;
                                                                MultipleActiveResultSets=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){


            #region Manufacturers
            Manufacturer Canon = new Manufacturer{Id = 1,
                Name = "Canon",
                CountryOfOrigin = "Japan",
                Established = new DateOnly(1937,08,10)};
            Canon.Lenses = new List<ILens>();
            
            Manufacturer Nikon = new Manufacturer{Id = 2,
                Name = "Nikon",
                CountryOfOrigin = "Japan",
                Established = new DateOnly(1917,07,25)};
            Nikon.Lenses = new List<ILens>();
            
            Manufacturer Sigma = new Manufacturer{Id = 3,
                Name = "Sigma",
                CountryOfOrigin = "Japan",
                Established = new DateOnly(1961,09,01)};
            Sigma.Lenses = new List<ILens>();   
            
            Manufacturer Tamron = new Manufacturer{Id = 4,
                Name = "Tamron",
                CountryOfOrigin = "Japan",
                Established = new DateOnly(1950,01,01)};
            Tamron.Lenses = new List<ILens>();
            
            Manufacturer Tokina = new Manufacturer{Id = 5,
                Name = "Tokina",
                CountryOfOrigin = "Japan",
                Established = new DateOnly(1950,01,01)};
            Tokina.Lenses = new List<ILens>();
            
            Manufacturer Leica = new Manufacturer() {Id = 6, 
                Name = "Leica",
                CountryOfOrigin = "Germany",
                Established = new DateOnly(1913, 01, 01)};
            Leica.Lenses = new List<ILens>();
            
            Manufacturer Zeiss = new Manufacturer() {Id = 7, 
                Name = "Zeiss",
                CountryOfOrigin = "Germany",
                Established = new DateOnly(1846, 01, 01)};
            Zeiss.Lenses = new List<ILens>();
            
            Manufacturer FED = new Manufacturer() {Id = 8, 
                Name = "FED",
                CountryOfOrigin = "Russia",
                Established = new DateOnly(1932, 01, 01)};
            FED.Lenses = new List<ILens>();
            #endregion

            #region Lens Mounts

            LensMount EF = new LensMount() {Id = 1, Name = "EF", Manufacturer = Canon, FlangeDistence = 44};
            LensMount EF_S = new LensMount() {Id = 2, Name = "EF-S", Manufacturer = Canon, FlangeDistence = 44};
            LensMount EF_M = new LensMount() {Id = 3, Name = "EF-M", Manufacturer = Canon, FlangeDistence = 18};
            LensMount RF = new LensMount() {Id = 4, Name = "RF", Manufacturer = Canon, FlangeDistence = 20};
            LensMount FD = new LensMount() {Id = 5, Name = "FD", Manufacturer = Canon, FlangeDistence = 42};
            LensMount F = new LensMount() {Id = 6, Name = "F", Manufacturer = Nikon, FlangeDistence = 46};
            LensMount Z = new LensMount() {Id = 7, Name = "Z", Manufacturer = Nikon, FlangeDistence = 16};
            LensMount M42 = new LensMount(){Id = 8, Name = "M42", Manufacturer = FED, FlangeDistence = 45.46};
            LensMount M39 = new LensMount(){Id = 9, Name = "M39", Manufacturer = FED, FlangeDistence = 28.80};
            LensMount M = new LensMount(){Id = 10, Name = "M", Manufacturer = Leica, FlangeDistence = 27.8};
            LensMount L = new LensMount(){Id = 11, Name = "L", Manufacturer = Leica, FlangeDistence = 20};
            LensMount R = new LensMount(){Id = 12, Name = "R", Manufacturer = Zeiss, FlangeDistence = 46};
            LensMount SA = new LensMount(){Id = 13, Name = "SA", Manufacturer = Sigma, FlangeDistence = 44};
            
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

            #region Fixed Lenses
            #region 50mm
            ILens _50mm_f1_8 = new FixedFocalLengthLens() { Id = 1, 
                FocalLength = 50, 
                Aperture = 1.8, 
                FilterSize = 55, 
                Manufacturer = Canon, 
                Mounts = CanonMounts,
                ManufacturerId = Canon.Id};
            Canon.Lenses.Add(_50mm_f1_8);
            
            ILens _50mm_f1_4_ssc = new FixedFocalLengthLens() { Id = 2, 
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Manufacturer = Canon,
                Mounts = new List<LensMount>(){FD},
                ManufacturerId = Canon.Id}; 
            Canon.Lenses.Add(_50mm_f1_4_ssc);
            
            ILens _50mm_f1_4_usm = new FixedFocalLengthLens() { Id = 3, 
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Manufacturer = Canon,
                Mounts = new List<LensMount>(){EF},
                ManufacturerId = Canon.Id};
            Canon.Lenses.Add(_50mm_f1_4_usm);
            
            ILens _50mm_f1_4 = new FixedFocalLengthLens() { Id = 4,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Manufacturer = Nikon,
                Mounts = new List<LensMount>(){F},
                ManufacturerId = Nikon.Id};
            Nikon.Lenses.Add(_50mm_f1_4);
            
            ILens _50mm_f1_4_afs = new FixedFocalLengthLens() { Id = 5,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Manufacturer = Nikon,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.Id};
            Nikon.Lenses.Add(_50mm_f1_4_afs);
            
            ILens _50mm_f1_4_afs_g = new FixedFocalLengthLens() { Id = 6,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Manufacturer = Nikon,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.Id};
            Nikon.Lenses.Add(_50mm_f1_4_afs_g);
            
            ILens noctilux_50mm_f0_95 = new FixedFocalLengthLens() { Id = 7,
                FocalLength = 50,
                Aperture = 0.95,
                FilterSize = 55,
                Manufacturer = Leica,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.Id};
            Leica.Lenses.Add(noctilux_50mm_f0_95);
            
            ILens summilux_50mm_f1_4_ASPH = new FixedFocalLengthLens() { Id = 8,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Manufacturer = Leica,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.Id};
            Leica.Lenses.Add(summilux_50mm_f1_4_ASPH);
            
            ILens Summicron = new FixedFocalLengthLens(){Id = 9,
                FocalLength = 50,
                Aperture = 2,
                FilterSize = 55,
                Manufacturer = Leica,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.Id};
            Leica.Lenses.Add(Summicron);
            
            ILens _50mm_f1_4_DG_HSM = new FixedFocalLengthLens(){Id = 10,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 77,
                Manufacturer = Sigma,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.Id};

            ILens SP_45mm_f_1_8_Di_VC_USD = new FixedFocalLengthLens(){Id = 11,
                FocalLength = 45,
                Aperture = 1.8,
                FilterSize = 67,
                Manufacturer = Tamron,
                Mounts = TamronMounts,
                ManufacturerId = Tamron.Id};
            Tamron.Lenses.Add(SP_45mm_f_1_8_Di_VC_USD);
            
            ILens Opera_50mm_f_1_4 = new FixedFocalLengthLens(){Id = 12,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 72,
                Manufacturer = Tokina,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.Id};
            Tokina.Lenses.Add(Opera_50mm_f_1_4);
            
            ILens atx_m_56_1_4_plus_e = new FixedFocalLengthLens(){Id = 13,
                FocalLength = 56,
                Aperture = 1.4,
                FilterSize = 52,
                Manufacturer = Tokina,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.Id};
            Tokina.Lenses.Add(atx_m_56_1_4_plus_e);
            #endregion

            #region 35mm
            ILens _35mm_f2_is_usm = new FixedFocalLengthLens(){Id = 14,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Manufacturer = Canon,
                Mounts = CanonMounts,
                ManufacturerId = Canon.Id};
            Canon.Lenses.Add(_35mm_f2_is_usm);
            
            ILens _35mm_f1_4_l_usm = new FixedFocalLengthLens(){Id = 15,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Manufacturer = Canon,
                Mounts = CanonMounts,
                ManufacturerId = Canon.Id};
            Canon.Lenses.Add(_35mm_f1_4_l_usm);
            
            ILens _35mm_f2_afs = new FixedFocalLengthLens(){Id = 16,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Manufacturer = Nikon,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.Id};
            Nikon.Lenses.Add(_35mm_f2_afs);

            ILens _35mm_f1_4_afs_g = new FixedFocalLengthLens(){ Id = 17,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Manufacturer = Nikon,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.Id};
            Nikon.Lenses.Add(_35mm_f1_4_afs_g);

            ILens _35mm_f1_2_DG_DN = new FixedFocalLengthLens(){Id = 18,
                FocalLength = 35,
                Aperture = 1.2,
                FilterSize = 77,
                Manufacturer = Sigma,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.Id};
            Sigma.Lenses.Add(_35mm_f1_2_DG_DN);
            
            ILens _35mm_f1_4_DG_HSM = new FixedFocalLengthLens(){Id = 19,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 77,
                Manufacturer = Sigma,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.Id};
            Sigma.Lenses.Add(_35mm_f1_4_DG_HSM);
            
            ILens atx_m_35_1_4_plus_e = new FixedFocalLengthLens(){Id = 20,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 52,
                Manufacturer = Tokina,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.Id};
            Tokina.Lenses.Add(atx_m_35_1_4_plus_e);
            
            ILens _35mm_f1_4_Di_VC_USD = new FixedFocalLengthLens(){Id = 21,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 67,
                Manufacturer = Tamron,
                Mounts = TamronMounts,
                ManufacturerId = Tamron.Id};
            Tamron.Lenses.Add(_35mm_f1_4_Di_VC_USD);
            
            ILens Summicron_M_f_2_ASPH = new FixedFocalLengthLens(){Id = 22,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Manufacturer = Leica,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.Id};
            Leica.Lenses.Add(Summicron_M_f_2_ASPH);
    
            ILens Summilux_M_f_1_4_ASPH = new FixedFocalLengthLens(){Id = 23,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Manufacturer = Leica,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.Id};
            Leica.Lenses.Add(Summilux_M_f_1_4_ASPH);
            
            
            #endregion
            

            #endregion

            #region Variable Focal
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
            

            #endregion

            modelBuilder.Entity<ILens>(entityBuild =>
            {
                entityBuild
                    .HasOne(lens => lens.Manufacturer)
                    .WithMany(manf => manf.Lenses)
                    .HasForeignKey(lens => lens.Id).OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ILens>()
                .HasDiscriminator<string>("LensType")
                .HasValue<FixedFocalLengthLens>("Fixed")
                .HasValue<VariableFocalLengthLens>("Variable");
            
           
            
            modelBuilder.Entity<LensMount>(entityBuilder =>
            {
                entityBuilder
                    .HasOne(lensM => lensM.Manufacturer)
                    .WithMany(manf => manf.LensMounts)
                    .HasForeignKey(lensM => lensM.Id)
                    .OnDelete(DeleteBehavior.SetNull);

            });
            
            modelBuilder.Entity<Manufacturer>().HasData(
                Canon,
                Nikon,
                Sigma,
                Tamron,
                Tokina,
                Leica
            );

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
            modelBuilder.Entity<ILens>().HasData(
                _14_24mm_f2_8_afs,
                _14_24mm_f2_8_is_usm,
                _24_105mm_f4_dg_hs_osm,
                _24_70mm_f2_8_afs,
                _24_70mm_f2_8_afs_g,
                _24_70mm_f2_8_is_usm,
                _35mm_f1_4_Di_VC_USD
                ,noctilux_50mm_f0_95,
                summilux_50mm_f1_4_ASPH,
                Summilux_M_f_1_4_ASPH,
                Summicron_M_f_2_ASPH,
                Tri_Elmar_M_28_35_50mm_f_4_asph,
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
                _24_105mm_f4_dg_hs_osm,
                _50mm_f1_4_ssc,
                _35mm_f1_4_DG_HSM,
                _50mm_f1_4_DG_HSM
            );
        }


    }
}

