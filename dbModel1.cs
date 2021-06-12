using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QBisnis
{
    public partial class dbModel1 : DbContext
    {
        public dbModel1()
            : base("name=dbModel11")
        {
        }

        public virtual DbSet<FixedCost> FixedCosts { get; set; }
        public virtual DbSet<VariableCost> VariableCosts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FixedCost>()
                .Property(e => e.Nominal)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VariableCost>()
                .Property(e => e.Nominal)
                .HasPrecision(18, 0);
        }
    }
}
