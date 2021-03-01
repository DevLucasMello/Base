using Core.Entities.Usuarios;
using Core.Repositories.Usuarios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Usuarios
{
    public class UsuarioService
    {

        private UsuarioRepository usuarioRepository;

        public UsuarioService(DbContext context)
        {
            usuarioRepository = new UsuarioRepository(context);
        }

        public Usuario Autenticar(Guid codigo)
        {
            var usuario = usuarioRepository.GetByCodigo(codigo);
            return Autenticar(usuario);
        }

        public Usuario Autenticar(string email, string senha)
        {
            var usuario = usuarioRepository.GetByEmailSenha(email, senha);
            return Autenticar(usuario);
        }

        public Usuario Autenticar(Usuario usuario)
        {
            if(usuario == null)
            {
                throw new Exception("Usuário não localizado");
            }
            if (usuario.Bloqueado)
            {
                throw new Exception("Acesso bloqueado");
            }
            usuario.UltimoAcesso = DateTime.Now;
            usuarioRepository.Save(usuario);
            return usuario;
        }

    }
}
