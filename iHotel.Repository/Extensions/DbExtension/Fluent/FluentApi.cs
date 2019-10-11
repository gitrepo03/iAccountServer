using iHotel.Entity.Accounting;
using iHotel.Entity.Admin;
using iHotel.Entity.Common;
using iHotel.Entity.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHotel.Repository.Extensions.DbExtension.Fluent
{
    public class FluentApi
    {
        public static void createEntityRules(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasIndex(e => e.OrgCode)
                    .IsUnique();

                entity.Property(e => e.OrgCode)
                    .IsRequired();

                //entity.HasIndex(e => e.AudId)
                //    .IsUnique();

                entity.Property(e => e.Address)
                    .HasMaxLength(500);

                entity.Property(e => e.ContactNo)
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(100);

                entity.Property(e => e.EstablishedDateAd)
                    .HasColumnName("EstablishedDate_AD")
                    .HasColumnType("date");

                entity.Property(e => e.EstablishedDateBs)
                    .HasColumnName("EstablishedDate_BS")
                    .HasMaxLength(10);

                entity.Property(e => e.IsActive)
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Logo)
                    .HasMaxLength(200);

                entity.Property(e => e.OrgCode)
                    .HasMaxLength(100);

                entity.Property(e => e.OrgName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.OrgNameNp)
                    .HasColumnName("OrgName_Np")
                    .HasMaxLength(500);

                entity.Property(e => e.PanNo)
                    .HasMaxLength(50);

                entity.Property(e => e.Quote).HasMaxLength(1000);

                entity.Property(e => e.Website)
                    .HasMaxLength(250);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IsActive")
                    .HasDefaultValueSql("((1))");

                //entity.HasOne(o => o.UserNavigation)
                //   .WithMany(u => u.Organizations)
                //   .HasForeignKey(ar => ar.User)
                //   .HasConstraintName("FK__AppUser__Organization__5B23C598");
            });

            modelBuilder.Entity<OrganizationImagePath>(entity =>
            {
                entity.HasOne(d => d.OrganizationNavigation)
                    .WithMany(p => p.OrganizationImagePaths)
                    .HasForeignKey(d => d.Organization)
                    .HasConstraintName("FK__Organizat__organ__52593CB8");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasIndex(e => e.AudId)
                    .IsUnique();

                entity.Property(e => e.Organization)
                    .IsRequired();

                entity.Property(e => e.ImgPath)
                    .HasMaxLength(100);

                entity.Property(e => e.PathTitle)
                    .HasMaxLength(50);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IsActive")
                    .HasDefaultValueSql("((1))");

            });

            modelBuilder.Entity<WriteActivityLog>(entity =>
            {
                entity.HasOne(w => w.OrganizationNavigation)
                   .WithMany(o => o.WriteActivityLogs)
                   .HasForeignKey(w => w.Organization)
                   .HasConstraintName("FK__Organizat__WriteActLog__5B23C598");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Organization)
                    .IsRequired();

                entity.Property(e => e.ActivityBy)
                    .HasMaxLength(150);

                entity.Property(e => e.ActivityTable)
                    .HasMaxLength(50);

                entity.Property(e => e.DateAd)
                    .HasColumnName("Date_AD")
                    .HasColumnType("date")
                    .HasDefaultValueSql("CONVERT(date, getdate())");

                entity.Property(e => e.DateBs)
                    .HasColumnName("Date_BS")
                    .HasMaxLength(10);

                entity.Property(e => e.ActivityTime)
                    .HasColumnType("time")
                    .HasDefaultValueSql("CONVERT(time, getdate())");

                entity.Property(e => e.IsActive)
                    .HasColumnName("IsActive")
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<ChangeLog>(entity => {

                entity.HasOne(w => w.OrganizationNavigation)
                   .WithMany(o => o.ChangeLogs)
                   .HasForeignKey(w => w.Organization)
                   .HasConstraintName("FK__Organizat__ChangeLog__5B23C598");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Organization)
                    .IsRequired();

                entity.Property(e => e.LogDateAD)
                    .HasColumnName("LogDate_AD")
                    .HasColumnType("date")
                    .HasDefaultValueSql("CONVERT(date, getdate())");

                entity.Property(e => e.LogTime)
                    .HasColumnType("time")
                    .HasDefaultValueSql("CONVERT(time, getdate())");

                entity.Property(e => e.LogDateBS)
                    .HasColumnName("LogDate_BS")
                    .HasMaxLength(10);

                entity.Property(e => e.TableName)
                    .HasMaxLength(50);

                entity.Property(e => e.ColumnName)
                    .HasMaxLength(50);

                entity.Property(e => e.ChangedBy)
                    .HasMaxLength(100);
            });


            //ACCUONTING RULES------------------------------------------------------------------------------------------
            
            modelBuilder.Entity<AccountRef>(entity =>
            {
                entity.HasIndex(e => new { e.Fiscal, e.GroupCode })
                    .HasName("ACCOUNTREF_FISCALYEAR_GROUPCODE")
                    .IsUnique();

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Bs)
                    .IsRequired()
                    .HasColumnName("BS")
                    .HasMaxLength(1);

                entity.Property(e => e.Fiscal)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Pl)
                    .IsRequired()
                    .HasColumnName("PL")
                    .HasMaxLength(1);

                entity.Property(e => e.Tb)
                    .IsRequired()
                    .HasColumnName("TB")
                    .HasMaxLength(1);

                entity.HasOne(ar => ar.AccountRefNavigation)
                    .WithMany(arp => arp.AccountRefs)
                    .HasForeignKey(ar => ar.Parent)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ar => ar.OrganizationNavigation)
                   .WithMany(o => o.AccountRefs)
                   .HasForeignKey(ar => ar.Organization)
                   .HasConstraintName("FK__Org__AccRef__5B23C598");

                entity.HasOne(ar => ar.UserNavigation)
                   .WithMany(u => u.AccountRefs)
                   .HasForeignKey(ar => ar.User)
                   .HasConstraintName("FK__AppUser__AccRef__5B23C598");

                entity.HasOne(d => d.FiscalNavigation)
                    .WithMany(p => p.AccountRef)
                    .HasPrincipalKey(p => p.Fiscal)
                    .HasForeignKey(d => d.Fiscal)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AccountRef_Fiscal");
            });

            modelBuilder.Entity<FiscalYear>(entity =>
            {
                entity.HasIndex(e => new { e.Fiscal, e.Organization })
                    .HasName("UC_FISCALYEAR_ORGANIZATION")
                    .IsUnique();

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateBeginEnglish).HasColumnType("datetime");

                entity.Property(e => e.DateBeginNepali)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.DateEndEnglish).HasColumnType("datetime");

                entity.Property(e => e.DateEndNepali)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Fiscal)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.HasOne(w => w.OrganizationNavigation)
                   .WithMany(o => o.FiscalYears)
                   .HasForeignKey(w => w.Organization)
                   .HasConstraintName("FK__Organizat__Fiscal__5B23C598");

                entity.HasOne(ar => ar.UserNavigation)
                   .WithMany(u => u.Fiscals)
                   .HasForeignKey(ar => ar.User)
                   .HasConstraintName("FK__AppUser__Fiscal__5B23C598");
            });

            modelBuilder.Entity<LedgerRef>(entity =>
            {
                entity.HasIndex(e => new { e.FiscalYear, e.LedgerCode, e.GroupCode })
                    .HasName("LEDGERREF_FISCALYEAR_LEDGERCODE_GROUPCODE")
                    .IsUnique();

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BalanceType)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.FiscalYear)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.LedgerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(w => w.OrganizationNavigation)
                   .WithMany(o => o.LedgerRefs)
                   .HasForeignKey(w => w.Organization)
                   .HasConstraintName("FK__Organizat__LedgerRef__5B23C598");

                entity.HasOne(ar => ar.UserNavigation)
                   .WithMany(u => u.LedgerRefs)
                   .HasForeignKey(ar => ar.User)
                   .HasConstraintName("FK__AppUser__LedgerRef__5B23C598");

                entity.HasOne(d => d.AccountRef)
                    .WithMany(p => p.LedgerRefs)
                    .HasPrincipalKey(p => new { p.Fiscal, p.GroupCode })
                    .HasForeignKey(d => new { d.FiscalYear, d.GroupCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LedgerRef_AccountRef");
            });

            modelBuilder.Entity<VoucherDetail>(entity =>
            {
                entity.HasIndex(e => new { e.FiscalYear, e.VoucherNumber, e.VoucherCode, e.SerialNumber, e.LedgerCode })
                    .HasName("UC_Voucherdetail_Fiscalyear_vouchernumber_vouchertype_serialnumber_ledgercode")
                    .IsUnique();

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.BalanceType)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.FiscalYear)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.VoucherCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(w => w.OrganizationNavigation)
                   .WithMany(o => o.VoucherDetails)
                   .HasForeignKey(w => w.Organization)
                   .HasConstraintName("FK__Organizat__VoucherDetail__5B23C598");

                entity.HasOne(ar => ar.UserNavigation)
                   .WithMany(u => u.VoucherDetails)
                   .HasForeignKey(ar => ar.User)
                   .HasConstraintName("FK__AppUser__VoucherDetail__5B23C598");

                entity.HasOne(d => d.LedgerCodeNavigation)
                    .WithMany(p => p.VoucherDetails)
                    .HasForeignKey(d => d.LedgerCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoucherDetail_LedgerRef");

                entity.HasOne(d => d.VoucherMasters)
                    .WithMany(p => p.VoucherDetails)
                    .HasPrincipalKey(p => new { p.FiscalYear, p.VoucherNumber, p.VoucherCode })
                    .HasForeignKey(d => new { d.FiscalYear, d.VoucherNumber, d.VoucherCode })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoucherDetail_VoucherMaster");
            });

            modelBuilder.Entity<VoucherMaster>(entity =>
            {
                entity.HasIndex(e => new { e.FiscalYear, e.VoucherNumber, e.VoucherCode })
                    .HasName("VM_UC")
                    .IsUnique();

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateEnglish).HasColumnType("datetime");

                entity.Property(e => e.DateNepali)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.FiscalYear)
                    .IsRequired()
                    .HasMaxLength(9);

                entity.Property(e => e.InWords)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.VoucherCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.HasOne(w => w.OrganizationNavigation)
                   .WithMany(o => o.VoucherMasters)
                   .HasForeignKey(w => w.Organization)
                   .HasConstraintName("FK__Organizat__VoucherMaster__5B23C598");

                entity.HasOne(ar => ar.UserNavigation)
                   .WithMany(u => u.VoucherMasters)
                   .HasForeignKey(ar => ar.User)
                   .HasConstraintName("FK__AppUser__VoucherMaster__5B23C598");

                entity.HasOne(d => d.FiscalYearNavigation)
                    .WithMany(p => p.VoucherMasters)
                    .HasPrincipalKey(p => p.Fiscal)
                    .HasForeignKey(d => d.FiscalYear)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoucherMaster_Fiscal");

                entity.HasOne(d => d.VoucherCodeNavigation)
                    .WithMany(p => p.VoucherMasters)
                    .HasPrincipalKey(p => p.VoucherCode)
                    .HasForeignKey(d => d.VoucherCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VoucherMaster_VoucherType");
            });

            modelBuilder.Entity<VoucherType>(entity =>
            {
                entity.HasIndex(e => e.VoucherCode)
                    .HasName("UC_VOUCHERTYPE_VOUCHERCODE")
                    .IsUnique();

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                //entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.VoucherCode)
                    .IsRequired()
                    .HasMaxLength(2);

                entity.Property(e => e.VoucherName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(w => w.OrganizationNavigation)
                   .WithMany(o => o.VoucherTypes)
                   .HasForeignKey(w => w.Organization)
                   .HasConstraintName("FK__Organizat__VoucherType__5B23C598");

                entity.HasOne(ar => ar.UserNavigation)
                   .WithMany(u => u.VoucherTypes)
                   .HasForeignKey(ar => ar.User)
                   .HasConstraintName("FK__AppUser__VoucherType__5B23C598");
            });



            //MANY TO MANY RELATIONSHIP RULES-----------------------------------------------------------------------


            modelBuilder.Entity<UsersOrgs>(entity =>
            {
                entity.HasIndex(e => new { e.User, e.Organization})
                    .HasName("UO_UC")
                    .IsUnique();

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Organization)
                    .IsRequired();

                entity.HasOne(e => e.OrganizationNavigation)
                    .WithMany(o => o.Users)
                    .HasForeignKey(e => e.Organization);

                entity.HasOne(e => e.UserNavigation)
                    .WithMany(au => au.Organizations)
                    .HasForeignKey(e => e.User);

            });



            //IDENTITY RULES--------------------------------------------------------------------------------------------

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(e => e.UserName)
                    .HasMaxLength(150);

                //entity.Property(e => e.Organization)
                //    .IsRequired();

                //entity.HasOne(a => a.OrganizationNavigation)
                //    .WithMany(o => o.Users)
                //    .HasForeignKey(a => a.Organization)
                //    .HasConstraintName("FK__Org__AppUser__52B859C3");
            });
        }
    }
}
