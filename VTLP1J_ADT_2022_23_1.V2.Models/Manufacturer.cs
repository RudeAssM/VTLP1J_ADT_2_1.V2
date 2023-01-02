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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        
        [Required]
        public String Name { get; set; }
        
        [Required]
        public DateOnly Established { get; set; }
        
        [Required]
        public String countryOfOrigin { get; set; }
        
        [NotMapped]
        public virtual ICollection<ILens> Lenses { get; set; }
        
        
        public Manufacturer()
        {
            this.Lenses = new HashSet<ILens>();
    
        }

        public override string ToString()
        {
            return $"{ID}: {Name} Est.:{Established} in {countryOfOrigin} ";
        }
    }
}