using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Core.Entities;
using Core.Entities.Base;

namespace Servico.App_Start
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<DbContext>().To<MainContext>();
        }
    }
}