using System;
using System.Linq;
using VTLP1J_ADT_2022_23_1.V2.Data;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Repository
{
    public class ManufacturerRepository : Repository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(LensDatabaseContext ctx) : base(ctx)
        {
        }

        public override Manufacturer GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(manufacturer => manufacturer.ManufacturerId == id);
        }

        public void UpdateName(int id, string name)
        {
            var manufacturer = this.GetOne(id);
            if (manufacturer == null)
            {
                throw new Exception("No Manufacturer with that name.");
               
            }
            this.GetOne(id).Name = name;
            this.Context.SaveChanges();
        }
    }
}