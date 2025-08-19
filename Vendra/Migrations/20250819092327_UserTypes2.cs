using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vendra.Migrations
{
    /// <inheritdoc />
    public partial class UserTypes2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grup",
                table: "UserTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grup",
                table: "UserTypes");
        }
    }
}
