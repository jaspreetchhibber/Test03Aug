using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestApp03Aug.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Fixed_CreatedDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatdDate",
                table: "Employees",
                newName: "CreatedDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Employees",
                newName: "CreatdDate");
        }
    }
}
