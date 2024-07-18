using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestTaskSmart.Server.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subdivisions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subdivisions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PositionId = table.Column<int>(type: "int", nullable: false),
                    SubdivisionId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    PeoplePartnerId = table.Column<int>(type: "int", nullable: true),
                    Balance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Employees_PeoplePartnerId",
                        column: x => x.PeoplePartnerId,
                        principalTable: "Employees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employees_Positions_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Positions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Subdivisions_SubdivisionId",
                        column: x => x.SubdivisionId,
                        principalTable: "Subdivisions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AbsenceReason = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ApprovalRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveRequestId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApprovalRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApprovalRequests_LeaveRequests_LeaveRequestId",
                        column: x => x.LeaveRequestId,
                        principalTable: "LeaveRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeesProjects",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesProjects", x => new { x.EmployeeId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_EmployeesProjects_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeesProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "HR" },
                    { 3, "PM" },
                    { 4, "Employee" }
                });

            migrationBuilder.InsertData(
                table: "Subdivisions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Subdivision1" },
                    { 3, "Subdivision2" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Balance", "FullName", "Login", "Password", "PeoplePartnerId", "PositionId", "Status", "SubdivisionId" },
                values: new object[,]
                {
                    { 1, 0, "Admin Admin", "admin", "admin", null, 1, true, 1 },
                    { 2, 0, "Alice HR", "hr1", "hr1", null, 2, true, 2 },
                    { 3, 0, "Bob HR", "hr2", "hr2", null, 2, true, 3 },
                    { 4, 0, "Charlie PM", "pm1", "pm1", null, 3, true, 2 },
                    { 5, 0, "David PM", "pm2", "pm2", null, 3, true, 3 },
                    { 6, 5, "Emma Emp", "emp1", "emp1", null, 4, true, 2 },
                    { 7, 5, "Liam Emp", "emp2", "emp2", null, 4, true, 3 },
                    { 8, 21, "Jazmyn Bergstrom", "Joe.Altenwerth33", "Rwnrp8rCto", 2, 4, true, 2 },
                    { 9, 21, "Trudie Bashirian", "Rahul8", "tKoJguhGRH", 2, 4, true, 2 },
                    { 10, 9, "Vladimir Jacobi", "Ned_Moore65", "2u55jsmXvJ", 2, 4, true, 2 },
                    { 11, 5, "Desiree Wolf", "Ruthe_Lang", "UzwfltqNm4", 2, 4, false, 2 },
                    { 12, 16, "Florencio Brown", "Major_Ondricka5", "Gqwszre_3d", 2, 4, true, 2 },
                    { 13, 14, "Bernita Jacobs", "Rosario.Schiller", "c9I3uSJIoN", 2, 4, false, 2 },
                    { 14, 16, "Frederic Rolfson", "Jo.Muller26", "oiiDtgtKcV", 2, 4, false, 2 },
                    { 15, 17, "Elody D'Amore", "Juwan.Dibbert", "MsQHevYp2o", 2, 4, true, 2 },
                    { 16, 11, "Claudine Schmidt", "Giovani_Vandervort41", "oOQXOEc5D9", 2, 4, true, 2 },
                    { 17, 25, "Alison Bayer", "Myrtie.Zboncak", "72h0Gydnkw", 2, 4, true, 2 },
                    { 18, 21, "Benton Schinner", "Winona_Kohler42", "jpxmByZ4un", 2, 4, true, 2 },
                    { 19, 7, "Keon Dare", "Floy_Barrows", "J2qW3Q7bzs", 2, 4, false, 2 },
                    { 20, 4, "Casper Kemmer", "Jean_Koss", "AH68qiqVQX", 2, 4, true, 2 },
                    { 21, 5, "Name Wuckert", "Rodolfo.Windler16", "O8nx9Wrsq3", 2, 4, true, 2 },
                    { 22, 2, "Maximo Rogahn", "Leanna_Bartoletti", "HyzHvDYi7Z", 2, 4, true, 2 },
                    { 23, 16, "Lelah Fritsch", "Scarlett.Kris96", "lSqj7PFAI4", 2, 4, true, 2 },
                    { 24, 21, "Bernadine Schamberger", "Emelie_Jast73", "QwXuuh7hkl", 2, 4, false, 2 },
                    { 25, 14, "Reece D'Amore", "Carmela41", "soCQ50CfZI", 2, 4, false, 2 },
                    { 26, 12, "Bella Bradtke", "Giuseppe2", "MRhrXsOOlq", 2, 4, true, 2 },
                    { 27, 16, "Cade Harvey", "Kyra.Boehm", "73VO17ln25", 2, 4, false, 2 },
                    { 28, 4, "Sigrid Nicolas", "Carole64", "uBsVq4AjG8", 2, 4, true, 2 },
                    { 29, 17, "Reinhold Lemke", "Tressie48", "AstlNUOrQH", 2, 4, false, 2 },
                    { 30, 28, "Jedediah Morissette", "Emilio.Cummerata27", "V1OX_7BIC2", 2, 4, false, 2 },
                    { 31, 18, "Arno Quigley", "Guillermo94", "s7pLPsdOfK", 2, 4, false, 2 },
                    { 32, 27, "Geovanny Schneider", "Eileen_Murphy47", "DGw1Bm1sL3", 2, 4, false, 2 },
                    { 33, 4, "Colten Batz", "Lilyan.Lowe15", "ki38Kl3h6y", 3, 4, true, 3 },
                    { 34, 13, "Allen Weber", "Richard_Stracke8", "JAqMBzT2T6", 3, 4, true, 3 },
                    { 35, 8, "Haleigh Dickinson", "Ethyl.Wilkinson", "Yp7qo3P2A9", 3, 4, true, 3 },
                    { 36, 6, "Garfield Gislason", "Alexie46", "bRXLcj49GV", 3, 4, true, 3 },
                    { 37, 5, "Audreanne Fritsch", "Judah_Dickens", "0dN9LvoPQa", 3, 4, true, 3 },
                    { 38, 22, "Annie O'Connell", "Kimberly54", "PDvK0X5ZAC", 3, 4, true, 3 },
                    { 39, 11, "Jan Tromp", "Bailee.Bogan90", "yy34MoS1b1", 3, 4, false, 3 },
                    { 40, 2, "Israel Kohler", "Maiya.Pagac", "wLVry1Ncjm", 3, 4, false, 3 },
                    { 41, 25, "Delphia Bartell", "Maxwell8", "uSqvp300sy", 3, 4, true, 3 },
                    { 42, 5, "Madyson Daniel", "Russell.Berge55", "y2qzKKTtPe", 3, 4, true, 3 },
                    { 43, 22, "Pasquale O'Kon", "Percy.Hayes11", "YpkUEuJsvX", 3, 4, false, 3 },
                    { 44, 8, "Rowena Jakubowski", "Kathryne92", "MsSQIY4SL4", 3, 4, false, 3 },
                    { 45, 17, "Modesta Frami", "Paris.Rau", "wI_Jr6LPga", 3, 4, false, 3 },
                    { 46, 9, "Pink Walter", "Eriberto92", "43Lr3d2Huk", 3, 4, false, 3 },
                    { 47, 8, "Hassie Fay", "Emmanuelle_Hauck55", "WfM65CbrGx", 3, 4, true, 3 },
                    { 48, 3, "Keyon Hayes", "Harvey.Buckridge31", "8gJzNdXOxD", 3, 4, false, 3 },
                    { 49, 18, "Rebecca Fahey", "Olga42", "laOc5Dj8IZ", 3, 4, false, 3 },
                    { 50, 6, "Felicia Collier", "Isac_Witting10", "pdk1sOLafI", 3, 4, false, 3 },
                    { 51, 25, "Berry Volkman", "Sophie.Schultz", "VqfgpWTEjP", 3, 4, false, 3 },
                    { 52, 29, "Theo Koelpin", "Rylan_Gleason", "x4kGFiP8QH", 3, 4, false, 3 },
                    { 53, 30, "Ford Padberg", "Chauncey_Turner", "C0ewLNm0iv", 3, 4, false, 3 },
                    { 54, 7, "Carmen Klocko", "Jerry39", "MavblyI0qf", 3, 4, false, 3 },
                    { 55, 21, "Kevon Huels", "Mckenna.VonRueden", "kdnyNPVQtE", 3, 4, false, 3 },
                    { 56, 20, "Lisa Lesch", "Wava.Purdy", "EP2uXwL600", 3, 4, false, 3 },
                    { 57, 12, "Reinhold Weimann", "Stan26", "gZJVwBVEVK", 3, 4, true, 3 }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Comment", "EndDate", "ProjectManagerId", "StartDate", "Status", "Type" },
                values: new object[,]
                {
                    { 1, "", new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6280), 4, new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6278), true, 0 },
                    { 2, "", new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6285), 4, new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6284), true, 2 },
                    { 3, "", new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6289), 5, new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6288), true, 1 }
                });

            migrationBuilder.InsertData(
                table: "EmployeesProjects",
                columns: new[] { "EmployeeId", "ProjectId" },
                values: new object[,]
                {
                    { 11, 2 },
                    { 13, 2 },
                    { 14, 1 },
                    { 25, 1 },
                    { 31, 3 },
                    { 33, 3 }
                });

            migrationBuilder.InsertData(
                table: "LeaveRequests",
                columns: new[] { "Id", "AbsenceReason", "Comment", "EmployeeId", "EndDate", "StartDate", "Status" },
                values: new object[,]
                {
                    { 1, 0, "", 9, new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6185), new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6133), 0 },
                    { 2, 1, "", 10, new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6193), new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6191), 0 },
                    { 3, 2, "", 14, new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6197), new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6195), 0 },
                    { 4, 3, "", 32, new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6200), new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6199), 0 },
                    { 5, 4, "", 31, new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6203), new DateTime(2024, 7, 15, 2, 11, 20, 989, DateTimeKind.Local).AddTicks(6202), 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_EmployeeId",
                table: "ApprovalRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalRequests_LeaveRequestId",
                table: "ApprovalRequests",
                column: "LeaveRequestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PeoplePartnerId",
                table: "Employees",
                column: "PeoplePartnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PositionId",
                table: "Employees",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_SubdivisionId",
                table: "Employees",
                column: "SubdivisionId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeesProjects_ProjectId",
                table: "EmployeesProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_EmployeeId",
                table: "LeaveRequests",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApprovalRequests");

            migrationBuilder.DropTable(
                name: "EmployeesProjects");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Positions");

            migrationBuilder.DropTable(
                name: "Subdivisions");
        }
    }
}
