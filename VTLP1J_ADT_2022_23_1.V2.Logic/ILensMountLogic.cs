using System.Collections.Generic;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Logic
{
    public interface ILensMountLogic
    {
        public LensMount AddLensMount(LensMount lensMount);
        public LensMount GetLensMount(int id);
        public void deleteLensMount(int id);
        public IEnumerable<LensMount> GetAllLensMounts();
        
        
    }
}