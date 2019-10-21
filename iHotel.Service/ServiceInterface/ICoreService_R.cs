using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHotel.Service.ServiceInterface
{
    public interface ICoreService_R<T>
    {
        //Get all.
        IQueryable<T> GetAll();
        //Get all Active data.
        //IQueryable<T> GetAllActive();
        //Get all of organization.
        IQueryable<T> GetAllOfOrg();
        //Get all active of organization.
        //IQueryable<T> GetAllActiveOfOrg();
        //Get a single data with id.
        IQueryable<T> GetById(int id);
    }
}
