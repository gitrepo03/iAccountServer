using iHotel.Entity.Accounting;
using iHotel.Entity.Admin;
using iHotel.Entity.Common;
using iHotel.Entity.Identity;
using iHotel.Repository.Extensions;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.RepoInterface;
using iHotel.Repository.Repository;
using iHotel.Repository.SignalRHub;
using iHotel.Service.ServiceInterface;
using iHotel.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iHotelManagement
{
    public static class ConfigContainerExtensions
    {
        #region DataContextRegion

        public static void AddDbContext(
            this IServiceCollection services,
            string dataConnectionString = null, 
            string authConnectionString = null
        )
        {
            services.AddDbContext<IHotelDbContext>(options =>
                    options.UseSqlServer(dataConnectionString ?? GetDataConnectionStringFromConfig()));

            //services.AddDbContext<iSchoolIdentityAuthDbContext>(options =>
            //    options.UseSqlServer(authConnectionString ?? GetAuthConnectionStringFromConfig()));

            //services.AddDefaultIdentity<ApplicationUser>()
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<iSchoolIdentityAuthDbContext>()
            //    .AddDefaultTokenProviders();

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IHotelDbContext>()
                .AddDefaultTokenProviders();
        }

        private static string GetDataConnectionStringFromConfig()
        {
            return new DbConfig().GetDataConnectionString();
        }

        private static string GetAuthConnectionStringFromConfig()
        {
            return new DbConfig().GetAuthConnectionString();
        }

        #endregion

        #region RepositoryRegion

        public static void AddRepository(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IRepository<>), typeof(DataRepository<>));
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UsersRepository>();
            services.AddScoped<IReadRepository<WriteActivityLog>, ReadRepository<WriteActivityLog>>();
            //services.AddScoped<IDataLoggerExtension, DbActivityLoggerExtension>();
            services.AddScoped<IRepository<Organization>, OrganizationRepository>();
            services.AddScoped<IRepository<FiscalYear>, FiscalRepository>();
            services.AddScoped<IRepository<LedgerRef>, LedgerRefRepository>();
            services.AddScoped<IRepository<AccountRef>, AccountRefRepository>();
            services.AddScoped<IRepository<VoucherType>, VoucherTypeRepository>();
            services.AddScoped<IRepository<VoucherMaster>, VoucherMasterRepository>();
            services.AddScoped<IRepository<VoucherDetail>, VoucherDetailRepository>();

            //services.AddScoped<IWriteActivityLogRepository, WriteActivityLogRepository>();
            //services.AddTransient<ICustomerRepository, CustomerRepository>();
        }

        #endregion

        #region TransientServicesRegion

        public static void AddTransientServices(this IServiceCollection services)
        {
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IOrganizationService, OrganizationService>();

            services.AddTransient<IFiscalService, FiscalService>();
            services.AddTransient<ILedgerRefService, LedgerRefService>();
            services.AddTransient<IAccountRefService, AccountRefService>();
            services.AddTransient<IVoucherTypeService, VoucherTypeService>();
            services.AddTransient<IVoucherMasterService, VoucherMasterService>();
            services.AddTransient<IVoucherDetailService, VoucherDetailService>();


        }

        #endregion

        #region SingletonServicesRegion

        public static void AddSingletonServices(this IServiceCollection services)
        {
            services.AddSingleton<AppHub<Organization>>();
            services.AddSingleton<AppHub<FiscalYear>>();
            services.AddSingleton<AppHub<VoucherType>>();
            services.AddSingleton<AppHub<AccountRef>>();
            services.AddSingleton<AppHub<LedgerRef>>();
            services.AddSingleton<AppHub<VoucherMaster>>();
            services.AddSingleton<AppHub<VoucherDetail>>();

        }

        #endregion
    }
}
