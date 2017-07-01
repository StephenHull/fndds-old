namespace FnddsLoader.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MoistNFatAdjust")]
    public partial class MoistNFatAdjust
    {
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

        public decimal? MoistureChange { get; set; }

        public decimal? FatChange { get; set; }

        public int? TypeOfFat { get; set; }

        public DateTime Created { get; set; }

        public virtual MainFoodDesc MainFoodDesc { get; set; }
    }
}