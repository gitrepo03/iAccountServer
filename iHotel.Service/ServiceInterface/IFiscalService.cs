using iHotel.Entity.Accounting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iHotel.Service.ServiceInterface
{
    public interface IFiscalService : ICoreService<FiscalYear>, ICoreService_R<FiscalYear_R> { }
}
