using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookingPlatform.Migrations
{
    /// <inheritdoc />
    public partial class addImageNameInResources : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageName",
                table: "Resources",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageName",
                table: "Resources");
        }
    }
}
