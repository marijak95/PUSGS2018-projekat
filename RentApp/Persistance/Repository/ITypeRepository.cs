using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentApp.Models.Entities;

namespace RentApp.Persistance.Repository
{
    public interface ITypeRepository : IRepository<RentApp.Models.Entities.Type, int>
    {
        IEnumerable<RentApp.Models.Entities.Type> GetAll(int pageIndex, int pageSize);
    }
}
