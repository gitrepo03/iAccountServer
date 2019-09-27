using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Repository.Extensions.DbExtension
{
    public class DbConfig : ConfigBase
    {
        private string DataConnectionKey = "SQLContext";
        private string DataConnectionKeyForSQLite = "HotelMGNTContextSQLite";
        private string AuthConnectionKey = "IdentityAuthContext";

        public string GetDataConnectionString()
        {
            return GetConfiguration().GetConnectionString(DataConnectionKey);
        }

        public string GetDataConnectionStringForSQLite()
        {
            return GetConfiguration().GetConnectionString(DataConnectionKeyForSQLite);
        }

        public string GetAuthConnectionString()
        {
            return GetConfiguration().GetConnectionString(AuthConnectionKey);
        }
    }
}
