using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ServerApp.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class vovaas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserInfo_Name",
                table: "Users",
                newName: "UserInfo_LastName");

            migrationBuilder.AddColumn<string>(
                name: "UserInfo_FirstName",
                table: "Users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserInfo_FirstName",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserInfo_LastName",
                table: "Users",
                newName: "UserInfo_Name");
        }
    }
}
