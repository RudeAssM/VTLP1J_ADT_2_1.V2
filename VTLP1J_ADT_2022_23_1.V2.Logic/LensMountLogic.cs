using System.Collections.Generic;
using VTLP1J_ADT_2022_23_1.V2.Models;
using VTLP1J_ADT_2022_23_1.V2.Repository;

namespace VTLP1J_ADT_2022_23_1.V2.Logic
{
    public class LensMountLogic : ILensMountLogic
    {
        private ILensMountRepository _lensMountRepository;
        
        public LensMountLogic(ILensMountRepository lensMountRepository)
        {
            _lensMountRepository = lensMountRepository;
        }

        public void AddLensMount(LensMount lensMount)
        {
            if (lensMount == null)
            {
                
                throw new System.ArgumentNullException(nameof(lensMount));
            }
            this._lensMountRepository.Add(lensMount);
        }

        public LensMount GetLensMount(int id)
        {
            LensMount lensMount = this._lensMountRepository.GetOne(id);
            if (lensMount == null)
            {
                throw new System.ArgumentNullException(nameof(lensMount));
            }

            return lensMount;

        }

        public void deleteLensMount(int id)
        {
            LensMount lensMount = this._lensMountRepository.GetOne(id);
            if (lensMount == null)
            {
                throw new System.ArgumentNullException(nameof(lensMount));
            }
            this._lensMountRepository.Delete(lensMount);
        }

        public IEnumerable<LensMount> GetAllLensMounts()
        {
            
            return this._lensMountRepository.GetAll();
            
        }

        public void UpdateLensMountManufacturer(int id, Manufacturer manufacturer)
        {
            this._lensMountRepository.UpdateManufacturer(id, manufacturer);
        }
    }
}