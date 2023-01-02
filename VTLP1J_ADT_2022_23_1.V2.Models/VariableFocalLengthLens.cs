using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace VTLP1J_ADT_2022_23_1.V2.Models
{
    [Table("VarFocLens")]
    public class VariableFocalLengthLens : ILens
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int MinFocalLength { get; set; }
        [Required]
        public int MaxFocalLength { get; set; }
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
        
        public VariableFocalLengthLens()
        {
            this.Mounts = new HashSet<LensMount>();
        }

        public override string ToString()
        {
            return $"{Id}: {MinFocalLength}-{MaxFocalLength}mm, f/{FStopLowest}, filter size,{FilterSize}mm";
        }
    }
}