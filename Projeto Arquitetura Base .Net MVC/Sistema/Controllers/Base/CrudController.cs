using System.Runtime.InteropServices;
using Core.Entities.Base;
using Core.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema.Controllers.Base
{

    public abstract class CrudController<T> : SecurityController where T : PersistentEntity
    {

        public PersistentRepository<T> repository;

        public CrudController(DbContext context)
            : base(context)
        {
            repository = new PersistentRepository<T>(context);
        }

        public virtual ActionResult Index()
        {
            var items = repository.GetAll();
            return View(items);
        }

        public virtual ActionResult Criar()
        {
            return View("Editar");
        }

        public virtual ActionResult Editar(int id)
        {
            var item = repository.Get(id);
            if (item != null)
            {
                return View(item);
            }
            return RedirectToAction("Index", new { erro = "Item não encontrado." });
        }

        [ValidateInput(false)]
        [HttpPost]
        public virtual ActionResult Salvar(T planoAcao)
        {
            if (planoAcao.ID == 0)
            {
                planoAcao.DataCriacao = DateTime.Now;
            }
            planoAcao.DataAlteracao = DateTime.Now;
            repository.Save(planoAcao);
            return RedirectToAction("Index", new { sucesso = "O item foi salvo." });
        }

        public virtual ActionResult Excluir(int id)
        {
            try
            {
                repository.Delete(id);
                return RedirectToAction("Index", new { sucesso = "O item foi excluído." });
            }
            catch
            {
                return RedirectToAction("Index", new { erro = "Não é possível excluir este item." });
            }
        }

    }
}