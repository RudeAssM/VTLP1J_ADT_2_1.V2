using System;
using System.Linq;
using VTLP1J_ADT_2022_23_1.V2.Data;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Repository
{
    public class LensMountRepository : Repository<LensMount>, ILensMountRepository
    {
        public LensMountRepository(LensDatabaseContext ctx) : base(ctx){}

        public override LensMount GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(mount => mount.LensMountId == id);
        }

        public void UpdateManufacturer(int id, Manufacturer manufacturer)
        {
            Manufacturer manufact = (this.GetOne(id)).Manufacturer;
            if (manufact == null)
            {
                throw new ArgumentNullException(nameof(manufacturer));
            }
            this.GetOne(id).Manufacturer = manufacturer;
            this.Context.SaveChanges();

        }
    }
}