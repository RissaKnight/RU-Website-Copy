using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RU_ASP_Semester_Project.Migrations
{
    /// <inheritdoc />
    public partial class MakeStudentProgramOptional : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Programs_ProgramId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "ProgramId",
                table: "Students",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Programs_ProgramId",
                table: "Students",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "ProgramId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Programs_ProgramId",
                table: "Students");

            migrationBuilder.AlterColumn<int>(
                name: "ProgramId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Programs_ProgramId",
                table: "Students",
                column: "ProgramId",
                principalTable: "Programs",
                principalColumn: "ProgramId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
