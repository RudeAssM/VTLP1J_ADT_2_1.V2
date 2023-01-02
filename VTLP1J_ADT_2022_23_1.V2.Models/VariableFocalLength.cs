using System;

namespace VTLP1J_ADT_2022_23_1.V2.Models
{
    public class VariableFocalLength : ILens
    {
        public int minFocalLength { get; set; }
        public int maxFocalLength { get; set; }
        public int fStopLowest { get; set; }
        public int filterSize { get; set; }
        public String lensMount { get; set; }
        
        
        
        public override string ToString()
        {
            return base.ToString();
        }
    }
}