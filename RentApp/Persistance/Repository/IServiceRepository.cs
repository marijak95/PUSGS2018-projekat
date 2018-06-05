using RentApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RentApp.Persistance.Repository
{
    public interface IServiceRepository : IRepository<Service, int>
    {
        IEnumerable<Service> GetAll(int pageIndex, int pageSize);
    }
}