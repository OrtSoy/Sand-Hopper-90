namespace DispensadorDeArena
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
            : base("name=EmployeeContext")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Last)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.First)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.HomeDept)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.BadgePin)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Salaried)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Plant)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CommentPending)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.WinLogin)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.NetworkName)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.DutyorFunction)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PlantID)
                .IsUnicode(false);
        }
    }
}
