using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Repository.Helper
{
    public class ExceptionHandler
    {
        public static string AbstractExceptionMessage(Exception ex)
        {
            var innerExcp = ex.InnerException;
            while (innerExcp != null)
            {
                if (innerExcp.InnerException == null)
                {
                    return innerExcp.Message;
                }
                innerExcp = innerExcp.InnerException;
            }
            return ex.Message;
        }
    }
}
