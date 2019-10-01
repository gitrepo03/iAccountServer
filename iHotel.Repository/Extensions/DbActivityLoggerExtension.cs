using iHotel.Entity.Common;
using iHotel.Entity.Identity;
using iHotel.Repository.Extensions.DbExtension;
using iHotel.Repository.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace iHotel.Repository.Extensions
{
    public class DbActivityLoggerExtension
    {
        public static void LogDataWriteActivity(IHotelDbContext db)
        {
            //Get all Entities which has state of Added
            var addedEntities = db.ChangeTracker.Entries()
                .Where(p => p.State == EntityState.Added).ToList();

            //Get all Entities which has state of Modified | Delete | Detached
            var modifiedEntities = db.ChangeTracker.Entries()
                .Where(p =>
                       p.State == EntityState.Modified
                    || p.State == EntityState.Deleted
                    || p.State == EntityState.Detached
                ).ToList();

            List<String> EntityAllowedWithoutAudId = new List<string>() { "WriteActivityLog", "ChangeLog" };
            

            LoggedInUserModel loggedUser = new IdentityAuth(db).getLoggedInUserClames();

            //Get List of Entityes that doesnot contains value from AuditId(AudId) Property.
            addedEntities.Where(ae =>
                   !EntityAllowedWithoutAudId.Contains(ae.Entity.GetType().Name)
                && ae.Entity is BaseEntity
            ).ToList().ForEach(ae => {
                ae.Property("AudId").CurrentValue = Utility.GenerateUnikeAuditId();
                var orgProp = ae.Metadata.FindProperty("Organization");
                if (orgProp != null)
                {
                    var org = ae.Property("Organization");
                    var orgCurValue = int.Parse(org.CurrentValue.ToString());
                    var isOrgHasValue = orgCurValue <= 0;
                    ae.Property("Organization").CurrentValue = (isOrgHasValue ? int.Parse(loggedUser.Organization) : org.CurrentValue);
                }
            });

            var addedEntityWithout_AudId = addedEntities.Where(ae =>
                   !EntityAllowedWithoutAudId.Contains(ae.Entity.GetType().Name)
                && ae.Entity is BaseEntity
            ).Where(wa => string.IsNullOrEmpty(wa.Property("AudId")?.CurrentValue?.ToString()) == true).ToList();

            //Check if Entity to add contains AuditId(AudId) or not.
            //If any Entity doesnot contains AuditId(AudId) then throw exception.
            if (addedEntityWithout_AudId.Count > 0)
            {
                throw new InvalidDataException("Entity without AuditId(AudId) found. Please supply value for AudId.");
            }

            List<WriteActivityLog> writeActLogs = new List<WriteActivityLog>();
            List<ChangeLog> changeLogs = new List<ChangeLog>();



            var currentNepaliDate = NepaliDateConverter.DateConverter.ConvertToNepali(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            //Loop over all Entities with state of Added and 
            //Log them in table WriteActivityLog.
            foreach (var newEntry in addedEntities)
            {
                //If Entity doesnot has base class of BaseEntity class then 
                //that means that we doent want to Audit that Entity.
                if (!(newEntry.Entity is BaseEntity))
                {
                    continue;
                }
                var entityName = newEntry.Entity.GetType().Name;
                var primaryKeyValue = GetPrimaryKeyValue(db, newEntry.Entity);

                WriteActivityLog writeActLog = new WriteActivityLog()
                {
                    ActivityTable = entityName,
                    AudId = newEntry.Property("AudId").CurrentValue.ToString(),
                    ActivityType = true,
                    DateBs = currentNepaliDate.Year + "/" + currentNepaliDate.Month + "/" + currentNepaliDate.Day,
                    ActivityBy = loggedUser.UserName,
                    Organization = loggedUser.Organization != null ? int.Parse(loggedUser.Organization) : 0
                };
                //db.Attach(writeActLog).State = EntityState.Added;
                writeActLogs.Add(writeActLog);
            }

            //Loop over all Entities with state of Modified | Delete | Detached and 
            //Log Modified in table WriteActivityLog & ChangeLog.
            foreach (var change in modifiedEntities)
            {
                //If Entity doesnot has base class of BaseAuditClass then 
                //that means that we doent want to Audit that Entity.
                if (!(change.Entity is BaseEntity))
                {
                    continue;
                }

                var entityName = change.Entity.GetType().Name;
                var primaryKeyValue = GetPrimaryKeyValue(db, change.Entity);
                primaryKeyValue = primaryKeyValue != -1
                        ? primaryKeyValue
                        : int.Parse(change.Property("Id")?.CurrentValue?.ToString());

                if (change.State == EntityState.Modified)
                {
                    WriteActivityLog writeActLog = new WriteActivityLog()
                    {
                        ActivityTable = entityName,
                        AudId = change.Property("AudId").CurrentValue.ToString(),
                        ActivityType = false,
                        DateBs = currentNepaliDate.Year + "/" + currentNepaliDate.Month + "/" + currentNepaliDate.Day,
                        ActivityBy = loggedUser.UserName,
                        Organization = int.Parse(loggedUser.Organization)
                    };
                    writeActLogs.Add(writeActLog);
                    //db.Attach(writeActLog).State = EntityState.Added;

                    var databaseValues = change.GetDatabaseValues();

                    foreach (var prop in change.Entity.GetType().GetProperties())
                    {
                        if (!prop.GetGetMethod().IsVirtual)
                        {
                            if (change.Property(prop.Name).IsModified)
                            {
                                var currentValue = change.Property(prop.Name).CurrentValue;
                                //var originalValue = change.Property(prop.Name).OriginalValue;
                                var originalValue = databaseValues.GetValue<object>(prop.Name);
                                if (originalValue?.ToString() != currentValue?.ToString())
                                {
                                    ChangeLog changeLog = new ChangeLog
                                    {
                                        ColumnName = prop.Name,
                                        TableName = entityName,
                                        RowId = primaryKeyValue,
                                        OldValue = originalValue.ToString(),
                                        NewValue = currentValue.ToString(),
                                        ChangedBy = loggedUser.UserName,
                                        LogDateBS = currentNepaliDate.Year + "/" + currentNepaliDate.Month + "/" + currentNepaliDate.Day,
                                        Organization = int.Parse(loggedUser.Organization)
                                    };
                                    changeLogs.Add(changeLog);
                                    //db.Attach(changeLog).State = EntityState.Added;
                                }
                            }
                        }
                    }
                }
            }
            db.WriteActivityLogs.AddRange(writeActLogs);
            db.ChangeLogs.AddRange(changeLogs);
            //this.Attach(writeActLogs).State = EntityState.Added;
            //this.Attach(WriteActivityLogs).State = EntityState.Added;
        }

        #region LogDataWriteActivity Method's Helper Methods

        protected static int GetPrimaryKeyValue<T>(IHotelDbContext db, T entity)
        {
            //TODO: 
            //This is not ideal for table with multiple primary keys. 
            //So needed to change this in future.

            var test = entity;
            var test2 = test.GetType();
            var keyName = db.Model.FindEntityType(test2).FindPrimaryKey().Properties
                .Select(x => x.Name).Single();
            var result = (int)entity.GetType().GetProperty(keyName).GetValue(entity, null);
            if (result < 0)
                return -1;

            return result;
        }

        #endregion

    }
}
