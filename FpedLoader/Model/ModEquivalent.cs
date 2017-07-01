namespace FpedLoader.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ModEquivalent")]
    public partial class ModEquivalent
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FoodCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ModCode { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Version { get; set; }

        public decimal? F_CITMLB { get; set; }

        public decimal? F_OTHER { get; set; }

        public decimal? F_JUICE { get; set; }

        public decimal? F_TOTAL { get; set; }

        public decimal? V_DRKGR { get; set; }

        public decimal? V_REDOR_TOMATO { get; set; }

        public decimal? V_REDOR_OTHER { get; set; }

        public decimal? V_REDOR_TOTAL { get; set; }

        public decimal? V_STARCHY_POTATO { get; set; }

        public decimal? V_STARCHY_OTHER { get; set; }

        public decimal? V_STARCHY_TOTAL { get; set; }

        public decimal? V_OTHER { get; set; }

        public decimal? V_TOTAL { get; set; }

        public decimal? V_LEGUMES { get; set; }

        public decimal? G_WHOLE { get; set; }

        public decimal? G_REFINED { get; set; }

        public decimal? G_TOTAL { get; set; }

        public decimal? PF_MEAT { get; set; }

        public decimal? PF_CUREDMEAT { get; set; }

        public decimal? PF_ORGAN { get; set; }

        public decimal? PF_POULT { get; set; }

        public decimal? PF_SEAFD_HI { get; set; }

        public decimal? PF_SEAFD_LOW { get; set; }

        public decimal? PF_MPS_TOTAL { get; set; }

        public decimal? PF_EGGS { get; set; }

        public decimal? PF_SOY { get; set; }

        public decimal? PF_NUTSDS { get; set; }

        public decimal? PF_LEGUMES { get; set; }

        public decimal? PF_TOTAL { get; set; }

        public decimal? D_MILK { get; set; }

        public decimal? D_YOGURT { get; set; }

        public decimal? D_CHEESE { get; set; }

        public decimal? D_TOTAL { get; set; }

        public decimal? OILS { get; set; }

        public decimal? SOLID_FATS { get; set; }

        public decimal? ADD_SUGARS { get; set; }

        public decimal? A_DRINKS { get; set; }

        public DateTime Created { get; set; }
    }
}
