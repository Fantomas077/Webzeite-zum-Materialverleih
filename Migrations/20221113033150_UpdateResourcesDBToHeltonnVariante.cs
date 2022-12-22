using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingPlatform.Migrations
{
    /// <inheritdoc />
    public partial class UpdateResourcesDBToHeltonnVariante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Availability",
                table: "Resources");

            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ImageName",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Availability",
                table: "Resources",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
