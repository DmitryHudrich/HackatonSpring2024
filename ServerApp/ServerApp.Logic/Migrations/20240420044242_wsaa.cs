using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace ServerApp.Logic.Migrations
{
    /// <inheritdoc />
    public partial class wsaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Point>(
                name: "SearchGeoposition",
                table: "Users",
                type: "geometry (point)",
                nullable: true,
                oldClrType: typeof(Point),
                oldType: "geography",
                oldNullable: true);

            migrationBuilder.AlterColumn<Point>(
                name: "Geoposition",
                table: "Activities",
                type: "geometry (point)",
                nullable: false,
                oldClrType: typeof(Point),
                oldType: "geography");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Point>(
                name: "SearchGeoposition",
                table: "Users",
                type: "geography",
                nullable: true,
                oldClrType: typeof(Point),
                oldType: "geometry (point)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Point>(
                name: "Geoposition",
                table: "Activities",
                type: "geography",
                nullable: false,
                oldClrType: typeof(Point),
                oldType: "geometry (point)");
        }
    }
}
