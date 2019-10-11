using iHotel.Entity.Accounting;
using iHotel.Entity.Admin;
using iHotel.Entity.Common;
using iHotel.Entity.Identity;
using iHotel.Repository.Extensions.DbExtension.Fluent;
using iHotel.Repository.RepoInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace iHotel.Repository.Extensions.DbExtension
{
    public class IHotelDbContext: IdentityDbContext<ApplicationUser>
    {
        public readonly IHttpContextAccessor _httpContextAccessor;

        public IHotelDbContext(
            DbContextOptions<IHotelDbContext> options,
            IHttpContextAccessor httpContextAccessor
        ) : base(options)
        {
            this._httpContextAccessor = httpContextAccessor;
    }

        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationImagePath> OrganizationImagePaths { get; set; }
        public virtual DbSet<WriteActivityLog> WriteActivityLogs { get; set; }
        public virtual DbSet<ChangeLog> ChangeLogs { get; set; }

        public virtual DbSet<LedgerRef> LedgerRefs{ get; set; }
        public virtual DbSet<VoucherType> VoucherTypes{ get; set; }
        public virtual DbSet<VoucherDetail> VoucherDetails { get; set; }
        public virtual DbSet<VoucherMaster> VoucherMasters { get; set; }
        public virtual DbSet<FiscalYear> FiscalYears { get; set; }

        public virtual DbSet<UsersOrgs> UsersOrgs { get; set; }

        #region Override Methods Section

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            FluentApi.createEntityRules(modelBuilder);
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ChangeTracker.DetectChanges();
            //_dataLogger.LogDataWriteActivity(this);
            new DbActivityLoggerExtension().LogDataWriteActivity(this);

            return base.SaveChanges();
        }

        public async override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess, 
            CancellationToken cancellationToken = default(CancellationToken)
        )
        {
            this.ChangeTracker.DetectChanges();
            //await _dataLogger.LogDataWriteActivity(this);
            new DbActivityLoggerExtension().LogDataWriteActivity(this);

            return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        #endregion
    }
}
