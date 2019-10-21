using iHotel.Entity.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHotel.Service.ServiceInterface
{
    public interface IQueryBuilderService<T>
    {
        IQueryable walOrgJoinQuery(IQueryable<T> source);
    }
}
