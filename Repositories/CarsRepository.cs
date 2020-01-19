using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace Repositories
{
    public class CarsRepository : BaseRepository<Car>
    {
      
        public List<Car> GetByUserId(int userId)
        {
            return Context.Set<Car>().Where(item => item.Owner == userId).ToList();
        }

        public override void Save(Car item)
        {
            if (item.ID == 0)
            {
                base.Create(item);
            }
            else
            {
                base.Update(item, car => car.ID == item.ID);
            }
        }
    }
}
