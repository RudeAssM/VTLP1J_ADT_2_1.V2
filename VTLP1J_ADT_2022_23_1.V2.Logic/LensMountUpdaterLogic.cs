using System.Collections.Generic;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Logic
{
    public class LensMountUpdaterLogic
    {
        public int id_target;
        public ICollection<LensMount> lensMounts;
        
        public LensMountUpdaterLogic(int id_target, ICollection<LensMount> lensMounts)
        {
            this.id_target = id_target;
            this.lensMounts = lensMounts;
        }
    }
}