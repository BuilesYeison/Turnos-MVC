using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Index(){
            return View(await _context.Especialidad.ToListAsync()); //le pasamos a la vista una lista de los datos de la tabla Especialidad
        }

        public async Task<IActionResult> Edit(int? id){//int? permite valores nulos
            if(id == null){
                return NotFound();
            }
            var especialidad = await _context.Especialidad.FindAsync(id); //objeto que permite obtener este dato de la base de datos según el id del registro que se paso 
            if(especialidad == null){//no se encontró en la db el registro
                return NotFound();
            }
            return View(especialidad);
        }
        ///<summary>
        ///Se recibe la descripción y el id del registro en la base de datos
        ///</summary>
        [HttpPost]//Esto diferencia el metodo Edit que graba, del Edit de vista
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad, descripción")] Especialidad especialidad){
            if(id != especialidad.IdEspecialidad){
                return NotFound();
            }
            if(ModelState.IsValid){
                _context.Update(especialidad);//actualizamos datos nuevos
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); //retornamos a la vista principal
            }
            return View(); 
        }
        ///<summary>
        ///Se recibe el id del registro a borrar en la tabla Especialidad
        ///</summary>
        public async Task<IActionResult> Delete(int? id){
            if(id == null){
                return NotFound();
            }
            var especialidad = await _context.Especialidad.FirstOrDefaultAsync(e => e.IdEspecialidad == id); //obtiene la primera coincidencia en la db que sea igual al id enviado. Si no ha encontrado registros devuelve un null
            if(especialidad == null){
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id){
            var especialidad = await _context.Especialidad.FindAsync(id);
            if(especialidad == null){
                return NotFound();
            }
            _context.Especialidad.Remove(especialidad); //con LINQ eliminamos el registro de la base de datos
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ///<summary>
        ///Metodo que crea una nueva especialidad en la tabla de la db
        ///</summary>
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdEspecialidad,descripción")] Especialidad especialidad){
            if(ModelState.IsValid){
                _context.Add(especialidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}