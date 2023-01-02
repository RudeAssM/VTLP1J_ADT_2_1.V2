using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using VTLP1J_ADT_2022_23_1.V2.Data;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Repository
{
    public class LensRepository : Repository<ILens>, ILensRepository{
        public LensRepository(LensDatabaseContext ctx) : base(ctx)
        {
        }

        public override ILens GetOne(int id)
        {
            return this.GetAll().SingleOrDefault(lens => lens.Id == id);
        }

        public void UpdateLensMounts(int id, HashSet<LensMount> lensMounts)
        {
            var LensMounts = this.GetOne(id).Mounts;
            if (lensMounts != null)
            {
                
                foreach (var LenM in LensMounts)
                {
                       
                }
            }

        }
    }
}