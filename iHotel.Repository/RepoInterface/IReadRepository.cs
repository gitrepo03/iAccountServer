using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHotel.Repository.RepoInterface
{
    public interface IReadRepository<T>
    {
        //Get a single data with id.
        IQueryable<T> GetById(int id);
        //Get all.
        IQueryable<T> GetAll();
        //Get all Active data.
        IQueryable<T> Get();
    }
}
