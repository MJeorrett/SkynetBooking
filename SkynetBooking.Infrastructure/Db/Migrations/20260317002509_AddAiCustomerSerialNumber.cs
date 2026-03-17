using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SkynetBooking.Infrastructure.Db.Migrations
{
    /// <inheritdoc />
    public partial class AddAiCustomerSerialNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SerialNumber",
                table: "AiCustomers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AiCustomers_SerialNumber",
                table: "AiCustomers",
                column: "SerialNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AiCustomers_SerialNumber",
                table: "AiCustomers");

            migrationBuilder.DropColumn(
                name: "SerialNumber",
                table: "AiCustomers");
        }
    }
}
