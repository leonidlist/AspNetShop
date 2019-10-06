using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class GoodRepository : GenericRepository<Good>
    {
        public GoodRepository(ShopContext context) : base(context)
        {

        }
    }
}
