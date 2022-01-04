using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    examDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Levels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Levels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    gender = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    bornDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    citizenCard = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    issueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    issuePlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    email = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    examinationId = table.Column<int>(type: "int", nullable: false),
                    levelId = table.Column<int>(type: "int", nullable: false),
                    amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Examinations_examinationId",
                        column: x => x.examinationId,
                        principalTable: "Examinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rooms_Levels_examinationId",
                        column: x => x.examinationId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RegistionForms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    examinationId = table.Column<int>(type: "int", nullable: false),
                    levelId = table.Column<int>(type: "int", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistionForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistionForms_Examinations_examinationId",
                        column: x => x.examinationId,
                        principalTable: "Examinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistionForms_Levels_levelId",
                        column: x => x.levelId,
                        principalTable: "Levels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RegistionForms_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Results",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    examRoom = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    SBD = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    pointListen = table.Column<float>(type: "real", nullable: true),
                    pointSpeak = table.Column<float>(type: "real", nullable: true),
                    pointWrite = table.Column<float>(type: "real", nullable: true),
                    pointRead = table.Column<float>(type: "real", nullable: true),
                    roomId = table.Column<int>(type: "int", nullable: false),
                    studentId = table.Column<int>(type: "int", nullable: false),
                    registionFormId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Results", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Results_RegistionForms_registionFormId",
                        column: x => x.registionFormId,
                        principalTable: "RegistionForms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Results_Rooms_roomId",
                        column: x => x.roomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistionForms_examinationId_levelId_studentId",
                table: "RegistionForms",
                columns: new[] { "examinationId", "levelId", "studentId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegistionForms_levelId",
                table: "RegistionForms",
                column: "levelId");

            migrationBuilder.CreateIndex(
                name: "IX_RegistionForms_studentId",
                table: "RegistionForms",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Results_registionFormId",
                table: "Results",
                column: "registionFormId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Results_roomId",
                table: "Results",
                column: "roomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_examinationId",
                table: "Rooms",
                column: "examinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_citizenCard",
                table: "Students",
                column: "citizenCard",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Results");

            migrationBuilder.DropTable(
                name: "RegistionForms");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Levels");
        }
    }
}
