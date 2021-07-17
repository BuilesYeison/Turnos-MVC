using Microsoft.AspNetCore.Mvc;

namespace Turnos.Controllers
{
    ///<remark> Controlador que se conecta con la vista y el modelo y adminsitra datos y se encarga de logica
    public class EspecialidadController : Controller
    {
        ///<summary>
        ///Constructor de la clase
        ///</summary>
        public EspecialidadController(){

        }

        ///<summary>
        ///mostrar el resultado que obtiene este metodo en la interfaz del usuario Index
        ///</summary>
        public IActionResult Index(){
            return View();
        }
    }
}