namespace FnddsLoader.Model
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FnddsSrLinks")]
    public partial class FnddsSrLinks
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FoodCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SeqNum { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        [StringLength(8)]
        public string SrCode { get; set; }

        [Required]
        [StringLength(255)]
        public string SrDescription { get; set; }

        public decimal Amount { get; set; }

        [StringLength(3)]
        public string Measure { get; set; }

        [Column(Order = 2)]
        public int? PortionCode { get; set; }

        public int? RetentionCode { get; set; }

        public int? Flag { get; set; }

        public decimal Weight { get; set; }

        [StringLength(1)]
        public string ChangeTypeToSrCode { get; set; }

        [StringLength(1)]
        public string ChangeTypeToWeight { get; set; }

        [StringLength(1)]
        public string ChangeTypeToRetnCode { get; set; }

        public DateTime Created { get; set; }

        public virtual FoodPortionDesc FoodPortionDesc { get; set; }

        public virtual MainFoodDesc MainFoodDesc { get; set; }
    }
}