using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities.Base
{
    public class MainContext : DbContext
    {

        public MainContext()
            : base("name=MainConnectionString")
        {

        }


        public DbSet<Usuarios.Usuario> Usuarios { get; set; }

    }
}
