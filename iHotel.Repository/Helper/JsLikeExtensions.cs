using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace iHotel.Repository.Helper
{
    public class JsLikeExtensions
    {
        public static object sprade(List<object> objsToSprade, object objToContain)
        {
            foreach (object obj in objsToSprade)
            {
                JsonConvert.SerializeObject(obj);
            }
            return objToContain;
        }
    }
}
