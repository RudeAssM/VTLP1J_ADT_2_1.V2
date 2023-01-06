using System.Collections;
using System.Collections.Generic;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Repository
{
    public interface ILensRepository : IRepository<Lens>
    {
        void UpdateLensMounts(int id, ICollection<LensMount> lensMounts);
    }
}