using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.RepoInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iHotel.Repository.Extensions
{
    public interface IDataLoggerExtension
    {
        Task LogDataWriteActivity(IHotelDbContext db);
    }
}
