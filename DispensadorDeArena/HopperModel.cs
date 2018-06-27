namespace DispensadorDeArena
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HopperModel : DbContext
    {
        public HopperModel()
            : base("name=HopperModel")
        {
        }

        public virtual DbSet<Registro> Registroes { get; set; }
        public virtual DbSet<SetKilo> SetKiloes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
