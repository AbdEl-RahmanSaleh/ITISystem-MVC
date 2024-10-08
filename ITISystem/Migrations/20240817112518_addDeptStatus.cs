﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITISystem.Migrations
{
    /// <inheritdoc />
    public partial class addDeptStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Departments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Departments");
        }
    }
}
