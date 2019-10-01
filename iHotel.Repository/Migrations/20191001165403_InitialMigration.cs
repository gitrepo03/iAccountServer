using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace iHotel.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 150, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    OrgName = table.Column<string>(unicode: false, maxLength: 200, nullable: true),
                    OrgName_Np = table.Column<string>(maxLength: 500, nullable: true),
                    PanNo = table.Column<string>(maxLength: 50, nullable: true),
                    Address = table.Column<string>(maxLength: 500, nullable: true),
                    ContactNo = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    Website = table.Column<string>(maxLength: 250, nullable: true),
                    EstablishedDate_AD = table.Column<DateTime>(type: "date", nullable: true),
                    EstablishedDate_BS = table.Column<string>(maxLength: 10, nullable: true),
                    Logo = table.Column<string>(maxLength: 200, nullable: true),
                    Quote = table.Column<string>(maxLength: 1000, nullable: true),
                    OrgCode = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChangeLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Organization = table.Column<int>(nullable: false),
                    TableName = table.Column<string>(maxLength: 50, nullable: true),
                    ColumnName = table.Column<string>(maxLength: 50, nullable: true),
                    RowId = table.Column<int>(nullable: false),
                    LogDate_AD = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "CONVERT(date, getdate())"),
                    LogDate_BS = table.Column<string>(maxLength: 10, nullable: true),
                    LogTime = table.Column<TimeSpan>(type: "time", nullable: true, defaultValueSql: "CONVERT(time, getdate())"),
                    OldValue = table.Column<string>(nullable: true),
                    NewValue = table.Column<string>(nullable: true),
                    ChangedBy = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Organizat__ChangeLog__5B23C598",
                        column: x => x.Organization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FiscalYears",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AudId = table.Column<string>(nullable: true),
                    Organization = table.Column<int>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Fiscal = table.Column<string>(maxLength: 9, nullable: false),
                    DateBeginNepali = table.Column<string>(maxLength: 10, nullable: false),
                    DateEndNepali = table.Column<string>(maxLength: 10, nullable: false),
                    DateBeginEnglish = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateEndEnglish = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiscalYears", x => x.Id);
                    table.UniqueConstraint("AK_FiscalYears_Fiscal", x => x.Fiscal);
                    table.ForeignKey(
                        name: "FK__Organizat__Fiscal__5B23C598",
                        column: x => x.Organization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AppUser__Fiscal__5B23C598",
                        column: x => x.User,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationImagePaths",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false, defaultValueSql: "((1))"),
                    AudId = table.Column<string>(nullable: true),
                    Organization = table.Column<int>(nullable: false),
                    User = table.Column<string>(nullable: true),
                    UserNavigationId = table.Column<string>(nullable: true),
                    PathTitle = table.Column<string>(maxLength: 50, nullable: true),
                    ImgPath = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationImagePaths", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Organizat__organ__52593CB8",
                        column: x => x.Organization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrganizationImagePaths_AspNetUsers_UserNavigationId",
                        column: x => x.UserNavigationId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersOrgs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsActive = table.Column<bool>(nullable: false),
                    AudId = table.Column<string>(nullable: true),
                    Organization = table.Column<int>(nullable: false),
                    User = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersOrgs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersOrgs_Organizations_Organization",
                        column: x => x.Organization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersOrgs_AspNetUsers_User",
                        column: x => x.User,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoucherTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AudId = table.Column<string>(nullable: true),
                    Organization = table.Column<int>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    VoucherCode = table.Column<string>(maxLength: 2, nullable: false),
                    VoucherName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherTypes", x => x.Id);
                    table.UniqueConstraint("AK_VoucherTypes_VoucherCode", x => x.VoucherCode);
                    table.ForeignKey(
                        name: "FK__Organizat__VoucherType__5B23C598",
                        column: x => x.Organization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AppUser__VoucherType__5B23C598",
                        column: x => x.User,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WriteActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Organization = table.Column<int>(nullable: false),
                    ActivityType = table.Column<bool>(nullable: false),
                    ActivityTable = table.Column<string>(maxLength: 50, nullable: true),
                    AudId = table.Column<string>(nullable: true),
                    ActivityBy = table.Column<string>(maxLength: 150, nullable: true),
                    Date_AD = table.Column<DateTime>(type: "date", nullable: true, defaultValueSql: "CONVERT(date, getdate())"),
                    Date_BS = table.Column<string>(maxLength: 10, nullable: true),
                    ActivityTime = table.Column<TimeSpan>(type: "time", nullable: true, defaultValueSql: "CONVERT(time, getdate())"),
                    IsActive = table.Column<bool>(nullable: true, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteActivityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Organizat__WriteActLog__5B23C598",
                        column: x => x.Organization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountRef",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AudId = table.Column<string>(nullable: true),
                    Organization = table.Column<int>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    Fiscal = table.Column<string>(maxLength: 9, nullable: false),
                    GroupCode = table.Column<int>(nullable: false),
                    GroupName = table.Column<string>(maxLength: 250, nullable: false),
                    NodeLevel = table.Column<int>(nullable: false),
                    Parent = table.Column<int>(nullable: false),
                    TB = table.Column<string>(maxLength: 1, nullable: false),
                    PL = table.Column<string>(maxLength: 1, nullable: false),
                    BS = table.Column<string>(maxLength: 1, nullable: false),
                    IsDefaultGroup = table.Column<bool>(nullable: false),
                    HasSubLedger = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountRef", x => x.Id);
                    table.UniqueConstraint("AK_AccountRef_Fiscal_GroupCode", x => new { x.Fiscal, x.GroupCode });
                    table.ForeignKey(
                        name: "FK_AccountRef_Fiscal",
                        column: x => x.Fiscal,
                        principalTable: "FiscalYears",
                        principalColumn: "Fiscal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Org__AccRef__5B23C598",
                        column: x => x.Organization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AppUser__AccRef__5B23C598",
                        column: x => x.User,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoucherMasters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AudId = table.Column<string>(nullable: true),
                    Organization = table.Column<int>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    FiscalYear = table.Column<string>(maxLength: 9, nullable: false),
                    VoucherNumber = table.Column<int>(nullable: false),
                    VoucherCode = table.Column<string>(maxLength: 2, nullable: false),
                    DateEnglish = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateNepali = table.Column<string>(maxLength: 10, nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: false),
                    InWords = table.Column<string>(maxLength: 500, nullable: false),
                    UserCode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherMasters", x => x.Id);
                    table.UniqueConstraint("AK_VoucherMasters_FiscalYear_VoucherNumber_VoucherCode", x => new { x.FiscalYear, x.VoucherNumber, x.VoucherCode });
                    table.ForeignKey(
                        name: "FK_VoucherMaster_Fiscal",
                        column: x => x.FiscalYear,
                        principalTable: "FiscalYears",
                        principalColumn: "Fiscal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Organizat__VoucherMaster__5B23C598",
                        column: x => x.Organization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AppUser__VoucherMaster__5B23C598",
                        column: x => x.User,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoucherMaster_VoucherType",
                        column: x => x.VoucherCode,
                        principalTable: "VoucherTypes",
                        principalColumn: "VoucherCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LedgerRefs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AudId = table.Column<string>(nullable: true),
                    Organization = table.Column<int>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    FiscalYear = table.Column<string>(maxLength: 9, nullable: false),
                    GroupCode = table.Column<int>(nullable: false),
                    LedgerCode = table.Column<int>(nullable: false),
                    LedgerName = table.Column<string>(maxLength: 100, nullable: false),
                    IsDefault = table.Column<bool>(nullable: false),
                    BalanceType = table.Column<string>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LedgerRefs", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Organizat__LedgerRef__5B23C598",
                        column: x => x.Organization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AppUser__LedgerRef__5B23C598",
                        column: x => x.User,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LedgerRef_AccountRef",
                        columns: x => new { x.FiscalYear, x.GroupCode },
                        principalTable: "AccountRef",
                        principalColumns: new[] { "Fiscal", "GroupCode" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoucherDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AudId = table.Column<string>(nullable: true),
                    Organization = table.Column<int>(nullable: true),
                    User = table.Column<string>(nullable: true),
                    FiscalYear = table.Column<string>(maxLength: 9, nullable: false),
                    VoucherNumber = table.Column<int>(nullable: false),
                    VoucherCode = table.Column<string>(maxLength: 2, nullable: false),
                    SerialNumber = table.Column<int>(nullable: false),
                    LedgerCode = table.Column<int>(nullable: false),
                    BalanceType = table.Column<string>(maxLength: 2, nullable: false),
                    Amount = table.Column<decimal>(type: "money", nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoucherDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoucherDetail_LedgerRef",
                        column: x => x.LedgerCode,
                        principalTable: "LedgerRefs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Organizat__VoucherDetail__5B23C598",
                        column: x => x.Organization,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__AppUser__VoucherDetail__5B23C598",
                        column: x => x.User,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoucherDetail_VoucherMaster",
                        columns: x => new { x.FiscalYear, x.VoucherNumber, x.VoucherCode },
                        principalTable: "VoucherMasters",
                        principalColumns: new[] { "FiscalYear", "VoucherNumber", "VoucherCode" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountRef_Organization",
                table: "AccountRef",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_AccountRef_User",
                table: "AccountRef",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "ACCOUNTREF_FISCALYEAR_GROUPCODE",
                table: "AccountRef",
                columns: new[] { "Fiscal", "GroupCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeLogs_Organization",
                table: "ChangeLogs",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalYears_Organization",
                table: "FiscalYears",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_FiscalYears_User",
                table: "FiscalYears",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "UC_FISCALYEAR_ORGANIZATION",
                table: "FiscalYears",
                columns: new[] { "Fiscal", "Organization" },
                unique: true,
                filter: "[Organization] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerRefs_Organization",
                table: "LedgerRefs",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerRefs_User",
                table: "LedgerRefs",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_LedgerRefs_FiscalYear_GroupCode",
                table: "LedgerRefs",
                columns: new[] { "FiscalYear", "GroupCode" });

            migrationBuilder.CreateIndex(
                name: "LEDGERREF_FISCALYEAR_LEDGERCODE_GROUPCODE",
                table: "LedgerRefs",
                columns: new[] { "FiscalYear", "LedgerCode", "GroupCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationImagePaths_AudId",
                table: "OrganizationImagePaths",
                column: "AudId",
                unique: true,
                filter: "[AudId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationImagePaths_Organization",
                table: "OrganizationImagePaths",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationImagePaths_UserNavigationId",
                table: "OrganizationImagePaths",
                column: "UserNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_OrgCode",
                table: "Organizations",
                column: "OrgCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersOrgs_Organization",
                table: "UsersOrgs",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "UO_UC",
                table: "UsersOrgs",
                columns: new[] { "User", "Organization" },
                unique: true,
                filter: "[User] IS NOT NULL AND [Organization] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetails_LedgerCode",
                table: "VoucherDetails",
                column: "LedgerCode");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetails_Organization",
                table: "VoucherDetails",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherDetails_User",
                table: "VoucherDetails",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "UC_Voucherdetail_Fiscalyear_vouchernumber_vouchertype_serialnumber_ledgercode",
                table: "VoucherDetails",
                columns: new[] { "FiscalYear", "VoucherNumber", "VoucherCode", "SerialNumber", "LedgerCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoucherMasters_Organization",
                table: "VoucherMasters",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherMasters_User",
                table: "VoucherMasters",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherMasters_VoucherCode",
                table: "VoucherMasters",
                column: "VoucherCode");

            migrationBuilder.CreateIndex(
                name: "VM_UC",
                table: "VoucherMasters",
                columns: new[] { "FiscalYear", "VoucherNumber", "VoucherCode" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VoucherTypes_Organization",
                table: "VoucherTypes",
                column: "Organization");

            migrationBuilder.CreateIndex(
                name: "IX_VoucherTypes_User",
                table: "VoucherTypes",
                column: "User");

            migrationBuilder.CreateIndex(
                name: "UC_VOUCHERTYPE_VOUCHERCODE",
                table: "VoucherTypes",
                column: "VoucherCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WriteActivityLogs_Organization",
                table: "WriteActivityLogs",
                column: "Organization");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChangeLogs");

            migrationBuilder.DropTable(
                name: "OrganizationImagePaths");

            migrationBuilder.DropTable(
                name: "UsersOrgs");

            migrationBuilder.DropTable(
                name: "VoucherDetails");

            migrationBuilder.DropTable(
                name: "WriteActivityLogs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "LedgerRefs");

            migrationBuilder.DropTable(
                name: "VoucherMasters");

            migrationBuilder.DropTable(
                name: "AccountRef");

            migrationBuilder.DropTable(
                name: "VoucherTypes");

            migrationBuilder.DropTable(
                name: "FiscalYears");

            migrationBuilder.DropTable(
                name: "Organizations");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
