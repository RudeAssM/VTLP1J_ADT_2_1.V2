using System.Collections;
using System.Collections.Generic;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Logic
{
    public interface IManufacturerLogic
    {
        public void AddNewManufacturer(Manufacturer manufacturer);
        public Manufacturer Get(int id);
        public void deleteManufacturer(int id);
        public IEnumerable<Manufacturer> GetAllManufacturers();
        
        public void UpdateManufacturer(Manufacturer manufacturer);
        public IEnumerable<Manufacturer> GetManufacturersByCountry(string country);
        public ICollection<LensMount> GetAllLensMountsOfManufacturer(int id);
    }
}