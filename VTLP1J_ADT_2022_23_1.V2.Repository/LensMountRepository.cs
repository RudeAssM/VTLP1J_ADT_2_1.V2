using System;
using System.Linq;
using VTLP1J_ADT_2022_23_1.V2.Data;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Repository
{
    public class LensMountRepository : Repository<LensMount>, IlensMountRepository
    {
        public LensMountRepository(LensDatabaseContext ctx) : base(ctx)
        {
        }

        public override LensMount GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(mount => mount.Id == id);
        }

        public void UpdateManufacturer(int id, Manufacturer manufacturer)
        {
            var manufact= (this.GetOne(id)).Manufacturer;
            if (manufacturer != null)
            {
                manufact = manufacturer;
                this.Context.SaveChanges();
            }
            else { throw new Exception("No lens mount like that."); }

        }
    }
}