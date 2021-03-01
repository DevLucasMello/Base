using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Usuarios
{
    public class UsuarioRepository : Base.PersistentRepository<Entities.Usuarios.Usuario>
    {

        public UsuarioRepository(DbContext context) : base(context)
        {
        }

        public Entities.Usuarios.Usuario GetByCodigo(Guid codigo)
        {
            return this.GetByExpression(u => u.Codigo.CompareTo(codigo) == 0).FirstOrDefault();
        }

        public Entities.Usuarios.Usuario GetByEmailSenha(string email, string senha)
        {
            return this.GetByExpression(u => u.Email == email && u.Senha == senha).FirstOrDefault();
        }

    }
}
