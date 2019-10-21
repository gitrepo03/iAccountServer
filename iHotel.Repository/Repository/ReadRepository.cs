using iHotel.Entity.Common;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.RepoInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace iHotel.Repository.Repository
{
    public class ReadRepository<T>: IReadRepository<T> where T : EntityBase
    {
        private DbSet<T> entities;
        public ReadRepository(IHotelDbContext context){
            entities = context.Set<T>();
        }
        public IQueryable<T> GetAll()
        {
            return entities;
        }

        public IQueryable<T> Get()
        {
            return GetAll().Where(es => es.IsActive == true);
        }

        public IQueryable<T> GetById(int id)
        {
            if (id <= 0)
            {
                throw new InvalidDataException("Id must be greater than zero.");
            }
            //return entities.SingleOrDefault(e => e.Id == id);
            return Get().Where(e => e.IsActive && e.Id == id);
        }
    }
}
