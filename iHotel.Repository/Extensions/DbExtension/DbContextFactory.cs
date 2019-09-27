using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Repository.Extensions.DbExtension
{
    public class DbContextFactory : IDesignTimeDbContextFactory<IHotelDbContext>
    {
        private readonly IHttpContextAccessor _httpContext;

        public DbContextFactory()
        {

        }

        public DbContextFactory(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        private static string DataConnectionString => new DbConfig().GetDataConnectionString();
        private static string DataConnectionStringForSQLite => new DbConfig().GetDataConnectionStringForSQLite();
        public IHotelDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IHotelDbContext>();

            optionsBuilder.UseSqlServer(DataConnectionString);
            //optionsBuilder.UseSqlite(DataConnectionStringForSQLite);

            return new IHotelDbContext(optionsBuilder.Options, _httpContext);
        }
    }
}
