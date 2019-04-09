using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Senai.Wishlist.API.Domains
{
    public partial class WishlistContext : DbContext
    {
        public WishlistContext()
        {
        }

        public WishlistContext(DbContextOptions<WishlistContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Desejos> Desejos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
<<<<<<< HEAD
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress;Initial Catalog=senaiWishlistDesafio;Persist Security Info=True;User ID=sa;Password=132");
=======
                optionsBuilder.UseSqlServer("Data Source=.\\SqlExpress; Initial Catalog= SENAI_WISHLIST_DESAFIO; User Id=sa; Password=132");
>>>>>>> ac95517e9ca01ecbc497847700427255fb6f28ae
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Desejos>(entity =>
            {
                entity.ToTable("DESEJOS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DataCriacao)
                    .HasColumnName("DATA_CRIACAO")
                    .HasColumnType("date");

                entity.Property(e => e.Desejo)
                    .IsRequired()
                    .HasColumnName("DESEJO")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.IdUsuario).HasColumnName("ID_USUARIO");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Desejos)
                    .HasForeignKey(d => d.IdUsuario)
                    .HasConstraintName("FK__DESEJOS__ID_USUA__4CA06362");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.ToTable("USUARIOS");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__USUARIOS__161CF72470846AC2")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMAIL")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("SENHA")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });
        }
    }
}
