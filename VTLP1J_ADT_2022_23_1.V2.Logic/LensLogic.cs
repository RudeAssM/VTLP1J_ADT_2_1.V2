using System.Collections;
using System.Collections.Generic;
using System.Linq;
using VTLP1J_ADT_2022_23_1.V2.Models;
using VTLP1J_ADT_2022_23_1.V2.Repository;

namespace VTLP1J_ADT_2022_23_1.V2.Logic
{
    public class LensLogic : ILensLogic
    {
        
        private ILensRepository _lensRepository;
        
        public LensLogic(ILensRepository lensRepository)
        {
            _lensRepository = lensRepository;
        }
        public void AddNewLens(Lens lens)
        {
            if (lens == null)
            {
                throw new System.ArgumentNullException(nameof(lens));
            }
            _lensRepository.Add(lens);
        }

        public Lens GetLens(int id)
        {
            Lens lens = _lensRepository.GetOne(id);
            if (lens == null)
            {
                throw new System.ArgumentNullException(nameof(lens));
            }
            return lens;
        }

        public void deleteLens(int id)
        {
            Lens lens = _lensRepository.GetOne(id);
            if (lens == null)
            {
                throw new System.ArgumentNullException(nameof(lens));
            } 
            _lensRepository.Delete(lens);
        }

        public IEnumerable<Lens> GetAllLenses()
        {
           return _lensRepository.GetAll();
        }

        public void UpdateLensMount(int id, ICollection<LensMount> lensMounts)
        {
            
            this._lensRepository.UpdateLensMounts(id, lensMounts);
        }
    }
}