namespace FnddsLoader.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MainFoodDesc")]
    public partial class MainFoodDesc
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MainFoodDesc()
        {
            AddFoodDesc = new HashSet<AddFoodDesc>();
            FnddsNutVal = new HashSet<FnddsNutVal>();
            FnddsSrLinks = new HashSet<FnddsSrLinks>();
            FoodWeights = new HashSet<FoodWeights>();
            ModDesc = new HashSet<ModDesc>();
        }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FoodCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(200)]
        public string MainFoodDescription { get; set; }

        [StringLength(60)]
        public string AbbreviatedMainFoodDescription { get; set; }

        public int FortificationIdentifier { get; set; }

        public DateTime Created { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddFoodDesc> AddFoodDesc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FnddsNutVal> FnddsNutVal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FnddsSrLinks> FnddsSrLinks { get; set; }

        public virtual FnddsVersion FnddsVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FoodWeights> FoodWeights { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ModDesc> ModDesc { get; set; }

        public virtual MoistNFatAdjust MoistNFatAdjust { get; set; }
    }
}