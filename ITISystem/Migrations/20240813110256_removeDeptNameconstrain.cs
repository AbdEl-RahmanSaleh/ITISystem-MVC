using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITISystem.Migrations
{
    /// <inheritdoc />
    public partial class removeDeptNameconstrain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Departments_DeptName",
                table: "Departments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Departments_DeptName",
                table: "Departments",
                column: "DeptName",
                unique: true);
        }
    }
}
