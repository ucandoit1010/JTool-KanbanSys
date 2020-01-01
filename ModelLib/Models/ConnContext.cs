namespace ModelLib.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ConnContext : DbContext
    {
        public ConnContext()
            : base("name=ConnContext")
        {
        }

        public virtual DbSet<Chart> Charts { get; set; }
        public virtual DbSet<ChartProperty> ChartProperties { get; set; }
        public virtual DbSet<Conn> Conns { get; set; }
        public virtual DbSet<CurrencyJPY> CurrencyJPies { get; set; }
        public virtual DbSet<KBProject> KBProjects { get; set; }
        public virtual DbSet<ProjectMapping> ProjectMappings { get; set; }
        public virtual DbSet<CurrencyTest> CurrencyTests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chart>()
                .Property(e => e.ChartType)
                .IsUnicode(false);

            modelBuilder.Entity<Chart>()
                .HasMany(e => e.ChartProperties)
                .WithRequired(e => e.Chart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Chart>()
                .HasMany(e => e.KBProjects)
                .WithRequired(e => e.Chart)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Conn>()
                .Property(e => e.ConnStr)
                .IsUnicode(false);

            modelBuilder.Entity<Conn>()
                .HasMany(e => e.KBProjects)
                .WithRequired(e => e.Conn)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CurrencyJPY>()
                .Property(e => e.Mon)
                .IsUnicode(false);

            modelBuilder.Entity<CurrencyJPY>()
                .Property(e => e.Currency)
                .HasPrecision(10, 4);

            modelBuilder.Entity<CurrencyJPY>()
                .Property(e => e.CurrencyType)
                .IsUnicode(false);

            modelBuilder.Entity<KBProject>()
                .Property(e => e.ProjectSQL)
                .IsUnicode(false);

            modelBuilder.Entity<KBProject>()
                .Property(e => e.Url)
                .IsUnicode(false);

            modelBuilder.Entity<KBProject>()
                .HasMany(e => e.ProjectMappings)
                .WithRequired(e => e.KBProject)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectMapping>()
                .Property(e => e.PropertyName)
                .IsUnicode(false);

            modelBuilder.Entity<CurrencyTest>()
                .Property(e => e.Mon)
                .IsUnicode(false);

            modelBuilder.Entity<CurrencyTest>()
                .Property(e => e.Currency)
                .HasPrecision(10, 4);

            modelBuilder.Entity<CurrencyTest>()
                .Property(e => e.CurrencyType)
                .IsUnicode(false);
        }
    }
}
