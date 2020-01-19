using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BrandRepository : BaseRepository<Brand>
    {
        public override void Save(Brand item)
        {
            if (item.ID == 0)
            {
                base.Create(item);
            }
            else
            {
                base.Update(item, brand => brand.ID == item.ID);
            }

        }
    }
}
