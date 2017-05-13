namespace FnddsLoader.Model
{
    using System.Data.Entity;

    public partial class FnddsContext : DbContext
    {
        public FnddsContext()
            : base("name=Fndds")
        {
        }

        public virtual DbSet<AddFoodDesc> AddFoodDesc { get; set; }
        public virtual DbSet<Equivalent> Equivalent { get; set; }
        public virtual DbSet<FnddsNutVal> FnddsNutVal { get; set; }
        public virtual DbSet<FnddsSrLinks> FnddsSrLinks { get; set; }
        public virtual DbSet<FnddsVersion> FnddsVersion { get; set; }
        public virtual DbSet<FoodPortionDesc> FoodPortionDesc { get; set; }
        public virtual DbSet<FoodWeights> FoodWeights { get; set; }
        public virtual DbSet<MainFoodDesc> MainFoodDesc { get; set; }
        public virtual DbSet<ModDesc> ModDesc { get; set; }
        public virtual DbSet<ModEquivalent> ModEquivalent { get; set; }
        public virtual DbSet<ModNutVal> ModNutVal { get; set; }
        public virtual DbSet<MoistNFatAdjust> MoistNFatAdjust { get; set; }
        public virtual DbSet<NoSaltModNutVal> NoSaltModNutVal { get; set; }
        public virtual DbSet<NutDesc> NutDesc { get; set; }
        public virtual DbSet<SubcodeDesc> SubcodeDesc { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AddFoodDesc>()
                .Property(e => e.AdditionalFoodDescription)
                .IsUnicode(false);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.F_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.F_CITMLB)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.F_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.F_JUICE)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_DRKGR)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_REDOR_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_REDOR_TOMATO)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_REDOR_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_STARCHY_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_STARCHY_POTATO)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_STARCHY_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_LEGUMES)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.G_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.G_WHOLE)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.G_REFINED)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.PF_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.PF_MPS_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.PF_MEAT)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.PF_CUREDMEAT)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.PF_ORGAN)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.PF_POULT)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.PF_SEAFD_HI)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.PF_SEAFD_LOW)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.PF_EGGS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.PF_SOY)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.PF_NUTSDS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.PF_LEGUMES)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.D_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.D_MILK)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.D_YOGURT)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.D_CHEESE)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.OILS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.SOLID_FATS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.ADD_SUGARS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.A_DRINKS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<FnddsNutVal>()
                .Property(e => e.NutrientValue)
                .HasPrecision(10, 3);

            modelBuilder.Entity<FnddsSrLinks>()
                .Property(e => e.SrCode)
                .IsUnicode(false);

            modelBuilder.Entity<FnddsSrLinks>()
                .Property(e => e.SrDescription)
                .IsUnicode(false);

            modelBuilder.Entity<FnddsSrLinks>()
                .Property(e => e.Amount)
                .HasPrecision(11, 3);

            modelBuilder.Entity<FnddsSrLinks>()
                .Property(e => e.Measure)
                .IsUnicode(false);

            modelBuilder.Entity<FnddsSrLinks>()
                .Property(e => e.Weight)
                .HasPrecision(11, 3);

            modelBuilder.Entity<FnddsSrLinks>()
                .Property(e => e.ChangeTypeToSrCode)
                .IsUnicode(false);

            modelBuilder.Entity<FnddsSrLinks>()
                .Property(e => e.ChangeTypeToWeight)
                .IsUnicode(false);

            modelBuilder.Entity<FnddsSrLinks>()
                .Property(e => e.ChangeTypeToRetnCode)
                .IsUnicode(false);

            modelBuilder.Entity<FnddsVersion>()
                .HasMany(e => e.FoodPortionDesc)
                .WithRequired(e => e.FnddsVersion)
                .HasForeignKey(e => e.Version);

            modelBuilder.Entity<FnddsVersion>()
                .HasMany(e => e.MainFoodDesc)
                .WithRequired(e => e.FnddsVersion)
                .HasForeignKey(e => e.Version);

            modelBuilder.Entity<FnddsVersion>()
                .HasMany(e => e.NutDesc)
                .WithRequired(e => e.FnddsVersion)
                .HasForeignKey(e => e.Version);

            modelBuilder.Entity<FnddsVersion>()
                .HasMany(e => e.SubcodeDesc)
                .WithRequired(e => e.FnddsVersion)
                .HasForeignKey(e => e.Version);

            modelBuilder.Entity<FoodPortionDesc>()
                .Property(e => e.PortionDescription)
                .IsUnicode(false);

            modelBuilder.Entity<FoodPortionDesc>()
                .Property(e => e.ChangeType)
                .IsUnicode(false);

            modelBuilder.Entity<FoodPortionDesc>()
                .HasMany(e => e.FnddsSrLinks)
                .WithOptional(e => e.FoodPortionDesc)
                .HasForeignKey(e => new { e.PortionCode, e.Version });

            modelBuilder.Entity<FoodPortionDesc>()
                .HasMany(e => e.FoodWeights)
                .WithRequired(e => e.FoodPortionDesc)
                .HasForeignKey(e => new { e.PortionCode, e.Version })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FoodWeights>()
                .Property(e => e.PortionWeight)
                .HasPrecision(8, 3);

            modelBuilder.Entity<FoodWeights>()
                .Property(e => e.ChangeType)
                .IsUnicode(false);

            modelBuilder.Entity<MainFoodDesc>()
                .Property(e => e.MainFoodDescription)
                .IsUnicode(false);

            modelBuilder.Entity<MainFoodDesc>()
                .Property(e => e.AbbreviatedMainFoodDescription)
                .IsUnicode(false);

            modelBuilder.Entity<MainFoodDesc>()
                .HasMany(e => e.AddFoodDesc)
                .WithRequired(e => e.MainFoodDesc)
                .HasForeignKey(e => new { e.FoodCode, e.Version });

            modelBuilder.Entity<MainFoodDesc>()
                .HasOptional(e => e.Equivalent)
                .WithRequired(e => e.MainFoodDesc)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MainFoodDesc>()
                .HasMany(e => e.FnddsNutVal)
                .WithRequired(e => e.MainFoodDesc)
                .HasForeignKey(e => new { e.FoodCode, e.Version });

            modelBuilder.Entity<MainFoodDesc>()
                .HasMany(e => e.FnddsSrLinks)
                .WithRequired(e => e.MainFoodDesc)
                .HasForeignKey(e => new { e.FoodCode, e.Version });

            modelBuilder.Entity<MainFoodDesc>()
                .HasMany(e => e.FoodWeights)
                .WithRequired(e => e.MainFoodDesc)
                .HasForeignKey(e => new { e.FoodCode, e.Version });

            modelBuilder.Entity<MainFoodDesc>()
                .HasMany(e => e.ModDesc)
                .WithRequired(e => e.MainFoodDesc)
                .HasForeignKey(e => new { e.FoodCode, e.Version });

            modelBuilder.Entity<MainFoodDesc>()
                .HasOptional(e => e.MoistNFatAdjust)
                .WithRequired(e => e.MainFoodDesc)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ModDesc>()
                .Property(e => e.ModificationDescription)
                .IsUnicode(false);

            modelBuilder.Entity<ModDesc>()
                .HasOptional(e => e.ModEquivalent)
                .WithRequired(e => e.ModDesc)
                .WillCascadeOnDelete();

            modelBuilder.Entity<ModDesc>()
                .HasMany(e => e.ModNutVal)
                .WithRequired(e => e.ModDesc)
                .HasForeignKey(e => new { e.FoodCode, e.ModificationCode, e.Version });

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.F_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.F_CITMLB)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.F_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.F_JUICE)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_DRKGR)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_REDOR_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_REDOR_TOMATO)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_REDOR_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_STARCHY_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_STARCHY_POTATO)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_STARCHY_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_LEGUMES)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.G_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.G_WHOLE)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.G_REFINED)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.PF_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.PF_MPS_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.PF_MEAT)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.PF_CUREDMEAT)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.PF_ORGAN)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.PF_POULT)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.PF_SEAFD_HI)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.PF_SEAFD_LOW)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.PF_EGGS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.PF_SOY)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.PF_NUTSDS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.PF_LEGUMES)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.D_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.D_MILK)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.D_YOGURT)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.D_CHEESE)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.OILS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.SOLID_FATS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.ADD_SUGARS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.A_DRINKS)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModNutVal>()
                .Property(e => e.NutrientValue)
                .HasPrecision(10, 3);

            modelBuilder.Entity<ModNutVal>()
                .HasOptional(e => e.NoSaltModNutVal)
                .WithRequired(e => e.ModNutVal)
                .WillCascadeOnDelete();

            modelBuilder.Entity<MoistNFatAdjust>()
                .Property(e => e.MoistureChange)
                .HasPrecision(5, 1);

            modelBuilder.Entity<MoistNFatAdjust>()
                .Property(e => e.FatChange)
                .HasPrecision(5, 1);

            modelBuilder.Entity<NoSaltModNutVal>()
                .Property(e => e.NutrientValue)
                .HasPrecision(10, 3);

            modelBuilder.Entity<NutDesc>()
                .Property(e => e.NutrientDescription)
                .IsUnicode(false);

            modelBuilder.Entity<NutDesc>()
                .Property(e => e.Tagname)
                .IsUnicode(false);

            modelBuilder.Entity<NutDesc>()
                .Property(e => e.Unit)
                .IsUnicode(false);

            modelBuilder.Entity<NutDesc>()
                .HasMany(e => e.FnddsNutVal)
                .WithRequired(e => e.NutDesc)
                .HasForeignKey(e => new { e.NutrientCode, e.Version })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NutDesc>()
                .HasMany(e => e.ModNutVal)
                .WithRequired(e => e.NutDesc)
                .HasForeignKey(e => new { e.NutrientCode, e.Version })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubcodeDesc>()
                .Property(e => e.SubcodeDescription)
                .IsUnicode(false);

            modelBuilder.Entity<SubcodeDesc>()
                .HasMany(e => e.FoodWeights)
                .WithRequired(e => e.SubcodeDesc)
                .HasForeignKey(e => new { e.Subcode, e.Version })
                .WillCascadeOnDelete(false);
        }
    }
}