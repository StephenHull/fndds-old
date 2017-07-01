namespace FnddsLoader.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NutDesc")]
    public partial class NutDesc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NutDesc()
        {
            FnddsNutVal = new HashSet<FnddsNutVal>();
            ModNutVal = new HashSet<ModNutVal>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NutrientCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        [Required]
        [StringLength(45)]
        public string NutrientDescription { get; set; }

        [StringLength(15)]
        public string Tagname { get; set; }

        [Required]
        [StringLength(10)]
        public string Unit { get; set; }

        public int Decimals { get; set; }

        public DateTime Created { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FnddsNutVal> FnddsNutVal { get; set; }

        public virtual FnddsVersion FnddsVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModNutVal> ModNutVal { get; set; }
    }
}