using Core.Entities.Usuarios;
using Core.Services.Usuarios;
using Servico.Models.Base;
using Servico.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Servico.Controllers
{
    public class UsuarioController : ApiController
    {

        private UsuarioService usuarioService;

        public UsuarioController(DbContext context)
        {
            usuarioService = new UsuarioService(context);
        }

        [HttpPost]
        public IHttpActionResult Autenticar([FromBody] AutenticacaoModel dados)
        {
            try
            {
                var usuario = usuarioService.Autenticar(dados.email, dados.senha);
                var model = new UsuarioModel(usuario);
                return Ok(model);
            }
            catch(Exception e)
            {
                return Ok(new MensagemModel(MensagemModel.Tipos.Erro, e.Message));
            }
        }

    }
}
