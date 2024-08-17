using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITISystem.Migrations
{
    /// <inheritdoc />
    public partial class mTmRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Courses_coursesId",
                table: "CourseDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDepartment",
                table: "CourseDepartment");

            migrationBuilder.DropIndex(
                name: "IX_CourseDepartment_coursesId",
                table: "CourseDepartment");

            migrationBuilder.RenameColumn(
                name: "coursesId",
                table: "CourseDepartment",
                newName: "CoursesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDepartment",
                table: "CourseDepartment",
                columns: new[] { "CoursesId", "DepartmentsDeptId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_DepartmentsDeptId",
                table: "CourseDepartment",
                column: "DepartmentsDeptId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Courses_CoursesId",
                table: "CourseDepartment",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Courses_CoursesId",
                table: "CourseDepartment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CourseDepartment",
                table: "CourseDepartment");

            migrationBuilder.DropIndex(
                name: "IX_CourseDepartment_DepartmentsDeptId",
                table: "CourseDepartment");

            migrationBuilder.RenameColumn(
                name: "CoursesId",
                table: "CourseDepartment",
                newName: "coursesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CourseDepartment",
                table: "CourseDepartment",
                columns: new[] { "DepartmentsDeptId", "coursesId" });

            migrationBuilder.CreateIndex(
                name: "IX_CourseDepartment_coursesId",
                table: "CourseDepartment",
                column: "coursesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Courses_coursesId",
                table: "CourseDepartment",
                column: "coursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
