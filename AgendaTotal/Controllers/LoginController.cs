using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using AgendaTotal.Models;
using AgendaTotal.Services;

namespace AgendaTotal.Controllers
{
    public class LoginController : Controller
    {
        private readonly Repositories.ADO.SQLServer.LoginDAO repository;
        private readonly AgendaTotal.Services.ISessao sessao;

        public LoginController(IConfiguration configuration, ISessao sessao)
        {
            this.repository = new Repositories.ADO.SQLServer.LoginDAO(configuration.GetConnectionString(AgendaTotal.Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
        }
        public IActionResult Login()
        {
            // Se o usuário não estiver logado retorna a View() senão retorna para a página de início
            return this.sessao.getTokenLogin() == null ? View() : RedirectToAction("Index", "Home");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Usuario login)
        {
            #region "Login com controle de sessão"
            if (!string.IsNullOrEmpty(login.email) && !string.IsNullOrEmpty(login.senha))
            {
                if (this.repository.check(login))
                {
                    var loginResultado = repository.getTipo(login);
                    this.sessao.addTokenLogin(login);

                    if (loginResultado.TipoUsuario == "Alex")

                        return RedirectToAction("Index", "Usuario");
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError(string.Empty, "Usuário e/ou Senha Inválidos!");
            }
            return View();
            #endregion


            #region "Login sem controle de sessão"
            /*
            if (!string.IsNullOrEmpty(login.Usuario) && !string.IsNullOrEmpty(login.Senha))
            {
                
                if (this.repository.check(login))
                    return RedirectToAction("Index", "Home");
                return RedirectToAction("Login", "Login");
                
             }
            ViewBag.Error = "Usuário e/ou Senha Inválidos!";
            return View();
            */
            #endregion
        }

        public IActionResult Logout()
        {
            this.sessao.deleteTokenLogin();
            return RedirectToAction("Index", "Home");
        }
    }
}
