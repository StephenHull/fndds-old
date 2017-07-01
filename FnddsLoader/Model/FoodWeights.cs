namespace FnddsLoader.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FoodWeights")]
    public partial class FoodWeights
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FoodCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Subcode { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SeqNum { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PortionCode { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal PortionWeight { get; set; }

        [StringLength(1)]
        public string ChangeType { get; set; }

        public DateTime Created { get; set; }

        public virtual FoodPortionDesc FoodPortionDesc { get; set; }

        public virtual MainFoodDesc MainFoodDesc { get; set; }

        public virtual SubcodeDesc SubcodeDesc { get; set; }
    }
}