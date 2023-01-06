using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VTLP1J_ADT_2022_23_1.V2.Models
{
    [Table("Lenses")]
    public class Lens
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LensId { get; set; }
        [Required]
        public int FocalLength { get; set; }
        [Required]
        public double Aperture { get; set; }
        [Required]
        public int FilterSize { get; set; }
        [NotMapped]
        public  ICollection<LensMount> Mounts { get; set; }
        [NotMapped]
        [JsonIgnore]
        public virtual Manufacturer Manufacturer { get; set; }
        
        [ForeignKey(nameof(Manufacturer))]
        public int ManufacturerId { get; set; }

        public Lens()
        {
            this.Mounts = new HashSet<LensMount>();
        }

        public override string ToString()
        {
            return $"{LensId}: {FocalLength}mm, f/{Aperture}, filter size,{FilterSize}mm";
        }
        
        

    }
}