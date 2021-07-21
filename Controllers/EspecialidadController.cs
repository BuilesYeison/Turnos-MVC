using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Turnos.Models;

namespace Turnos.Controllers
{
    ///<remark> Controlador que se conecta con la vista y el modelo y adminsitra datos y se encarga de logica
    public class EspecialidadController : Controller
    {
        private readonly TurnosContext _context;//solo lectura conexto del controlador
        ///<summary>
        ///Constructor de la clase que recibe el contexto de la db para conectarse a la tabla Especialidad 
        ///<param name="_context">Es el contexto que recibe este controlador</param>
        ///</summary>
        public EspecialidadController(TurnosContext context){
            _context = context; //cuando instaciamos esté controlador enviamos un context y lo inicializamos en _context
        }

        ///<summary>
        ///mostrar el resultado que obtiene este metodo en la interfaz del usuario Index
        ///</summary>
        public IActionResult Index(){
            return View(_context.Especialidad.ToList()); //le pasamos a la vista una lista de los datos de la tabla Especialidad
        }

        public IActionResult Edit(int? id){//int? permite valores nulos
            if(id == null){
                return NotFound();
            }
            var especialidad = _context.Especialidad.Find(id); //objeto que permite obtener este dato de la base de datos según el id del registro que se paso 
            if(especialidad == null){//no se encontró en la db el registro
                return NotFound();
            }
            return View(especialidad);
        }
        ///<summary>
        ///Se recibe la descripción y el id del registro en la base de datos
        ///</summary>
        [HttpPost]//Esto diferencia el metodo Edit que graba, del Edit de vista
        public IActionResult Edit(int id, [Bind("IdEspecialidad, descripción")] Especialidad especialidad){
            if(id != especialidad.IdEspecialidad){
                return NotFound();
            }
            if(ModelState.IsValid){
                _context.Update(especialidad);//actualizamos datos nuevos
                _context.SaveChanges();
                return RedirectToAction(nameof(Index)); //retornamos a la vista principal
            }
            return View(); 
        }
    }
}