using System.ComponentModel.DataAnnotations;

///<remarks>Modelo que representa una tabla/estructura de la base de datos con la que trabajaremos
namespace Turnos.Models{
    public class Especialidad{
        [Key]
        public int IdEspecialidad {get; set;}
        public string descripción{get;set;}
    }
}