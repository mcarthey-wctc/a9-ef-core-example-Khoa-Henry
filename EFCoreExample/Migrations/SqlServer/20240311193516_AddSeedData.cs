#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCoreExample.Migrations.SqlServer;

/// <inheritdoc />
public partial class AddSeedData : Migration
{
    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            "Classrooms",
            "ClassroomId",
            new object[] {1, 2, 3});

        migrationBuilder.DeleteData(
            "Students",
            "StudentId",
            new object[] {1, 2, 3, 4});
    }

    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.InsertData(
            "Classrooms",
            new[] {"ClassroomId", "Name"},
            new object[,]
            {
                {1, "Biology 101"},
                {2, "English Literature 202"},
                {3, "Computer Science 303"}
            });

        migrationBuilder.InsertData(
            "Students",
            new[] {"StudentId", "Name"},
            new object[,]
            {
                {1, "John Doe"},
                {2, "Jane Smith"},
                {3, "Robert Johnson"},
                {4, "Emily Davis"}
            });
    }
}
