using Microsoft.EntityFrameworkCore.Migrations;

namespace iHotel.Repository.Migrations
{
    public partial class WriteActLogTable_Field_ActivityBy_ChangedTo_User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ActivityBy",
                table: "WriteActivityLogs",
                newName: "User");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "WriteActivityLogs",
                nullable: false,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldNullable: true,
                oldDefaultValueSql: "((1))");

            migrationBuilder.AddColumn<string>(
                name: "UserNavigationId",
                table: "WriteActivityLogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WriteActivityLogs_UserNavigationId",
                table: "WriteActivityLogs",
                column: "UserNavigationId");

            migrationBuilder.AddForeignKey(
                name: "FK_WriteActivityLogs_AspNetUsers_UserNavigationId",
                table: "WriteActivityLogs",
                column: "UserNavigationId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WriteActivityLogs_AspNetUsers_UserNavigationId",
                table: "WriteActivityLogs");

            migrationBuilder.DropIndex(
                name: "IX_WriteActivityLogs_UserNavigationId",
                table: "WriteActivityLogs");

            migrationBuilder.DropColumn(
                name: "UserNavigationId",
                table: "WriteActivityLogs");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "WriteActivityLogs",
                newName: "ActivityBy");

            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "WriteActivityLogs",
                nullable: true,
                defaultValueSql: "((1))",
                oldClrType: typeof(bool),
                oldDefaultValueSql: "((1))");
        }
    }
}
