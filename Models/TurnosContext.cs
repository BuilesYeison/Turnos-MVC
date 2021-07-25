using Microsoft.EntityFrameworkCore;

namespace Turnos.Models
{
    ///<remark>Esta clase nos permite comunicarnos con EntityFramework y crear la base de datos conforme al código
    public class TurnosContext : DbContext
    {
        ///<summary>
        ///
        ///<param name="opciones">Opciones base que hereda nuestra clase TUrnosContext</param>
        ///</summary>
        public TurnosContext(DbContextOptions<TurnosContext> opciones):base(opciones){

        }

        ///<summary>
        ///Para crear una tabla en la db
        ///<param name="Especialidad">DbSet es una tabla, una entidad</param>
        ///</summary>
        public DbSet<Especialidad> Especialidad{get;set;}

        ///<summary>
        ///Creamos el dbset que apunta a la tabla en sql
        ///<param name="Paciente">DbSet es un tabla o entidad</param>
        ///</summary>
        public DbSet<Paciente> Paciente{get;set;}

        ///<summary>
        ///Funcion que permite especificar la creación de la tabla según el modelo en el codigo. Permite especificar las propiedades de las columnas
        ///</summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<Especialidad>(entidad =>{
                entidad.ToTable("Especialidad"); //nombre de la tabla
                entidad.HasKey(e => e.IdEspecialidad);
                entidad.Property(e => e.descripción)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);
            });
            modelBuilder.Entity<Paciente>(entidad =>{
                entidad.ToTable("Paciente");
                entidad.HasKey(e => e.idPaciente);
                entidad.Property(e => e.Nombre)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entidad.Property(e => e.Apellido)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);
                entidad.Property(e => e.Direccion)
                .IsRequired()
                .HasMaxLength(250)
                .IsUnicode(false);
                entidad.Property(e => e.Telefono)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false);
                entidad.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);
            });
        }
    }
}