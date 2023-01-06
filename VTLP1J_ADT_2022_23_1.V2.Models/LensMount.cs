using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VTLP1J_ADT_2022_23_1.V2.Models
{
    [Table("LensMounts")]
    public class LensMount
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LensMountId { get; set; }
        
        [Required] public String Name { get; set; }

        [Required] public double FlangeDistence { get; set; }
        
        [NotMapped] public virtual Manufacturer Manufacturer { get; set; }
            
        [ForeignKey(nameof(Manufacturer))]
        public int ManufacturerId { get; set; }
        public override string ToString()
        {
            return $"{LensMountId}: {Name},{FlangeDistence}";
        }
    }
}