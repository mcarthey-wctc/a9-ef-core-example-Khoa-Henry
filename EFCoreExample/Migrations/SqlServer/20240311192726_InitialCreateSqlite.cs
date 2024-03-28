#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreExample.Migrations.SqlServer;

/// <inheritdoc />
public partial class InitialCreateSqlite : Migration
{
    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "ClassroomStudent");

        migrationBuilder.DropTable(
            "Classrooms");

        migrationBuilder.DropTable(
            "Students");
    }

    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "Classrooms",
            table => new
            {
                ClassroomId = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>("nvarchar(max)", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Classrooms", x => x.ClassroomId); });

        migrationBuilder.CreateTable(
            "Students",
            table => new
            {
                StudentId = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>("nvarchar(max)", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Students", x => x.StudentId); });

        migrationBuilder.CreateTable(
            "ClassroomStudent",
            table => new
            {
                ClassroomsClassroomId = table.Column<int>("int", nullable: false),
                StudentsStudentId = table.Column<int>("int", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClassroomStudent", x => new {x.ClassroomsClassroomId, x.StudentsStudentId});
                table.ForeignKey(
                    "FK_ClassroomStudent_Classrooms_ClassroomsClassroomId",
                    x => x.ClassroomsClassroomId,
                    "Classrooms",
                    "ClassroomId",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    "FK_ClassroomStudent_Students_StudentsStudentId",
                    x => x.StudentsStudentId,
                    "Students",
                    "StudentId",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_ClassroomStudent_StudentsStudentId",
            "ClassroomStudent",
            "StudentsStudentId");
    }
}
