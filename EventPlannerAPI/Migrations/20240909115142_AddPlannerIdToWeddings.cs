using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPlannerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddPlannerIdToWeddings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlannerId",
                table: "Weddings",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlannerId",
                table: "Weddings");
        }
    }
}
