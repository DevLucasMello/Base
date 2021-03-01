using Core.Entities.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico.Models.Usuarios
{
    public class UsuarioModel
    {

        private Usuario _usuario;

        public Guid codigo { get { return _usuario.Codigo; } }
        public string nome { get { return _usuario.Nome; } }
        public string email { get { return _usuario.Email; } }

        public UsuarioModel(Usuario usuario)
        {
            this._usuario = usuario;
        }

    }
}
