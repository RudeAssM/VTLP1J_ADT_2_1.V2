using System;
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
            var LenMount = this.GetOne(id).Mounts;
            if(LenMount != null)
            {
               throw new Exception("this lens does not exist");
            }
            foreach (var mount in LenMount)
            {
                if (!lensMounts.Contains(mount))
                {
                    LenMount.Remove(mount);
                }
            }
            foreach (var mount in lensMounts)
            {
                if (!LenMount.Contains(mount))
                {
                    LenMount.Add(mount);
                }
            }
            
        }
    }
}