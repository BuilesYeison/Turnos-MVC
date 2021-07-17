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
        ///Constructor de la clase
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
    }
}