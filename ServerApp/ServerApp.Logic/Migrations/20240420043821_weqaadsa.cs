using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

#nullable disable

namespace ServerApp.Logic.Migrations
{
    /// <inheritdoc />
    public partial class weqaadsa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Point>(
                name: "SearchGeoposition",
                table: "Users",
                type: "geography",
                nullable: true,
                oldClrType: typeof(Point),
                oldType: "geometry",
                oldNullable: true);

            migrationBuilder.AlterColumn<Point>(
                name: "Geoposition",
                table: "Activities",
                type: "geography",
                nullable: false,
                oldClrType: typeof(Point),
                oldType: "geometry");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Point>(
                name: "SearchGeoposition",
                table: "Users",
                type: "geometry",
                nullable: true,
                oldClrType: typeof(Point),
                oldType: "geography",
                oldNullable: true);

            migrationBuilder.AlterColumn<Point>(
                name: "Geoposition",
                table: "Activities",
                type: "geometry",
                nullable: false,
                oldClrType: typeof(Point),
                oldType: "geography");
        }
    }
}
