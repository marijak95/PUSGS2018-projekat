using System;
using System.Collections.Generic;
using System.Linq;
using RentApp.Models.Entities;
using System.Web;
using System.Data.Entity;

namespace RentApp.Persistance.Repository
{
    public class GradingRepository : Repository<Grading, int>, IGradingRepository
    {
        public GradingRepository(DbContext context) : base(context)
        {
        }

        public IEnumerable<Grading> GetAll(int pageIndex, int pageSize)
        {
            return RADBContext.Gradings.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }

        protected RADBContext RADBContext { get { return context as RADBContext; } }
    }
}