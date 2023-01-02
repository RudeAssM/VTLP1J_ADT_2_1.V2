using System;
using System.Collections.Generic;
using System.Linq;

namespace VTLP1J_ADT_2022_23_1.V2.Models
{
    
    public interface ILens
    {
        public int Id { get; set; }

        public ICollection<LensMount> Mounts { get; set; }
        public String ToString();
        

    }
}