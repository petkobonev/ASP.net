using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ModelsRepository : BaseRepository<Model>
    {
        public override void Save(Model item)
        {
            if (item.ID == 0)
            {
                base.Create(item);
            }
            else
            {
                base.Update(item, model => model.ID == item.ID);
            }
        }
    }
}
