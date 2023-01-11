
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using VTLP1J_ADT_2022_23_1.V2.Logic;
using VTLP1J_ADT_2022_23_1.V2.Models;
using VTLP1J_ADT_2022_23_1.V2.Repository;

namespace VTLP1J_ADT_2022_23_1.V2.Test
{
    [TestFixture]
    public class LenseLogicTest
    {
        private LensLogic _lensLogic;
        private ManufacturerLogic _manufacturerLogic;
        private LensMountLogic _lensMountLogic;
        

        [SetUp]
        public void Setup()
        {   
            Mock<IManufacturerRepository> mockManufacturerRepo = new Mock<IManufacturerRepository>();
            Mock<ILensRepository> mockLensRepo = new Mock<ILensRepository>();
            Mock<ILensMountRepository> mockLensMountRepo = new Mock<ILensMountRepository>();
            Manufacturer manufacturer = new Manufacturer()
            {
                ManufacturerId = 4,
                Name = "Nikon",
                CountryOfOrigin = "Japan",
                Established = DateTime.Today,
                Lenses = new List<Lens>(),
                LensMounts = new List<LensMount>() ,
            };
            
            LensMount mount = new LensMount()
            {
                LensMountId = 5,
                Name ="F",
                FlangeDistence = 44,
                Manufacturer = manufacturer,
                ManufacturerId = manufacturer.ManufacturerId,
                
            };

            Lens lens = new Lens()
            {
                LensId = 7,
                Aperture = 1.8,
                FocalLength = 50,
                FilterSize = 52,
                Manufacturer = manufacturer,
                ManufacturerId = manufacturer.ManufacturerId,
                Mounts = new List<LensMount>()
            };

            manufacturer.Lenses.Add(lens);
            manufacturer.LensMounts.Add(mount);
            lens.Mounts.Add(mount);
            
            mockManufacturerRepo.Setup(x => x.GetOne(It.IsAny<int>())).Returns(manufacturer);
            mockLensRepo.Setup(x => x.GetOne(It.IsAny<int>())).Returns(lens);
            mockLensMountRepo.Setup(x => x.GetOne(It.IsAny<int>())).Returns(mount);
            
            
            mockLensRepo.Setup(x => x.GetAll()).Returns(this.fakeLenses);
            mockManufacturerRepo.Setup(x => x.GetAll()).Returns(this.fakeManufacturers);
            mockLensMountRepo.Setup(x => x.GetAll()).Returns(this.fakeLensMounts);

            this._lensLogic = new LensLogic(mockLensRepo.Object);
            this._manufacturerLogic = new ManufacturerLogic(mockManufacturerRepo.Object);
            this._lensMountLogic = new LensMountLogic(mockLensMountRepo.Object);
            
        }
        
        
        [Test]
        public void GetOneLensCorrectInstance()
        {
            var lens = this._lensLogic.GetLens(1);
            Assert.AreEqual(lens.Aperture, Is.EqualTo(1.8));
        }
        [Test]
        public void GetOneManufacturerCorrectInstance()
        {
            var manufacturer = this._manufacturerLogic.Get(1);
            Assert.AreEqual(manufacturer.Name, Is.EqualTo("Canon"));
        }
        [Test]
        public void GetOneLensMountCorrectInstance()
        {
            var lensMount = this._lensMountLogic.GetLensMount(1);
            Assert.AreEqual(lensMount.Name, Is.EqualTo("EF"));
        }
        
        [Test]
        public void GettAllLensesCorrectInstance()
        {
            Assert.AreEqual(this._lensLogic.GetAllLenses().Count(), Is.EqualTo(21));
        }
        [Test]
        public void GettAllManufacturersCorrectInstance()
        {
            Assert.AreEqual(this._manufacturerLogic.GetAllManufacturers().Count(), Is.EqualTo(8));
        }
        [Test]
        public void GettAllLensMountsCorrectInstance()
        {
            Assert.AreEqual(this._lensMountLogic.GetAllLensMounts().Count(), Is.EqualTo(11));
        }

        [Test]
        public void GetManufacturerBycountryOfOrigin()
        {
            Assert.AreEqual(this._manufacturerLogic.GetManufacturersByCountry("Japan").Count(), Is.EqualTo(5));
        }
        
        [TestCase(30)]
        [TestCase(1000)]
        [TestCase(0)]
        public void updateLensMountsManufacturer_throwsException_ifIndexNonexistent(int index)
        {
            Assert.That(() => this._lensMountLogic.UpdateLensMountManufacturer(index, new Manufacturer()), Throws.Exception);
        }        
        [TestCase(30)]
        [TestCase(1000)]
        [TestCase(0)]
        public void updateLensLensMounts_throwsException_ifIndexNonexistent(int index)
        {
            Assert.That(() => this._lensLogic.UpdateLensMount(index, new List<LensMount>()), Throws.Exception);
        }

        [Test]
        public void GetallManufacturerLenseMounts()
        {
            Assert.AreEqual(this._manufacturerLogic.GetAllLensMountsOfManufacturer(1).Count(), Is.EqualTo(5));
        }
        
    


        private IQueryable<Manufacturer> fakeManufacturers()
        {

            #region Manufacturers

            int ManufacturerId = 0;
            Manufacturer Canon = new Manufacturer()
            {
                ManufacturerId = ManufacturerId++,
                Name = "Canon",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1937, 08, 10)
            };
            Canon.Lenses = new List<Lens>();

            Manufacturer Nikon = new Manufacturer()
            {
                ManufacturerId = ManufacturerId++,
                Name = "Nikon",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1917, 07, 25)
            };
            Nikon.Lenses = new List<Lens>();

            Manufacturer Sigma = new Manufacturer()
            {
                ManufacturerId = ManufacturerId++,
                Name = "Sigma",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1961, 09, 01)
            };
            Sigma.Lenses = new List<Lens>();

            Manufacturer Tamron = new Manufacturer()
            {
                ManufacturerId = ManufacturerId++,
                Name = "Tamron",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1950, 01, 01)
            };
            Tamron.Lenses = new List<Lens>();

            Manufacturer Tokina = new Manufacturer()
            {
                ManufacturerId = ManufacturerId++,
                Name = "Tokina",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1950, 01, 01)
            };
            Tokina.Lenses = new List<Lens>();

            Manufacturer Leica = new Manufacturer()
            {
                ManufacturerId = ManufacturerId++,
                Name = "Leica",
                CountryOfOrigin = "Germany",
                Established = new DateTime(1913, 01, 01)
            };
            Leica.Lenses = new List<Lens>();

            Manufacturer Zeiss = new Manufacturer()
            {
                ManufacturerId = ManufacturerId++,
                Name = "Zeiss",
                CountryOfOrigin = "Germany",
                Established = new DateTime(1846, 01, 01)
            };
            Zeiss.Lenses = new List<Lens>();

            Manufacturer FED = new Manufacturer()
            {
                ManufacturerId = ManufacturerId++,
                Name = "FED",
                CountryOfOrigin = "Russia",
                Established = new DateTime(1932, 01, 01)
            };
            FED.Lenses = new List<Lens>();

            #endregion

            #region Lens Mounts

            int LensMountIDCounter = 0;


            LensMount EF = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "EF",
                ManufacturerId = Canon.ManufacturerId,
                FlangeDistence = 44
            };
            LensMount EF_S = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "EF-S",
                ManufacturerId = Canon.ManufacturerId,
                FlangeDistence = 44
            };
            LensMount EF_M = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "EF-M",
                ManufacturerId = Canon.ManufacturerId,
                FlangeDistence = 18
            };
            LensMount RF = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "RF",
                ManufacturerId = Canon.ManufacturerId,
                FlangeDistence = 20
            };
            LensMount FD = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "FD",
                ManufacturerId = Canon.ManufacturerId,
                FlangeDistence = 42
            };
            LensMount F = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "F",
                ManufacturerId = Nikon.ManufacturerId,
                FlangeDistence = 46
            };
            LensMount Z = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "Z",
                ManufacturerId = Nikon.ManufacturerId,
                FlangeDistence = 16
            };
            LensMount M42 = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "M42",
                ManufacturerId = FED.ManufacturerId,
                FlangeDistence = 45.46
            };
            LensMount M39 = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "M39",
                ManufacturerId = FED.ManufacturerId,
                FlangeDistence = 28.80
            };
            LensMount M = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "M",
                ManufacturerId = Leica.ManufacturerId,
                FlangeDistence = 27.8
            };
            LensMount L = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "L",
                ManufacturerId = Leica.ManufacturerId,
                FlangeDistence = 20
            };
            LensMount R = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "R",
                ManufacturerId = Zeiss.ManufacturerId,
                FlangeDistence = 46
            };
            LensMount SA = new LensMount()
            {
                LensMountId = LensMountIDCounter++,
                Name = "SA",
                ManufacturerId = Sigma.ManufacturerId,
                FlangeDistence = 44
            };

            #endregion
            Canon.LensMounts = new List<LensMount>() { EF, EF_S, EF_M, RF, FD };
            Nikon.LensMounts = new List<LensMount>() { F, Z };
            Sigma.LensMounts = new List<LensMount>() { SA, EF, EF_S, EF_M, RF, F, Z, FD };
            Tamron.LensMounts= new List<LensMount>() { EF, EF_S, EF_M, RF, F, Z, FD };
            Tokina.LensMounts = new List<LensMount>() { FD, M42, F, EF };
            Leica.LensMounts= new List<LensMount>() { M, L, M39 };
            Zeiss.LensMounts = new List<LensMount>() { R, L, M, M42 };
            FED.LensMounts = new List<LensMount>() { M42, M39 };
            #region LensMountsConnection

            ICollection<LensMount> CanonMounts = new List<LensMount>() { EF, EF_S, EF_M, RF, FD };
            ICollection<LensMount> NikonMounts = new List<LensMount>() { F, Z };
            ICollection<LensMount> SigmaMounts = new List<LensMount>() { SA, EF, EF_S, EF_M, RF, F, Z, FD };
            ICollection<LensMount> TamronMounts = new List<LensMount>() { EF, EF_S, EF_M, RF, F, Z, FD };
            ICollection<LensMount> TokinaMounts = new List<LensMount>() { FD, M42, F, EF };
            ICollection<LensMount> LeicaMounts = new List<LensMount>() { M, L, M39 };
            ICollection<LensMount> ZeissMounts = new List<LensMount>() { R, L, M, M42 };
            ICollection<LensMount> FEDMounts = new List<LensMount>() { M42, M39 };

            #endregion

            int LensIDCounter = 0;

            #region Fixed Lenses

            #region 50mm

            Lens _50mm_f1_8 = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.8,
                FilterSize = 55,
                Mounts = CanonMounts,
                ManufacturerId = Canon.ManufacturerId
            };
            Canon.Lenses.Add(_50mm_f1_8);
            Lens _50mm_f1_4_ssc = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>() { FD },
                ManufacturerId = Canon.ManufacturerId
            };
            Canon.Lenses.Add(_50mm_f1_4_ssc);
            Lens _50mm_f1_4_usm = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>() { EF },
                ManufacturerId = Canon.ManufacturerId
            };
            Canon.Lenses.Add(_50mm_f1_4_usm);
            Lens _50mm_f1_4 = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>() { F },
                ManufacturerId = Nikon.ManufacturerId
            };
            Canon.Lenses.Add(_50mm_f1_4);
            Lens _50mm_f1_4_afs = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId
            };
            Canon.Lenses.Add(_50mm_f1_4_afs);
            Lens _50mm_f1_4_afs_g = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId
            };
            Nikon.Lenses.Add(_50mm_f1_4_afs_g);
            Lens noctilux_50mm_f0_95 = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 0.95,
                FilterSize = 55,
                Mounts = new List<LensMount>() { L },
                ManufacturerId = Leica.ManufacturerId
            };
            Leica.Lenses.Add(noctilux_50mm_f0_95);
            Lens summilux_50mm_f1_4_ASPH = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>() { L },
                ManufacturerId = Leica.ManufacturerId
            };
            Leica.Lenses.Add(summilux_50mm_f1_4_ASPH);
            Lens Summicron = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 2,
                FilterSize = 55,
                Mounts = new List<LensMount>() { L },
                ManufacturerId = Leica.ManufacturerId
            };
            Leica.Lenses.Add(Summicron);
            Lens _50mm_f1_4_DG_HSM = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 77,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.ManufacturerId
            };
            Sigma.Lenses.Add(_50mm_f1_4_DG_HSM);
            Lens SP_45mm_f_1_8_Di_VC_USD = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 45,
                Aperture = 1.8,
                FilterSize = 67,
                Mounts = TamronMounts,
                ManufacturerId = Tamron.ManufacturerId
            };
            Tamron.Lenses.Add(SP_45mm_f_1_8_Di_VC_USD);
            Lens Opera_50mm_f_1_4 = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 72,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.ManufacturerId
            };
            Tokina.Lenses.Add(Opera_50mm_f_1_4);
            Lens atx_m_56_1_4_plus_e = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 56,
                Aperture = 1.4,
                FilterSize = 52,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.ManufacturerId
            };

            #endregion

            #region 35mm

            Lens _35mm_f2_is_usm = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Mounts = CanonMounts,
                ManufacturerId = Canon.ManufacturerId
            };
            Canon.Lenses.Add(_35mm_f2_is_usm);
            Lens _35mm_f1_4_l_usm = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = CanonMounts,
                ManufacturerId = Canon.ManufacturerId
            };
            Canon.Lenses.Add(_35mm_f1_4_l_usm);
            Lens _35mm_f2_afs = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId
            };
            Nikon.Lenses.Add(_35mm_f2_afs);
            Lens _35mm_f1_4_afs_g = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId
            };
            Nikon.Lenses.Add(_35mm_f1_4_afs_g);
            Lens _35mm_f1_2_DG_DN = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.2,
                FilterSize = 77,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.ManufacturerId
            };
            Sigma.Lenses.Add(_35mm_f1_2_DG_DN);
            Lens _35mm_f1_4_DG_HSM = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 77,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.ManufacturerId
            };
            Sigma.Lenses.Add(_35mm_f1_4_DG_HSM);
            Lens atx_m_35_1_4_plus_e = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 52,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.ManufacturerId
            };
            Tokina.Lenses.Add(atx_m_35_1_4_plus_e);
            Lens _35mm_f1_4_Di_VC_USD = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 67,
                Mounts = TamronMounts,
                ManufacturerId = Tamron.ManufacturerId
            };

            Tamron.Lenses.Add(_35mm_f1_4_Di_VC_USD);
            Lens Summicron_M_f_2_ASPH = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Mounts = new List<LensMount>() { L },
                ManufacturerId = Leica.ManufacturerId
            };
            Leica.Lenses.Add(Summicron_M_f_2_ASPH);

            Lens Summilux_M_f_1_4_ASPH = new Lens()
            {
                LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>() { L },
                ManufacturerId = Leica.ManufacturerId
            };

            Leica.Lenses.Add(Summilux_M_f_1_4_ASPH);

            #endregion

            #endregion

            List<Manufacturer> items = new List<Manufacturer>()
                { Canon, Nikon, Sigma, Tamron, Tokina, Leica, FED, Zeiss };


            return items.AsQueryable();
        }
        private IQueryable<Lens> fakeLenses()
        {
            
            #region Manufacturers
            
            int ManufacturerId = 0;
            Manufacturer Canon = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Canon",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1937,08,10)};
            Canon.Lenses = new List<Lens>();
            
            Manufacturer Nikon = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Nikon",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1917,07,25)};
            Nikon.Lenses = new List<Lens>();
            
            Manufacturer Sigma = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Sigma",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1961,09,01)};
            Sigma.Lenses = new List<Lens>();   
            
            Manufacturer Tamron = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Tamron",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1950,01,01)};
            Tamron.Lenses = new List<Lens>();
            
            Manufacturer Tokina = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Tokina",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1950,01,01)};
            Tokina.Lenses = new List<Lens>();
            
            Manufacturer Leica = new Manufacturer() {  ManufacturerId = ManufacturerId++,
                Name = "Leica",
                CountryOfOrigin = "Germany",
                Established = new DateTime(1913, 01, 01)};
            Leica.Lenses = new List<Lens>();
            
            Manufacturer Zeiss = new Manufacturer() {  ManufacturerId = ManufacturerId++,
                Name = "Zeiss",
                CountryOfOrigin = "Germany",
                Established = new DateTime(1846, 01, 01)};
            Zeiss.Lenses = new List<Lens>();
            
            Manufacturer FED = new Manufacturer() {  ManufacturerId = ManufacturerId++,
                Name = "FED",
                CountryOfOrigin = "Russia",
                Established = new DateTime(1932, 01, 01)};
            FED.Lenses = new List<Lens>();
            #endregion

            #region Lens Mounts
            int LensMountIDCounter = 0;


            LensMount EF = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "EF", 
                ManufacturerId = Canon.ManufacturerId, 
                FlangeDistence = 44};
            LensMount EF_S = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "EF-S", 
                ManufacturerId = Canon.ManufacturerId, 
                FlangeDistence = 44};
            LensMount EF_M = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "EF-M", 
                ManufacturerId = Canon.ManufacturerId, 
                FlangeDistence = 18};
            LensMount RF = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "RF", 
                ManufacturerId = Canon.ManufacturerId, 
                FlangeDistence = 20};
            LensMount FD = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "FD", 
                ManufacturerId = Canon.ManufacturerId, 
                FlangeDistence = 42};
            LensMount F = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "F", 
                ManufacturerId = Nikon.ManufacturerId, 
                FlangeDistence = 46};
            LensMount Z = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "Z",
                ManufacturerId = Nikon.ManufacturerId, 
                FlangeDistence = 16};
            LensMount M42 = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "M42", 
                ManufacturerId = FED.ManufacturerId, 
                FlangeDistence = 45.46};
            LensMount M39 = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "M39",
                ManufacturerId = FED.ManufacturerId, 
                FlangeDistence = 28.80};
            LensMount M = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "M", 
                ManufacturerId = Leica.ManufacturerId, 
                FlangeDistence = 27.8};
            LensMount L = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "L",
                ManufacturerId = Leica.ManufacturerId, 
                FlangeDistence = 20};
            LensMount R = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "R",
                ManufacturerId = Zeiss.ManufacturerId,
                FlangeDistence = 46};
            LensMount SA = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "SA", 
                ManufacturerId = Sigma.ManufacturerId, 
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
            Canon.Lenses.Add(_50mm_f1_8);
            Lens _50mm_f1_4_ssc = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){FD},
                ManufacturerId = Canon.ManufacturerId}; 
            Canon.Lenses.Add(_50mm_f1_4_ssc);
            Lens _50mm_f1_4_usm = new Lens() { LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){EF},
                ManufacturerId = Canon.ManufacturerId};
            Canon.Lenses.Add(_50mm_f1_4_usm);
            Lens _50mm_f1_4 = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){F},
                ManufacturerId = Nikon.ManufacturerId};
            Canon.Lenses.Add(_50mm_f1_4);
            Lens _50mm_f1_4_afs = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId};
            Canon.Lenses.Add(_50mm_f1_4_afs);
            Lens _50mm_f1_4_afs_g = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId};
            Nikon.Lenses.Add(_50mm_f1_4_afs_g);
            Lens noctilux_50mm_f0_95 = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 0.95,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            Leica.Lenses.Add(noctilux_50mm_f0_95);            
            Lens summilux_50mm_f1_4_ASPH = new Lens() { LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            Leica.Lenses.Add(summilux_50mm_f1_4_ASPH);
            Lens Summicron = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 2,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            Leica.Lenses.Add(Summicron);      
            Lens _50mm_f1_4_DG_HSM = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 77,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.ManufacturerId};
            Sigma.Lenses.Add(_50mm_f1_4_DG_HSM);
            Lens SP_45mm_f_1_8_Di_VC_USD = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 45,
                Aperture = 1.8,
                FilterSize = 67,
                Mounts = TamronMounts,
                ManufacturerId = Tamron.ManufacturerId};
            Tamron.Lenses.Add(SP_45mm_f_1_8_Di_VC_USD);    
            Lens Opera_50mm_f_1_4 = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 72,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.ManufacturerId};
            Tokina.Lenses.Add(Opera_50mm_f_1_4);           
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
            Canon.Lenses.Add(_35mm_f2_is_usm);    
            Lens _35mm_f1_4_l_usm = new Lens(){  LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = CanonMounts,
                ManufacturerId = Canon.ManufacturerId};
            Canon.Lenses.Add(_35mm_f1_4_l_usm);        
            Lens _35mm_f2_afs = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId};
            Nikon.Lenses.Add(_35mm_f2_afs);
            Lens _35mm_f1_4_afs_g = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId};
            Nikon.Lenses.Add(_35mm_f1_4_afs_g);
            Lens _35mm_f1_2_DG_DN = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.2,
                FilterSize = 77,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.ManufacturerId};
            Sigma.Lenses.Add(_35mm_f1_2_DG_DN);
            Lens _35mm_f1_4_DG_HSM = new Lens(){  LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 77,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.ManufacturerId};
            Sigma.Lenses.Add(_35mm_f1_4_DG_HSM);
            Lens atx_m_35_1_4_plus_e = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 52,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.ManufacturerId};
            Tokina.Lenses.Add(atx_m_35_1_4_plus_e);
            Lens _35mm_f1_4_Di_VC_USD = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 67,
                Mounts = TamronMounts,
                ManufacturerId = Tamron.ManufacturerId};
            
            Tamron.Lenses.Add(_35mm_f1_4_Di_VC_USD);
            Lens Summicron_M_f_2_ASPH = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            Leica.Lenses.Add(Summicron_M_f_2_ASPH); 
    
            Lens Summilux_M_f_1_4_ASPH = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            
            Leica.Lenses.Add(Summilux_M_f_1_4_ASPH);
            #endregion
            #endregion
            
            List<Lens> items = new List<Lens>() {                 
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
                _50mm_f1_4_DG_HSM};

            
            return items.AsQueryable();
        }
        private IQueryable<LensMount> fakeLensMounts()
        {
            
            #region Manufacturers
            
            int ManufacturerId = 0;
            Manufacturer Canon = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Canon",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1937,08,10)};
            Canon.Lenses = new List<Lens>();
            
            Manufacturer Nikon = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Nikon",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1917,07,25)};
            Nikon.Lenses = new List<Lens>();
            
            Manufacturer Sigma = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Sigma",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1961,09,01)};
            Sigma.Lenses = new List<Lens>();   
            
            Manufacturer Tamron = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Tamron",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1950,01,01)};
            Tamron.Lenses = new List<Lens>();
            
            Manufacturer Tokina = new Manufacturer(){ ManufacturerId = ManufacturerId++,
                Name = "Tokina",
                CountryOfOrigin = "Japan",
                Established = new DateTime(1950,01,01)};
            Tokina.Lenses = new List<Lens>();
            
            Manufacturer Leica = new Manufacturer() {  ManufacturerId = ManufacturerId++,
                Name = "Leica",
                CountryOfOrigin = "Germany",
                Established = new DateTime(1913, 01, 01)};
            Leica.Lenses = new List<Lens>();
            
            Manufacturer Zeiss = new Manufacturer() {  ManufacturerId = ManufacturerId++,
                Name = "Zeiss",
                CountryOfOrigin = "Germany",
                Established = new DateTime(1846, 01, 01)};
            Zeiss.Lenses = new List<Lens>();
            
            Manufacturer FED = new Manufacturer() {  ManufacturerId = ManufacturerId++,
                Name = "FED",
                CountryOfOrigin = "Russia",
                Established = new DateTime(1932, 01, 01)};
            FED.Lenses = new List<Lens>();
            #endregion

            #region Lens Mounts
            int LensMountIDCounter = 0;


            LensMount EF = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "EF", 
                ManufacturerId = Canon.ManufacturerId, 
                FlangeDistence = 44};
            LensMount EF_S = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "EF-S", 
                ManufacturerId = Canon.ManufacturerId, 
                FlangeDistence = 44};
            LensMount EF_M = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "EF-M", 
                ManufacturerId = Canon.ManufacturerId, 
                FlangeDistence = 18};
            LensMount RF = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "RF", 
                ManufacturerId = Canon.ManufacturerId, 
                FlangeDistence = 20};
            LensMount FD = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "FD", 
                ManufacturerId = Canon.ManufacturerId, 
                FlangeDistence = 42};
            LensMount F = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "F", 
                ManufacturerId = Nikon.ManufacturerId, 
                FlangeDistence = 46};
            LensMount Z = new LensMount() { LensMountId = LensMountIDCounter++,
                Name = "Z",
                ManufacturerId = Nikon.ManufacturerId, 
                FlangeDistence = 16};
            LensMount M42 = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "M42", 
                ManufacturerId = FED.ManufacturerId, 
                FlangeDistence = 45.46};
            LensMount M39 = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "M39",
                ManufacturerId = FED.ManufacturerId, 
                FlangeDistence = 28.80};
            LensMount M = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "M", 
                ManufacturerId = Leica.ManufacturerId, 
                FlangeDistence = 27.8};
            LensMount L = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "L",
                ManufacturerId = Leica.ManufacturerId, 
                FlangeDistence = 20};
            LensMount R = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "R",
                ManufacturerId = Zeiss.ManufacturerId,
                FlangeDistence = 46};
            LensMount SA = new LensMount(){ LensMountId = LensMountIDCounter++,
                Name = "SA", 
                ManufacturerId = Sigma.ManufacturerId, 
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
            Canon.Lenses.Add(_50mm_f1_8);
            Lens _50mm_f1_4_ssc = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){FD},
                ManufacturerId = Canon.ManufacturerId}; 
            Canon.Lenses.Add(_50mm_f1_4_ssc);
            Lens _50mm_f1_4_usm = new Lens() { LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){EF},
                ManufacturerId = Canon.ManufacturerId};
            Canon.Lenses.Add(_50mm_f1_4_usm);
            Lens _50mm_f1_4 = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){F},
                ManufacturerId = Nikon.ManufacturerId};
            Canon.Lenses.Add(_50mm_f1_4);
            Lens _50mm_f1_4_afs = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId};
            Canon.Lenses.Add(_50mm_f1_4_afs);
            Lens _50mm_f1_4_afs_g = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId};
            Nikon.Lenses.Add(_50mm_f1_4_afs_g);
            Lens noctilux_50mm_f0_95 = new Lens() {  LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 0.95,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            Leica.Lenses.Add(noctilux_50mm_f0_95);            
            Lens summilux_50mm_f1_4_ASPH = new Lens() { LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            Leica.Lenses.Add(summilux_50mm_f1_4_ASPH);
            Lens Summicron = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 2,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            Leica.Lenses.Add(Summicron);      
            Lens _50mm_f1_4_DG_HSM = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 77,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.ManufacturerId};
            Sigma.Lenses.Add(_50mm_f1_4_DG_HSM);
            Lens SP_45mm_f_1_8_Di_VC_USD = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 45,
                Aperture = 1.8,
                FilterSize = 67,
                Mounts = TamronMounts,
                ManufacturerId = Tamron.ManufacturerId};
            Tamron.Lenses.Add(SP_45mm_f_1_8_Di_VC_USD);    
            Lens Opera_50mm_f_1_4 = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 50,
                Aperture = 1.4,
                FilterSize = 72,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.ManufacturerId};
            Tokina.Lenses.Add(Opera_50mm_f_1_4);           
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
            Canon.Lenses.Add(_35mm_f2_is_usm);    
            Lens _35mm_f1_4_l_usm = new Lens(){  LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = CanonMounts,
                ManufacturerId = Canon.ManufacturerId};
            Canon.Lenses.Add(_35mm_f1_4_l_usm);        
            Lens _35mm_f2_afs = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId};
            Nikon.Lenses.Add(_35mm_f2_afs);
            Lens _35mm_f1_4_afs_g = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = NikonMounts,
                ManufacturerId = Nikon.ManufacturerId};
            Nikon.Lenses.Add(_35mm_f1_4_afs_g);
            Lens _35mm_f1_2_DG_DN = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.2,
                FilterSize = 77,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.ManufacturerId};
            Sigma.Lenses.Add(_35mm_f1_2_DG_DN);
            Lens _35mm_f1_4_DG_HSM = new Lens(){  LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 77,
                Mounts = SigmaMounts,
                ManufacturerId = Sigma.ManufacturerId};
            Sigma.Lenses.Add(_35mm_f1_4_DG_HSM);
            Lens atx_m_35_1_4_plus_e = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 52,
                Mounts = TokinaMounts,
                ManufacturerId = Tokina.ManufacturerId};
            Tokina.Lenses.Add(atx_m_35_1_4_plus_e);
            Lens _35mm_f1_4_Di_VC_USD = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 67,
                Mounts = TamronMounts,
                ManufacturerId = Tamron.ManufacturerId};
            
            Tamron.Lenses.Add(_35mm_f1_4_Di_VC_USD);
            Lens Summicron_M_f_2_ASPH = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 2,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            Leica.Lenses.Add(Summicron_M_f_2_ASPH); 
    
            Lens Summilux_M_f_1_4_ASPH = new Lens(){ LensId = LensIDCounter++,
                FocalLength = 35,
                Aperture = 1.4,
                FilterSize = 55,
                Mounts = new List<LensMount>(){L},
                ManufacturerId = Leica.ManufacturerId};
            
            Leica.Lenses.Add(Summilux_M_f_1_4_ASPH);
            #endregion
            #endregion
            
            List<LensMount> items = new List<LensMount>() {                    FD, 
                EF,
                F,
                L, 
                M, 
                R, 
                EF_S,
                EF_M, 
                RF,
                M39,
                M42, 
                SA};

            
            return items.AsQueryable();
        }
        

    }
}
