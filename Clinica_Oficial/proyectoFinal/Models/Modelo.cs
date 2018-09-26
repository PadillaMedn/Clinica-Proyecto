namespace proyectoFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Modelo : DbContext
    {
        public Modelo()
            : base("name=Modelo")
        {
        }

        public virtual DbSet<cita> cita { get; set; }
        public virtual DbSet<consulta> consulta { get; set; }
        public virtual DbSet<estado> estado { get; set; }
        public virtual DbSet<mascota> mascota { get; set; }
        public virtual DbSet<propietario_Mascota> propietario_Mascota { get; set; }
        public virtual DbSet<receta> receta { get; set; }
        public virtual DbSet<rol> rol { get; set; }
        public virtual DbSet<tipo_mascota> tipo_mascota { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<veterinario> veterinario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cita>()
                .Property(e => e.fecha)
                .IsUnicode(false);

            modelBuilder.Entity<cita>()
                .Property(e => e.hora)
                .IsUnicode(false);

            modelBuilder.Entity<cita>()
                .HasMany(e => e.consulta)
                .WithRequired(e => e.cita)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<consulta>()
                .Property(e => e.diagnostico)
                .IsUnicode(false);

            modelBuilder.Entity<consulta>()
                .Property(e => e.observaciones)
                .IsUnicode(false);

            modelBuilder.Entity<consulta>()
                .HasMany(e => e.receta)
                .WithRequired(e => e.consulta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<estado>()
                .Property(e => e.estado1)
                .IsUnicode(false);

            modelBuilder.Entity<estado>()
                .HasMany(e => e.cita)
                .WithRequired(e => e.estado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<mascota>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<mascota>()
                .Property(e => e.peso)
                .IsUnicode(false);

            modelBuilder.Entity<mascota>()
                .Property(e => e.sexo)
                .IsUnicode(false);

            modelBuilder.Entity<mascota>()
                .HasMany(e => e.cita)
                .WithRequired(e => e.mascota)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<propietario_Mascota>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<propietario_Mascota>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<propietario_Mascota>()
                .Property(e => e.dui)
                .IsUnicode(false);

            modelBuilder.Entity<propietario_Mascota>()
                .Property(e => e.sexo)
                .IsUnicode(false);

            modelBuilder.Entity<propietario_Mascota>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<propietario_Mascota>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<propietario_Mascota>()
                .HasMany(e => e.mascota)
                .WithRequired(e => e.propietario_Mascota)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<receta>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<receta>()
                .Property(e => e.dosis)
                .IsUnicode(false);

            modelBuilder.Entity<rol>()
                .Property(e => e.rol1)
                .IsUnicode(false);

            modelBuilder.Entity<rol>()
                .HasMany(e => e.usuario)
                .WithRequired(e => e.rol)
                .HasForeignKey(e => e.id_rol)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tipo_mascota>()
                .Property(e => e.especie)
                .IsUnicode(false);

            modelBuilder.Entity<tipo_mascota>()
                .HasMany(e => e.mascota)
                .WithRequired(e => e.tipo_mascota)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.usuario1)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .Property(e => e.pass)
                .IsUnicode(false);

            modelBuilder.Entity<usuario>()
                .HasMany(e => e.cita)
                .WithRequired(e => e.usuario)
                .HasForeignKey(e => e.codusuario)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<veterinario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<veterinario>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<veterinario>()
                .Property(e => e.dui)
                .IsUnicode(false);

            modelBuilder.Entity<veterinario>()
                .Property(e => e.telefono)
                .IsUnicode(false);

            modelBuilder.Entity<veterinario>()
                .Property(e => e.sexo)
                .IsUnicode(false);

            modelBuilder.Entity<veterinario>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<veterinario>()
                .HasMany(e => e.cita)
                .WithRequired(e => e.veterinario)
                .WillCascadeOnDelete(false);
        }
    }
}
