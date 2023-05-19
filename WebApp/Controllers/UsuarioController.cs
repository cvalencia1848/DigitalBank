using Microsoft.AspNetCore.Mvc;
using Models;
using Service;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        // GET: UsuarioController
        public async Task<ActionResult> Index()
        {
            var listaUsuario = await usuarioService.ObtenerUsuarioTodos();
            return View(listaUsuario);
        }

        // GET: UsuarioController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var usuario = await usuarioService.ObtenerUsuariosPorId(id);
            return View(usuario);
        }

        // GET: UsuarioController/Create
        public ActionResult Create()
        {
            var generos = usuarioService.Generos();
            ViewBag.Generos = generos;
            return View();
        }

        // POST: UsuarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario, string opcionGenero)
        {
            try
            {
                usuario.Sexo = opcionGenero;
                //this.usuarioService.AgregarUsuario(usuario);
                usuarioService.AgregarUsuarioSP(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: UsuarioController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var usuario = await usuarioService.ObtenerUsuariosPorId(id);
            return View(usuario);
        }

        // POST: UsuarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Usuario usuario)
        {
            try
            {
                usuarioService.ActualizarUsuarioSP(usuario);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuarioController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var usuario = await usuarioService.ObtenerUsuariosPorId(id);
            return View(usuario);
        }

        // POST: UsuarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                usuarioService.EliminarUsuarioSP(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
