namespace FpedLoader.Model
{
    using Base.Model;
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("FnddsVersion")]
    public partial class FnddsVersion : IFnddsVersion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int BeginYear { get; set; }

        public int EndYear { get; set; }

        public int? Major { get; set; }

        public int? Minor { get; set; }

        public DateTime Created { get; set; }
    }
}