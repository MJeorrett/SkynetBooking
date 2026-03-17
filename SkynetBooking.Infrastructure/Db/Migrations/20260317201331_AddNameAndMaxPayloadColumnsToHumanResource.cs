using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkynetBooking.Infrastructure.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddNameAndMaxPayloadColumnsToHumanResource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxPayloadKg",
                table: "HumanResources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NonUniqueIdentifier",
                table: "HumanResources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxPayloadKg",
                table: "HumanResources");

            migrationBuilder.DropColumn(
                name: "NonUniqueIdentifier",
                table: "HumanResources");
        }
    }
}
