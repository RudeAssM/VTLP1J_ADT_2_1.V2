using System;
using System.Collections;
using System.Collections.Generic;
using VTLP1J_ADT_2022_23_1.V2.Models;
using VTLP1J_ADT_2022_23_1.V2.Repository;

namespace VTLP1J_ADT_2022_23_1.V2.Logic
{
    public class ManufacturerLogic : IManufacturerLogic
    {
        private IManufacturerRepository _manufacturerRepository;
        
        
        public ManufacturerLogic(IManufacturerRepository manufacturerRepository)
        {
            this._manufacturerRepository = manufacturerRepository;
        }     
        
        
        public void AddNewManufacturer(Manufacturer manufacturer)
        {
            if(manufacturer == null)
            {
                throw new NullReferenceException("Manufacturer is null");
            }
            this._manufacturerRepository.Add(manufacturer);
        }

        public Manufacturer Get(int id)
        {
            Manufacturer manufacturer = this._manufacturerRepository.GetOne(id);
            if(manufacturer == null)
            {
                throw new NullReferenceException($"Manufacturer with id {id} not found");
            }
            return manufacturer;
        }

        public void deleteManufacturer(int id)
        {
            Manufacturer manufacturer = this._manufacturerRepository.GetOne(id);
            if(manufacturer == null)
            {
                throw new NullReferenceException($"Manufacturer with id {id} not found");
            }
            this._manufacturerRepository.Delete(manufacturer);
        }
        public IEnumerable<Manufacturer> GetAllManufacturers()
        {
            return this._manufacturerRepository.GetAll();
        }

        public void UpdateManufacturer(Manufacturer manufacturer)
        {
            _manufacturerRepository.UpdateName(manufacturer.ManufacturerId, manufacturer.Name);
        }

        public IEnumerable<Manufacturer> GetManufacturersByCountry(string country)
        {
            IEnumerable<Manufacturer> manufacturers = GetAllManufacturers();
            IEnumerable<Manufacturer> manufacturersByCountry = new List<Manufacturer>();
            foreach (Manufacturer manf in manufacturers)
            {
                if (manf.CountryOfOrigin == country)
                {
                    ((List<Manufacturer>)manufacturersByCountry).Add(manf);
                }
            }
            return manufacturersByCountry;
            

        }

        public ICollection<LensMount> GetAllLensMountsOfManufacturer(int id)
        {
            Manufacturer manufacturer = this._manufacturerRepository.GetOne(id);
            return manufacturer.LensMounts;
            
        }
    }
}