using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Turnos.Models;
using Microsoft.EntityFrameworkCore;

namespace Turnos.Controllers{
    public class PacienteController : Controller{
        private readonly TurnosContext _context; 
        public PacienteController(TurnosContext context){
            _context = context;
        }
        ///<summary>
        ///Pagina principal de MVC Paciente
        ///</summary>
        public async Task<IActionResult> Index(){
            return View(await _context.Paciente.ToListAsync());
        }

        ///<summary>
        ///Metodo que obtiene los detalles del paciente, retornamos la info del paciente solicitado a la vista
        ///</summary>
        public async Task<IActionResult> Details(int? id){
            if(id == null){
                return NotFound();
            }
            var paciente = await _context.Paciente.FirstOrDefaultAsync(p => p.idPaciente == id);
            if(paciente == null){
                return NotFound();
            }
            return View(paciente);
        }

        ///<summary>
        ///Metodo get para obtener la vista crear
        ///</summary>
        public IActionResult Create(){
            return View();
        }

        ///<summary>
        ///Metodo Post para obtener la informacion nueva de un paciente y agregarla a la tabla en bd
        ///<param name="paciente">objeto con la información del paciente</param>
        ///</summary>
        [HttpPost]
        [ValidateAntiForgeryToken]//valida que nuestro metodo ha sido ejecutado a traves de un formulario y no durante la url del navegador
        public async Task<IActionResult> Create([Bind("idPaciente,Nombre,Apellido,Direccion,Email,Telefono")] Paciente paciente){
            if(ModelState.IsValid){
                _context.Add(paciente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}