using AgendaTotal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;

namespace AgendaTotal.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly Repositories.ADO.SQLServer.UsuarioDAO repository;

        // objeto configuration => parte do framework que permite ler o
        //                         arquivo appsettings.json - GetConnectionString => método
        //                         do framework que permite ler a chave ConnectionStrings deste arquivo.
        public UsuarioController(IConfiguration configuration)
            {
                this.repository = new Repositories.ADO.SQLServer.UsuarioDAO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
                // Configurations.Appsettings.getKeyConnectionString() => nossa classe de configuração
                //    para trazer a chave que deve ser lida, neste caso: DefaultConnection.
            }


            // GET => getAll() : CarrosController
            [HttpGet]
            public IActionResult Index()
            {
                return View(this.repository.getAll());
            }

            // GET : CarrosController/Details/5 (id)
            [HttpGet]
            public IActionResult Details(int id)
            {
                return View(this.repository.getByIdUsuario(id));
            }

        // GET : CarrosController/Edit/5 (id)
            [HttpGet]
            public IActionResult Edit(int id)
            {
                return View(this.repository.getByIdUsuario(id));
            }

            // POST : CarrosController/Edit
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Edit(int id, Usuario usuario)
            {
                try
                {
                    this.repository.update(id,usuario);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
        // GET e POST do Create.
        // GET : CarrosController/Create
        [HttpGet]
            public IActionResult Create()
            {
                return View();
            }

            // POST : CarrosController/Create
            [HttpPost]
            [ValidateAntiForgeryToken]
            public IActionResult Create(Usuario usuario)
            {
                try
                {
                    this.repository.add(usuario);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {

                    return View();
                }



            }
       

        // GET : CarrosController/Delete/5
        [HttpGet]

            public IActionResult Delete(int id)
            {
                this.repository.delete(id);
                return RedirectToAction(nameof(Index));
            }
        }

    }



