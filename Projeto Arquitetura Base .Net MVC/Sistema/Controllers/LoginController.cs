using Core.Entities.Usuarios;
using Core.Services.Usuarios;
using Sistema.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Sistema.Controllers
{
    public class LoginController : Controller
    {

        private UsuarioService usuarioService;

        public LoginController(DbContext context)
        {
            usuarioService = new UsuarioService(context);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Acessar(Guid codigo)
        {
            try
            {
                var usuario = usuarioService.Autenticar(codigo);
                return Autenticar(usuario);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { erro = e.Message });
            }
        }

        [HttpPost]
        public ActionResult Entrar(string email, string senha)
        {
            try
            {
                var usuario = usuarioService.Autenticar(email, senha);
                return Autenticar(usuario);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", new { erro = e.Message });
            }
        }

        public ActionResult Sair()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }

        private ActionResult Autenticar(Usuario usuario)
        {
            var authenticatedUserModel = new AuthenticatedUserModel()
            {
                ID = usuario.ID,
                Name = usuario.Nome,
                ExpiresIn = DateTime.Now.AddMinutes(60)
            };
            authenticatedUserModel.AccessGroups.Add(usuario.Tipo.ToString());

            FormsAuthentication.SetAuthCookie(authenticatedUserModel.ToJSON(), true);
            return RedirectToAction("Index", "Home");
        }

    }
}