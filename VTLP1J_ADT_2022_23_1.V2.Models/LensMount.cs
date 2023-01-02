using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VTLP1J_ADT_2022_23_1.V2.Models
{
    [Table("LensMount")]
    public class LensMount
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required] public String Name { get; set; }

        [Required] public int FlangeDistence { get; set; }
        
        [NotMapped] public virtual Manufacturer Manufacturer { get; set; }
        
        [NotMapped] public virtual ILens Lens { get; set; }
        
        
        
    }
}