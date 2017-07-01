namespace FpedLoader.Model
{
    using System.Data.Entity;

    public partial class FpedContext : DbContext
    {
        public FpedContext()
            : base("name=fped")
        {
        }

        public virtual DbSet<Equivalent> Equivalent { get; set; }
        public virtual DbSet<FnddsVersion> FnddsVersion { get; set; }
        public virtual DbSet<ModEquivalent> ModEquivalent { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
                .Property(e => e.F_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_DRKGR)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_REDOR_TOMATO)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_REDOR_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_REDOR_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_STARCHY_POTATO)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_STARCHY_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_STARCHY_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.V_LEGUMES)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.G_WHOLE)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.G_REFINED)
                .HasPrecision(6, 3);

            modelBuilder.Entity<Equivalent>()
                .Property(e => e.G_TOTAL)
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
                .Property(e => e.PF_MPS_TOTAL)
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
                .Property(e => e.PF_TOTAL)
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
                .Property(e => e.D_TOTAL)
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
                .Property(e => e.F_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_DRKGR)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_REDOR_TOMATO)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_REDOR_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_REDOR_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_STARCHY_POTATO)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_STARCHY_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_STARCHY_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_OTHER)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_TOTAL)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.V_LEGUMES)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.G_WHOLE)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.G_REFINED)
                .HasPrecision(6, 3);

            modelBuilder.Entity<ModEquivalent>()
                .Property(e => e.G_TOTAL)
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
                .Property(e => e.PF_MPS_TOTAL)
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
                .Property(e => e.PF_TOTAL)
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
                .Property(e => e.D_TOTAL)
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
        }
    }
}
