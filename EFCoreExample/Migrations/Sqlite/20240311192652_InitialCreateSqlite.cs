#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreExample.Migrations.Sqlite;

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
                ClassroomId = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>("TEXT", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Classrooms", x => x.ClassroomId); });

        migrationBuilder.CreateTable(
            "Students",
            table => new
            {
                StudentId = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Name = table.Column<string>("TEXT", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_Students", x => x.StudentId); });

        migrationBuilder.CreateTable(
            "ClassroomStudent",
            table => new
            {
                ClassroomsClassroomId = table.Column<int>("INTEGER", nullable: false),
                StudentsStudentId = table.Column<int>("INTEGER", nullable: false)
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
