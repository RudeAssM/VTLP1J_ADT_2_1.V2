using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace VTLP1J_ADT_2022_23_1.V2.Models
{
    
    [Table("Manufacturers")]
    public class Manufacturer
    {
        #region Fields
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ManufacturerId { get; set; }
        
        [Required] 
        public String Name { get; set; }
        
        [NotMapped] 
        public DateOnly Established { get; set; }
        
        [Required]
        public String CountryOfOrigin { get; set; }
        
        [NotMapped] 
        [JsonIgnore]
        public virtual ICollection<Lens> Lenses { get; set; }
        
        
        [NotMapped] 
        public virtual ICollection<LensMount> LensMounts { get; set; }


        #endregion

        #region methods

        public override string ToString()
        {
            return $"{ManufacturerId}: {Name} Est.:{Established} in {CountryOfOrigin} ";
        }
        public Manufacturer()
        {
            this.Lenses = new HashSet<Lens>();
    
        }

        #endregion

    }
}