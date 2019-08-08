namespace SkatersTricks
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SkaterTrickMC : DbContext
    {
        public SkaterTrickMC()
            : base("name=SkaterTrickMC")
        {
        }

        public virtual DbSet<Trick> Tricks { get; set; }
        public virtual DbSet<Tuser> Tusers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
