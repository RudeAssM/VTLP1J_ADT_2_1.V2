using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VTLP1J_ADT_2022_23_1.V2.Models
{
    [Table("FixFocLens")]
    public class FixedFocalLengthLens : ILens
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int FocalLength { get; set; }
        [Required]
        public int FStopLowest { get; set; }
        [Required]
        public int FilterSize { get; set; }
        [NotMapped]
        public virtual ICollection<LensMount> Mounts { get; set; }
        [NotMapped]
        public virtual Manufacturer Manufacturer { get; set; }
        
        [ForeignKey(nameof(Manufacturer))]
        public int? ManufacturerId { get; set; }

        public FixedFocalLengthLens()
        {
            this.Mounts = new HashSet<LensMount>();
        }

        public override string ToString()
        {
            return $"{Id}: {FocalLength}mm, f/{FStopLowest}, filter size,{FilterSize}mm";
        }
        
        

    }
}