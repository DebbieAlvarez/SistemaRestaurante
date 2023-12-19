using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoProgramacion.Models
{
    public partial class RestauranteSistemaContext : DbContext
    {
        public RestauranteSistemaContext()
        {
        }

        public RestauranteSistemaContext(DbContextOptions<RestauranteSistemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Calificacion> Calificacions { get; set; } = null!;
        public virtual DbSet<Menu> Menus { get; set; } = null!;
        public virtual DbSet<Reservacion> Reservacions { get; set; } = null!;
        public virtual DbSet<Restaurante> Restaurantes { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

   
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.HasKey(e => e.IdCalificacion)
                    .HasName("PK__Califica__40E4A7514DEE8B4B");

                entity.ToTable("Calificacion");

                entity.Property(e => e.IdCalificacion).ValueGeneratedNever();

                entity.Property(e => e.Comentario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRestauranteNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.IdRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Restaurante1");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Calificacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasKey(e => e.IdMenu)
                    .HasName("PK__Menu__4D7EA8E1A4D93F8F");

                entity.ToTable("Menu");

                entity.Property(e => e.IdMenu).ValueGeneratedNever();

                entity.Property(e => e.Plato)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("smallmoney");

                entity.HasOne(d => d.IdRestauranteNavigation)
                    .WithMany(p => p.Menus)
                    .HasForeignKey(d => d.IdRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Restaurante");
            });

            modelBuilder.Entity<Reservacion>(entity =>
            {
                entity.HasKey(e => e.IdReservacion)
                    .HasName("PK__Reservac__52824637EDF35E8E");

                entity.ToTable("Reservacion");

                entity.Property(e => e.IdReservacion).ValueGeneratedNever();

                entity.Property(e => e.FechaReservacion).HasColumnType("datetime");

                entity.HasOne(d => d.IdRestauranteNavigation)
                    .WithMany(p => p.Reservacions)
                    .HasForeignKey(d => d.IdRestaurante)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Restaurante2");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Reservacions)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Usuario1");
            });

            modelBuilder.Entity<Restaurante>(entity =>
            {
                entity.HasKey(e => e.IdRestaurante)
                    .HasName("PK__Restaura__29CE64FA152D53A4");

                entity.ToTable("Restaurante");

                entity.Property(e => e.IdRestaurante).ValueGeneratedNever();

                entity.Property(e => e.Categoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreRestaurante)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__Usuario__5B65BF9766CC0674");

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).ValueGeneratedNever();

                entity.Property(e => e.Contrasena)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
