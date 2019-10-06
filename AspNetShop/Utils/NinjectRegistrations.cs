using DAL.Abstractions;
using DAL.Models;
using DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetHWCrud.Utils
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Good>>().To<GoodRepository>();
            Bind<IRepository<Manufacturer>>().To<ManufacturerRepository>();
            Bind<IRepository<Category>>().To<CategoryRepository>();
        }
    }
}