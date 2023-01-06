
using System.Collections.Generic;
using VTLP1J_ADT_2022_23_1.V2.Models;

namespace VTLP1J_ADT_2022_23_1.V2.Logic
{
    public interface ILensLogic
    {
        public void AddNewLens(Lens lens);
        public Lens GetLens(int id);
        public void deleteLens(int id);
        public IEnumerable<Lens> GetAllLenses();

        public void UpdateLensMount(int id, ICollection<LensMount> lensMounts);

    }
}