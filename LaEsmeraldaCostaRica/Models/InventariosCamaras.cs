namespace LaEsmeraldaCostaRica.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class InventariosCamaras : DbContext
    {
        public InventariosCamaras()
            : base("name=InventariosCamaras")
        {
        }

        public virtual DbSet<Bolsa> Bolsas { get; set; }
        public virtual DbSet<Bolsa_por_caja> Bolsa_por_caja { get; set; }
        public virtual DbSet<Caja> Cajas { get; set; }
        public virtual DbSet<Producto> productoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bolsa>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Bolsa>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Bolsa>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Bolsa>()
                .HasMany(e => e.Bolsa_por_caja)
                .WithRequired(e => e.Bolsa)
                .HasForeignKey(e => e.id_bolsa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Caja>()
                .Property(e => e.codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Caja>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Caja>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Caja>()
                .HasMany(e => e.Bolsa_por_caja)
                .WithRequired(e => e.Caja)
                .HasForeignKey(e => e.id_caja)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Bolsa_por_caja)
                .WithRequired(e => e.producto)
                .HasForeignKey(e => e.id_producto)
                .WillCascadeOnDelete(false);
        }
    }
}
