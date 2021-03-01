using Core.Entities.Usuarios;
using Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sistema.Filters;
using Sistema.Models;
using Core.Helpers;

namespace Sistema.Controllers.Base
{

    /// <summary>
    /// Class to ensure that the user is logged in and load his data
    /// </summary>
    [Authorization]
    public abstract class SecurityController : Controller
    {

        public enum Menu
        {
            Home = 1
        }

        public PersistentRepository<Usuario> usuarioRepository;
        public Usuario usuario;

        public SecurityController(DbContext context)
        {
            usuarioRepository = new PersistentRepository<Usuario>(context);
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var authenticatedUserModel = AuthenticatedUserModel.GetFromJSON(HttpContext.User.Identity.Name);
                usuario = usuarioRepository.Get(authenticatedUserModel.ID);
                ViewBag.Usuario = usuario;
            }
            return base.BeginExecuteCore(callback, state);
        }

    }

}