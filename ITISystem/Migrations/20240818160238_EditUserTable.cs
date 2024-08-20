using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITISystem.Migrations
{
    /// <inheritdoc />
    public partial class EditUserTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAgree",
                table: "Users");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAgree",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
