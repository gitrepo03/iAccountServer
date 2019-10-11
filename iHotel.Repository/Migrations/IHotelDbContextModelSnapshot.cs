﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iHotel.Repository.Extensions.DbExtension;

namespace iHotel.Repository.Migrations
{
    [DbContext(typeof(IHotelDbContext))]
    partial class IHotelDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("iHotel.Entity.Accounting.AccountRef", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudId");

                    b.Property<string>("Bs")
                        .IsRequired()
                        .HasColumnName("BS")
                        .HasMaxLength(1);

                    b.Property<string>("Fiscal")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<int>("GroupCode");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<bool>("HasSubLedger");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDefaultGroup");

                    b.Property<int>("NodeLevel");

                    b.Property<int?>("Organization");

                    b.Property<int>("Parent");

                    b.Property<string>("Pl")
                        .IsRequired()
                        .HasColumnName("PL")
                        .HasMaxLength(1);

                    b.Property<string>("Tb")
                        .IsRequired()
                        .HasColumnName("TB")
                        .HasMaxLength(1);

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.HasIndex("Organization");

                    b.HasIndex("Parent");

                    b.HasIndex("User");

                    b.HasIndex("Fiscal", "GroupCode")
                        .IsUnique()
                        .HasName("ACCOUNTREF_FISCALYEAR_GROUPCODE");

                    b.ToTable("AccountRef");
                });

            modelBuilder.Entity("iHotel.Entity.Accounting.FiscalYear", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudId");

                    b.Property<DateTime>("DateBeginEnglish")
                        .HasColumnType("datetime");

                    b.Property<string>("DateBeginNepali")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<DateTime>("DateEndEnglish")
                        .HasColumnType("datetime");

                    b.Property<string>("DateEndNepali")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("Fiscal")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<bool>("IsActive");

                    b.Property<int?>("Organization");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.HasIndex("Organization");

                    b.HasIndex("User");

                    b.HasIndex("Fiscal", "Organization")
                        .IsUnique()
                        .HasName("UC_FISCALYEAR_ORGANIZATION")
                        .HasFilter("[Organization] IS NOT NULL");

                    b.ToTable("FiscalYears");
                });

            modelBuilder.Entity("iHotel.Entity.Accounting.LedgerRef", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudId");

                    b.Property<string>("BalanceType")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("FiscalYear")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<int>("GroupCode");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsDefault");

                    b.Property<int>("LedgerCode");

                    b.Property<string>("LedgerName")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int?>("Organization");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.HasIndex("Organization");

                    b.HasIndex("User");

                    b.HasIndex("FiscalYear", "GroupCode");

                    b.HasIndex("FiscalYear", "LedgerCode", "GroupCode")
                        .IsUnique()
                        .HasName("LEDGERREF_FISCALYEAR_LEDGERCODE_GROUPCODE");

                    b.ToTable("LedgerRefs");
                });

            modelBuilder.Entity("iHotel.Entity.Accounting.VoucherDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("money");

                    b.Property<string>("AudId");

                    b.Property<string>("BalanceType")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<string>("FiscalYear")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<bool>("IsActive");

                    b.Property<int>("LedgerCode");

                    b.Property<int?>("Organization");

                    b.Property<int>("SerialNumber");

                    b.Property<string>("User");

                    b.Property<string>("VoucherCode")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<int>("VoucherNumber");

                    b.HasKey("Id");

                    b.HasIndex("LedgerCode");

                    b.HasIndex("Organization");

                    b.HasIndex("User");

                    b.HasIndex("FiscalYear", "VoucherNumber", "VoucherCode", "SerialNumber", "LedgerCode")
                        .IsUnique()
                        .HasName("UC_Voucherdetail_Fiscalyear_vouchernumber_vouchertype_serialnumber_ledgercode");

                    b.ToTable("VoucherDetails");
                });

            modelBuilder.Entity("iHotel.Entity.Accounting.VoucherMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudId");

                    b.Property<DateTime>("DateEnglish")
                        .HasColumnType("datetime");

                    b.Property<string>("DateNepali")
                        .IsRequired()
                        .HasMaxLength(10);

                    b.Property<string>("FiscalYear")
                        .IsRequired()
                        .HasMaxLength(9);

                    b.Property<string>("InWords")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.Property<bool>("IsActive");

                    b.Property<int?>("Organization");

                    b.Property<decimal>("Total")
                        .HasColumnType("money");

                    b.Property<string>("User");

                    b.Property<int>("UserCode");

                    b.Property<string>("VoucherCode")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<int>("VoucherNumber");

                    b.HasKey("Id");

                    b.HasIndex("Organization");

                    b.HasIndex("User");

                    b.HasIndex("VoucherCode");

                    b.HasIndex("FiscalYear", "VoucherNumber", "VoucherCode")
                        .IsUnique()
                        .HasName("VM_UC");

                    b.ToTable("VoucherMasters");
                });

            modelBuilder.Entity("iHotel.Entity.Accounting.VoucherType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudId");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("Organization");

                    b.Property<string>("User");

                    b.Property<string>("VoucherCode")
                        .IsRequired()
                        .HasMaxLength(2);

                    b.Property<string>("VoucherName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Organization");

                    b.HasIndex("User");

                    b.HasIndex("VoucherCode")
                        .IsUnique()
                        .HasName("UC_VOUCHERTYPE_VOUCHERCODE");

                    b.ToTable("VoucherTypes");
                });

            modelBuilder.Entity("iHotel.Entity.Admin.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(500);

                    b.Property<string>("ContactNo")
                        .HasMaxLength(100);

                    b.Property<string>("Email")
                        .HasMaxLength(100);

                    b.Property<DateTime?>("EstablishedDateAd")
                        .HasColumnName("EstablishedDate_AD")
                        .HasColumnType("date");

                    b.Property<string>("EstablishedDateBs")
                        .HasColumnName("EstablishedDate_BS")
                        .HasMaxLength(10);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsActive")
                        .HasDefaultValueSql("((1))");

                    b.Property<string>("Logo")
                        .HasMaxLength(200);

                    b.Property<string>("OrgCode")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("OrgName")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("OrgNameNp")
                        .HasColumnName("OrgName_Np")
                        .HasMaxLength(500);

                    b.Property<string>("PanNo")
                        .HasMaxLength(50);

                    b.Property<string>("Quote")
                        .HasMaxLength(1000);

                    b.Property<string>("Website")
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.HasIndex("OrgCode")
                        .IsUnique();

                    b.ToTable("Organizations");
                });

            modelBuilder.Entity("iHotel.Entity.Admin.OrganizationImagePath", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudId");

                    b.Property<string>("ImgPath")
                        .HasMaxLength(100);

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsActive")
                        .HasDefaultValueSql("((1))");

                    b.Property<int?>("Organization")
                        .IsRequired();

                    b.Property<string>("PathTitle")
                        .HasMaxLength(50);

                    b.Property<string>("User");

                    b.Property<string>("UserNavigationId");

                    b.HasKey("Id");

                    b.HasIndex("AudId")
                        .IsUnique()
                        .HasFilter("[AudId] IS NOT NULL");

                    b.HasIndex("Organization");

                    b.HasIndex("UserNavigationId");

                    b.ToTable("OrganizationImagePaths");
                });

            modelBuilder.Entity("iHotel.Entity.Admin.UsersOrgs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AudId");

                    b.Property<bool>("IsActive");

                    b.Property<int?>("Organization")
                        .IsRequired();

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.HasIndex("Organization");

                    b.HasIndex("User", "Organization")
                        .IsUnique()
                        .HasName("UO_UC")
                        .HasFilter("[User] IS NOT NULL AND [Organization] IS NOT NULL");

                    b.ToTable("UsersOrgs");
                });

            modelBuilder.Entity("iHotel.Entity.Common.ChangeLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ChangedBy")
                        .HasMaxLength(100);

                    b.Property<string>("ColumnName")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("LogDateAD")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("LogDate_AD")
                        .HasColumnType("date")
                        .HasDefaultValueSql("CONVERT(date, getdate())");

                    b.Property<string>("LogDateBS")
                        .HasColumnName("LogDate_BS")
                        .HasMaxLength(10);

                    b.Property<TimeSpan?>("LogTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("time")
                        .HasDefaultValueSql("CONVERT(time, getdate())");

                    b.Property<string>("NewValue");

                    b.Property<string>("OldValue");

                    b.Property<int>("Organization");

                    b.Property<int>("RowId");

                    b.Property<string>("TableName")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Organization");

                    b.ToTable("ChangeLogs");
                });

            modelBuilder.Entity("iHotel.Entity.Common.WriteActivityLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivityBy")
                        .HasMaxLength(150);

                    b.Property<string>("ActivityTable")
                        .HasMaxLength(50);

                    b.Property<TimeSpan?>("ActivityTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("time")
                        .HasDefaultValueSql("CONVERT(time, getdate())");

                    b.Property<bool>("ActivityType");

                    b.Property<string>("AudId");

                    b.Property<DateTime?>("DateAd")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Date_AD")
                        .HasColumnType("date")
                        .HasDefaultValueSql("CONVERT(date, getdate())");

                    b.Property<string>("DateBs")
                        .HasColumnName("Date_BS")
                        .HasMaxLength(10);

                    b.Property<bool?>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsActive")
                        .HasDefaultValueSql("((1))");

                    b.Property<int>("Organization");

                    b.HasKey("Id");

                    b.HasIndex("Organization");

                    b.ToTable("WriteActivityLogs");
                });

            modelBuilder.Entity("iHotel.Entity.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FullName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("iHotel.Entity.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("iHotel.Entity.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iHotel.Entity.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("iHotel.Entity.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iHotel.Entity.Accounting.AccountRef", b =>
                {
                    b.HasOne("iHotel.Entity.Accounting.FiscalYear", "FiscalNavigation")
                        .WithMany("AccountRef")
                        .HasForeignKey("Fiscal")
                        .HasConstraintName("FK_AccountRef_Fiscal")
                        .HasPrincipalKey("Fiscal");

                    b.HasOne("iHotel.Entity.Admin.Organization", "OrganizationNavigation")
                        .WithMany("AccountRefs")
                        .HasForeignKey("Organization")
                        .HasConstraintName("FK__Org__AccRef__5B23C598");

                    b.HasOne("iHotel.Entity.Accounting.AccountRef", "AccountRefNavigation")
                        .WithMany("AccountRefs")
                        .HasForeignKey("Parent")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("iHotel.Entity.Identity.ApplicationUser", "UserNavigation")
                        .WithMany("AccountRefs")
                        .HasForeignKey("User")
                        .HasConstraintName("FK__AppUser__AccRef__5B23C598");
                });

            modelBuilder.Entity("iHotel.Entity.Accounting.FiscalYear", b =>
                {
                    b.HasOne("iHotel.Entity.Admin.Organization", "OrganizationNavigation")
                        .WithMany("FiscalYears")
                        .HasForeignKey("Organization")
                        .HasConstraintName("FK__Organizat__Fiscal__5B23C598");

                    b.HasOne("iHotel.Entity.Identity.ApplicationUser", "UserNavigation")
                        .WithMany("Fiscals")
                        .HasForeignKey("User")
                        .HasConstraintName("FK__AppUser__Fiscal__5B23C598");
                });

            modelBuilder.Entity("iHotel.Entity.Accounting.LedgerRef", b =>
                {
                    b.HasOne("iHotel.Entity.Admin.Organization", "OrganizationNavigation")
                        .WithMany("LedgerRefs")
                        .HasForeignKey("Organization")
                        .HasConstraintName("FK__Organizat__LedgerRef__5B23C598");

                    b.HasOne("iHotel.Entity.Identity.ApplicationUser", "UserNavigation")
                        .WithMany("LedgerRefs")
                        .HasForeignKey("User")
                        .HasConstraintName("FK__AppUser__LedgerRef__5B23C598");

                    b.HasOne("iHotel.Entity.Accounting.AccountRef", "AccountRef")
                        .WithMany("LedgerRefs")
                        .HasForeignKey("FiscalYear", "GroupCode")
                        .HasConstraintName("FK_LedgerRef_AccountRef")
                        .HasPrincipalKey("Fiscal", "GroupCode");
                });

            modelBuilder.Entity("iHotel.Entity.Accounting.VoucherDetail", b =>
                {
                    b.HasOne("iHotel.Entity.Accounting.LedgerRef", "LedgerCodeNavigation")
                        .WithMany("VoucherDetails")
                        .HasForeignKey("LedgerCode")
                        .HasConstraintName("FK_VoucherDetail_LedgerRef");

                    b.HasOne("iHotel.Entity.Admin.Organization", "OrganizationNavigation")
                        .WithMany("VoucherDetails")
                        .HasForeignKey("Organization")
                        .HasConstraintName("FK__Organizat__VoucherDetail__5B23C598");

                    b.HasOne("iHotel.Entity.Identity.ApplicationUser", "UserNavigation")
                        .WithMany("VoucherDetails")
                        .HasForeignKey("User")
                        .HasConstraintName("FK__AppUser__VoucherDetail__5B23C598");

                    b.HasOne("iHotel.Entity.Accounting.VoucherMaster", "VoucherMasters")
                        .WithMany("VoucherDetails")
                        .HasForeignKey("FiscalYear", "VoucherNumber", "VoucherCode")
                        .HasConstraintName("FK_VoucherDetail_VoucherMaster")
                        .HasPrincipalKey("FiscalYear", "VoucherNumber", "VoucherCode");
                });

            modelBuilder.Entity("iHotel.Entity.Accounting.VoucherMaster", b =>
                {
                    b.HasOne("iHotel.Entity.Accounting.FiscalYear", "FiscalYearNavigation")
                        .WithMany("VoucherMasters")
                        .HasForeignKey("FiscalYear")
                        .HasConstraintName("FK_VoucherMaster_Fiscal")
                        .HasPrincipalKey("Fiscal");

                    b.HasOne("iHotel.Entity.Admin.Organization", "OrganizationNavigation")
                        .WithMany("VoucherMasters")
                        .HasForeignKey("Organization")
                        .HasConstraintName("FK__Organizat__VoucherMaster__5B23C598");

                    b.HasOne("iHotel.Entity.Identity.ApplicationUser", "UserNavigation")
                        .WithMany("VoucherMasters")
                        .HasForeignKey("User")
                        .HasConstraintName("FK__AppUser__VoucherMaster__5B23C598");

                    b.HasOne("iHotel.Entity.Accounting.VoucherType", "VoucherCodeNavigation")
                        .WithMany("VoucherMasters")
                        .HasForeignKey("VoucherCode")
                        .HasConstraintName("FK_VoucherMaster_VoucherType")
                        .HasPrincipalKey("VoucherCode");
                });

            modelBuilder.Entity("iHotel.Entity.Accounting.VoucherType", b =>
                {
                    b.HasOne("iHotel.Entity.Admin.Organization", "OrganizationNavigation")
                        .WithMany("VoucherTypes")
                        .HasForeignKey("Organization")
                        .HasConstraintName("FK__Organizat__VoucherType__5B23C598");

                    b.HasOne("iHotel.Entity.Identity.ApplicationUser", "UserNavigation")
                        .WithMany("VoucherTypes")
                        .HasForeignKey("User")
                        .HasConstraintName("FK__AppUser__VoucherType__5B23C598");
                });

            modelBuilder.Entity("iHotel.Entity.Admin.OrganizationImagePath", b =>
                {
                    b.HasOne("iHotel.Entity.Admin.Organization", "OrganizationNavigation")
                        .WithMany("OrganizationImagePaths")
                        .HasForeignKey("Organization")
                        .HasConstraintName("FK__Organizat__organ__52593CB8")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iHotel.Entity.Identity.ApplicationUser", "UserNavigation")
                        .WithMany()
                        .HasForeignKey("UserNavigationId");
                });

            modelBuilder.Entity("iHotel.Entity.Admin.UsersOrgs", b =>
                {
                    b.HasOne("iHotel.Entity.Admin.Organization", "OrganizationNavigation")
                        .WithMany("Users")
                        .HasForeignKey("Organization")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("iHotel.Entity.Identity.ApplicationUser", "UserNavigation")
                        .WithMany("Organizations")
                        .HasForeignKey("User");
                });

            modelBuilder.Entity("iHotel.Entity.Common.ChangeLog", b =>
                {
                    b.HasOne("iHotel.Entity.Admin.Organization", "OrganizationNavigation")
                        .WithMany("ChangeLogs")
                        .HasForeignKey("Organization")
                        .HasConstraintName("FK__Organizat__ChangeLog__5B23C598")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("iHotel.Entity.Common.WriteActivityLog", b =>
                {
                    b.HasOne("iHotel.Entity.Admin.Organization", "OrganizationNavigation")
                        .WithMany("WriteActivityLogs")
                        .HasForeignKey("Organization")
                        .HasConstraintName("FK__Organizat__WriteActLog__5B23C598")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
