using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace VTLP1J_ADT_2022_23_1.V2.Models
{
    
    [Table("manufacturer")]
    public class Manufacturer
    {
        #region Fields
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Required] public String Name { get; set; }
        
        [Required] public DateOnly Established { get; set; }
        
        [Required] public String CountryOfOrigin { get; set; }
        
        [NotMapped] public virtual ICollection<ILens> Lenses { get; set; }

        

        #endregion
        
        
     

        #region methods

        public override string ToString()
        {
            return $"{ID}: {Name} Est.:{Established} in {CountryOfOrigin} ";
        }
        public Manufacturer()
        {
            this.Lenses = new HashSet<ILens>();
    
        }

        #endregion

    }
}