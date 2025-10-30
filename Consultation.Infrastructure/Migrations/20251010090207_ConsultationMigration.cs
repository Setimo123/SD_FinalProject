using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Consultation.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ConsultationMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UMID = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Bulletin",
                columns: table => new
                {
                    BulletinID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Author = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    DatePublished = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    FileCount = table.Column<int>(type: "int", nullable: false),
                    IsArchived = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bulletin", x => x.BulletinID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DepartmentName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    NotificationNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NotificationMessage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NotificationType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.NotificationNumber);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SchoolYear",
                columns: table => new
                {
                    SchoolYearID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Year1 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Year2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SchoolYearStatus = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchoolYear", x => x.SchoolYearID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ActionLog",
                columns: table => new
                {
                    ActionLogID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    UsersId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionLog", x => x.ActionLogID);
                    table.ForeignKey(
                        name: "FK_ActionLog_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AdminName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsersID = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_Admin_AspNetUsers_UsersID",
                        column: x => x.UsersID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ProgramID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProgramName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Program", x => x.ProgramID);
                    table.ForeignKey(
                        name: "FK_Program_Department_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FacultyUMID = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FacultyName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FacultyEmail = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UsersID = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SchoolYearID = table.Column<int>(type: "int", nullable: false),
                    ProgramID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.FacultyID);
                    table.ForeignKey(
                        name: "FK_Faculty_AspNetUsers_UsersID",
                        column: x => x.UsersID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faculty_Program_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "Program",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Faculty_SchoolYear_SchoolYearID",
                        column: x => x.SchoolYearID,
                        principalTable: "SchoolYear",
                        principalColumn: "SchoolYearID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    StudentUMID = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StudentName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    yearLevel = table.Column<int>(type: "int", nullable: false),
                    ProgramID = table.Column<int>(type: "int", nullable: false),
                    SchoolYearID = table.Column<int>(type: "int", nullable: false),
                    UsersID = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                    table.ForeignKey(
                        name: "FK_Students_AspNetUsers_UsersID",
                        column: x => x.UsersID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_Program_ProgramID",
                        column: x => x.ProgramID,
                        principalTable: "Program",
                        principalColumn: "ProgramID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Students_SchoolYear_SchoolYearID",
                        column: x => x.SchoolYearID,
                        principalTable: "SchoolYear",
                        principalColumn: "SchoolYearID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FacultySchedule",
                columns: table => new
                {
                    FacultyScheduleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TimeStart = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    TimeEnd = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    Day = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultySchedule", x => x.FacultyScheduleID);
                    table.ForeignKey(
                        name: "FK_FacultySchedule_Faculty_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculty",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ConsultationRequest",
                columns: table => new
                {
                    ConsultationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateRequested = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateSchedule = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    StartedTime = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    EndedTime = table.Column<TimeOnly>(type: "time(6)", nullable: false),
                    Concern = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DisapprovedReason = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubjectCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false),
                    ProgramName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsultationRequest", x => x.ConsultationID);
                    table.ForeignKey(
                        name: "FK_ConsultationRequest_Faculty_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculty",
                        principalColumn: "FacultyID");
                    table.ForeignKey(
                        name: "FK_ConsultationRequest_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EnrolledCourse",
                columns: table => new
                {
                    EnrolledCourseID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CourseName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CourseCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SchoolYearID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    FacultyID = table.Column<int>(type: "int", nullable: false),
                    ProgramCourse = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnrolledCourse", x => x.EnrolledCourseID);
                    table.ForeignKey(
                        name: "FK_EnrolledCourse_Faculty_FacultyID",
                        column: x => x.FacultyID,
                        principalTable: "Faculty",
                        principalColumn: "FacultyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnrolledCourse_SchoolYear_SchoolYearID",
                        column: x => x.SchoolYearID,
                        principalTable: "SchoolYear",
                        principalColumn: "SchoolYearID");
                    table.ForeignKey(
                        name: "FK_EnrolledCourse_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UMID", "UserName", "UserType" },
                values: new object[,]
                {
                    { "0542B05F-A99D-43E3-AC02-D1724FD88E27", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "r.setimo.550200@umindanao.edu.ph", true, false, null, "R.SETIMO.550200@UMINDANAO.EDU.PH", "RENE CEDRIC SETIMO", "AQAAAAIAAYagAAAAEBRX/c+d7MuoQMdvZRIFdhUCjzDvVRlxw1jcxqm0BD5/JDU9seuUNrVfkn/wkmhcqw==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "550200", "Rene Cedric Setimo", 1 },
                    { "175A7233-93D9-4C74-870B-7C354E3035CC", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "knepa@umindanao.edu.ph", true, false, null, "KNEPA@UMINDANAO.EDU.PH", "KIMBERLY NEPA-MUANA", "AQAAAAIAAYagAAAAECwVRgr1a2BiU7JbuwxhUo2xnxVc29KERwMojMa0ars6mvyYGgQ9q0TNW7enU0LQUA==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "330006", "Kimberly Nepa-Muana", 2 },
                    { "18DA9DD0-CA87-4389-B12D-2B1A793F7A59", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "doro@umindanao.edu.ph", true, false, null, "DORO@UMINDANAO.EDU.PH", "DAN DAVID AARON ORO", "AQAAAAIAAYagAAAAEIc7BfVjfy8qXfRmZND4sz8QBmwyr7+t+bMjl2o/b745pTFQ8xu9chRj0ZyldnJSqw==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "340001", "Dan David Aaron Oro", 2 },
                    { "19D57012-9A44-4B2B-BBAF-F9361EBF62F7", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "salagao@umindanao.edu.ph", true, false, null, "SALAGAO@UMINDANAO.EDU.PH", "STEPHEN PAUL ALAGAO", "AQAAAAIAAYagAAAAEJaAaRCyYMRJxBArn7vdCyJUVg9fhvsZTo9HHnaKGLDp8V2H4Mn4nLiPHR/XWZaO8w==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "330002", "Stephen Paul Alagao", 2 },
                    { "1CE43429-A555-45F8-8D14-F93C147247B5", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "c.balsomo.544358@umindanao.edu.ph", true, false, null, "C.BALSOMO.544358@UMINDANAO.EDU.PH", "CHELEY BALSOMO", "AQAAAAIAAYagAAAAEPetr4Kr7ddS/t28dGj7I1nvB1D96ePbaUIaT4LBbcF6Rj1GjysXQ44QO8OXCVd/7g==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "544358", "Cheley Balsomo", 1 },
                    { "1DE3802A-E9C2-4B04-80DB-B32A3A5F1624", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "ccanesares@umindanao.edu.ph", true, false, null, "CCANESARES@UMINDANAO.EDU.PH", "CHARLITO CAÑESARES", "AQAAAAIAAYagAAAAEL5W1KB4G4LIBOjYAoFrqlcLCFFeNDoL5m3/i1514zocqgwuwf/vGKUdubq+Cbf6lg==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "310001", "Charlito Cañesares", 2 },
                    { "28DC4EA5-8AA7-43AA-813B-3E85D547893A", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "jgallenero@umindanao.edu.ph", true, false, null, "JGALLENERO@UMINDANAO.EDU.PH", "JAY GALLENERO", "AQAAAAIAAYagAAAAEO1ua+d/3wVpky6fzPQ7KUeGtd/FYrErbeoXGpw8QXsa68fV1bqRccCxV2bOM0QbCw==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "330005", "Jay Gallenero", 3 },
                    { "2B036F02-AC85-4511-A036-DA5B9238F157", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "mwata@umindanao.edu.ph", true, false, null, "MWATA@UMINDANAO.EDU.PH", "MARIANNE WATA", "AQAAAAIAAYagAAAAEIHM2qrAkHum2s0+Ipfh7ICjbrJxJWqR6pPDDo5rKM8u/NvrHsPNIJCYhjkD84Wkrg==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "330010", "Marianne Wata", 2 },
                    { "305AE16B-FBDB-435D-B97E-5A5EF3DC236D", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "h.basarte.550409@umindanao.edu.ph", true, false, null, "H.BASARTE.550409@UMINDANAO.EDU.PH", "HARWYNE ACE BASARTE", "AQAAAAIAAYagAAAAEPAh1El//va86g4HfCY+uYk24PW+0Y+v/f3+04YjOFLn9uiM8jbR+/TkCFxhUzA5xw==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "550409", "Harwyne Ace Basarte", 1 },
                    { "3A42AB5E-DC55-4BA4-9264-57C460539DDD", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "e.musni.545208@umindanao.edu.ph", true, false, null, "E.MUSNI.545208@UMINDANAO.EDU.PH", "ELLAINE MUSNI", "AQAAAAIAAYagAAAAEPUzxTWvKWqr3qIWpkpDQgTVnzK5vNcWi6uMnEwSvB/37dzPqNB/k0IOT3HodRcnrg==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "545208", "Ellaine Musni", 1 },
                    { "3FFC159F-6EF0-4D4E-8C95-3A75FA1600CE", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "n.orabi.535132@umindanao.edu.ph", true, false, null, "N.ORABI.535132@UMINDANAO.EDU.PH", "NASSIM EHAB ORABI", "AQAAAAIAAYagAAAAELWFffc4FsOm3sh4HxeUK8V+RaSaECLZ1MLRXrlnOIEwFmcECf+AL4ONWKiSEY3b1w==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "535132", "Nassim Ehab Orabi", 1 },
                    { "4018C0AF-6764-446E-99E0-B81FE80961E0", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "jordas@umindanao.edu.ph", true, false, null, "JORDAS@UMINDANAO.EDU.PH", "JETHRO JOSHUA ORDAS", "AQAAAAIAAYagAAAAEKxSTTg/NzHhxMzL9nqOhx01PuZmjhEwTV4NRiqXSOjLtrYpwnsySLUBW8cHXb+W3A==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "330007", "Jethro Joshua Ordas", 2 },
                    { "423965D1-0EF0-4CD9-931D-605CA7B38A3E", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "ccalunsag@umindanao.edu.ph", true, false, null, "CCALUNSAG@UMINDANAO.EDU.PH", "CARL JUSTINE CALUNSAG", "AQAAAAIAAYagAAAAECIzaS3Y2X6pqtEDlozRnbYdsrRgbntAA/FPnKkq4cmUYSeUCycmHu4A2WK8xR/uNg==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "320001", "Carl Justine Calunsag", 2 },
                    { "4D919EA9-ADBA-420A-9B19-BF1878E178C6", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "rangelia@umindanao.edu.ph", true, false, null, "RANGELIA@UMINDANAO.EDU.PH", "RANDY ANGELIA", "AQAAAAIAAYagAAAAEKCmSrCBcDFj71oyZzipT0rXehQZltQo2KWnML2SGlWEf9so36ByLFbJPNmbKW3g5g==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "330004", "Randy Angelia", 2 },
                    { "53E836AA-802B-4432-B682-CD9F86691317", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "ltubo@umindanao.edu.ph", true, false, null, "LTUBO@UMINDANAO.EDU.PH", "LESTER TUBO", "AQAAAAIAAYagAAAAECnidvfD7uRPrH2VrUO8DmHvJJ1ZSx3WjdSWxio26lm0jXynXi/xsKKXO2uLCpLmYA==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "330008", "Lester Tubo", 2 },
                    { "55D0D298-ED9B-4B4D-9270-2019C0A5802B", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "ramon@umindanao.edu.ph", true, false, null, "RAMON@UMINDANAO.EDU.PH", "RAMIRO EMERSON AMON", "AQAAAAIAAYagAAAAEBIVccTORAc3oAwvVSj8xd+YYIpk8dYcl4mmPOimQTrpJySN+MmsLiHSctLz7FZWgw==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "360001", "Ramiro Emerson Amon", 2 },
                    { "6EC682D8-03CC-4EBB-B48D-3D8DCBDD443D", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "jadtoon@umindanao.edu.ph", true, false, null, "JADTOON@UMINDANAO.EDU.PH", "JETRON ADTOON", "AQAAAAIAAYagAAAAEHt95IW4/l218+jsFBcXGT/o5rBkYb3scwM3yINibVX0CxNXhC8b7T0S3S+XtOLNcA==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "330001", "Jetron Adtoon", 2 },
                    { "9ECC5D8A-A6A9-46ED-89FC-BCD694F06CD7", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "r.mateo.547357@umindanao.edu.ph", true, false, null, "R.MATEO.547357@UMINDANAO.EDU.PH", "REYGIAN MATEO", "AQAAAAIAAYagAAAAEJ+soAmZvkLz/gKQDopn0W2JUIRDF2SP2KM9OmjCyjHICBwSMbxWQf/QTXPrXuSYLw==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "547357", "Reygian Mateo", 1 },
                    { "A4A8293F-AC1D-44AA-836F-D4C0A79FCFD9", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "jgallenero@umindanao.edu.ph", true, false, null, "JGALLENERO@UMINDANAO.EDU.PH", "JAY AL GALLENERO", "AQAAAAIAAYagAAAAENulO1sOhLor+cpb5JJaoOagguXcduPaTC75Ekp0FjP6Pui4OmsiZCz4DhRvj3GeoQ==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "330005", "Jay Al Gallenero", 2 },
                    { "A71A3F07-BDB7-44A9-8128-62848CF38181", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "juy@umindanao.edu.ph", true, false, null, "JUY@UMINDANAO.EDU.PH", "JULIE UY", "AQAAAAIAAYagAAAAEP7l8/gXCOoxv74eekrjWjV5dlBbvqDUE39obHf/sWxMc4OzC98gvCH+RClzZUYw7Q==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "330009", "Julie Uy", 2 },
                    { "AF1CA1A3-B937-45F0-9AE9-CBF355FE3F82", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "emorales@umindanao.edu.ph", true, false, null, "EMORALES@UMINDANAO.EDU.PH", "EGI JOE FRAN MORALES", "AQAAAAIAAYagAAAAEFjEfocaAba6RGXgRyN8uugEGtbqT/R89Y1T6oTYOnby0WfpR/xvDBUwim5fQ0pr1w==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "350001", "Egi Joe Fran Morales", 2 },
                    { "B1FBEBAB-BDF2-473A-8AE4-E8CB036F32CE", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "r.soylon.526044@umindanao.edu.ph", true, false, null, "R.SOYLON.526044@UMINDANAO.EDU.PH", "REGGIE SOYLON", "AQAAAAIAAYagAAAAEMNZK5s8js5oR1xKcOJ25+kkmYQT+HNhh7Clcmc3HDwV8fTjZa7vMLjGGmyR7IB2hw==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "526044", "Reggie Soylon", 1 },
                    { "C67B48B9-C09D-4A03-BB9F-A3E70D98EAFF", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "r.isid.545154@umindanao.edu.ph", true, false, null, "R.ISID.545154@UMINDANAO.EDU.PH", "RIANE KAISER ISID", "AQAAAAIAAYagAAAAENI+hEqn7IG4q2odQNbKdHsOQDQBjXrtb3oKv/iPAwP6qWniALsDqir7P78e820ASw==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "545154", "Riane Kaiser Isid", 1 },
                    { "CA0C4ABD-802D-4B0F-85CF-778E7EA4EF01", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "hangelia@umindanao.edu.ph", true, false, null, "HANGELIA@UMINDANAO.EDU.PH", "HANNAH LEAH ANGELIA", "AQAAAAIAAYagAAAAEI9X79OTcLIUBuw5xz5+PxNK1WKi6DyUmuJsT66ZikzlBDj27v1I2SGWIYcIwPBT4A==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "330003", "Hannah Leah Angelia", 2 },
                    { "DA470776-6AD4-42A3-9266-6DC67444D7B7", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "j.labsan.548631@umindanao.edu.ph", true, false, null, "J.LABSAN.548631@UMINDANAO.EDU.PH", "JEANELLE LABSAN", "AQAAAAIAAYagAAAAEMl/mZELurHmR5mkKL9PLadMSBBTxKEXopB5J3KGbuCkNS9tePFTfABRo21n9jrDDg==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "548631", "Jeanelle Labsan", 1 },
                    { "EAD9B361-DF40-48F6-AC0F-4A89AFFA72D2", 0, "8d3ef0d9-b045-4b8f-a18f-15f2cbfa219b", "c.destajo.546094@umindanao.edu.ph", true, false, null, "C.DESTAJO.546094@UMINDANAO.EDU.PH", "CHRISTOPHER JOHN DESTAJO", "AQAAAAIAAYagAAAAEE5tzrbpn6zs4ZHNydcz0NMSIxoLfamTS4M0BxsNzyp3eTHYz8r/IsnardsaAeQjxg==", null, false, "5a54c967-0b1f-4c38-bda7-5f94e4c1a3f4", false, "546094", "Christopher John Destajo", 1 }
                });

            migrationBuilder.InsertData(
                table: "Department",
                columns: new[] { "DepartmentID", "DepartmentName", "Description" },
                values: new object[,]
                {
                    { 1, "CASE", "College of Arts and Sciences Education" },
                    { 2, "CBAE", "College of Business Administration Education" },
                    { 3, "CEE", "College of Engineering Education" },
                    { 4, "CAE", "College of Accounting Education" },
                    { 5, "CAFAE", "College of Architecture and Fine Arts Education" },
                    { 6, "CCE", "College of Computing Education" },
                    { 7, "CTE", "College of Teacher Education" },
                    { 8, "CCJE", "College of Criminal Justice Education" },
                    { 9, "CHE", "College of Hospitality Education" },
                    { 10, "CHSE", "College of Health Sciences Education" }
                });

            migrationBuilder.InsertData(
                table: "Notification",
                columns: new[] { "NotificationNumber", "NotificationMessage", "NotificationType" },
                values: new object[,]
                {
                    { 1, "Your consultation request has been successfully submitted.", 1 },
                    { 2, "Your consultation schedule has been disapproved by the faculty.", 1 },
                    { 3, "A new faculty account has been registered in the system.", 2 }
                });

            migrationBuilder.InsertData(
                table: "SchoolYear",
                columns: new[] { "SchoolYearID", "SchoolYearStatus", "Semester", "Year1", "Year2" },
                values: new object[,]
                {
                    { 1, 1, 1, "2024", "2025" },
                    { 2, 1, 2, "2024", "2025" },
                    { 3, 1, 3, "2024", "2025" }
                });

            migrationBuilder.InsertData(
                table: "Admin",
                columns: new[] { "AdminID", "AdminName", "UsersID" },
                values: new object[] { 1, "Jay Al Gallenero", "28DC4EA5-8AA7-43AA-813B-3E85D547893A" });

            migrationBuilder.InsertData(
                table: "Program",
                columns: new[] { "ProgramID", "DepartmentID", "Description", "ProgramName" },
                values: new object[,]
                {
                    { 1, 3, "Mechanical Engineering", "ME" },
                    { 2, 3, "Civil Engineering", "CE" },
                    { 3, 3, "Computer Engineering", "CpE" },
                    { 4, 3, "Electrical Engineering", "EE" },
                    { 5, 3, "Electronics and Communication Engineering", "ECE" },
                    { 6, 3, "Chemical Engineering", "ChE" },
                    { 7, 3, "Materials Engineering", "MaE" }
                });

            migrationBuilder.InsertData(
                table: "Faculty",
                columns: new[] { "FacultyID", "FacultyEmail", "FacultyName", "FacultyUMID", "ProgramID", "SchoolYearID", "UsersID" },
                values: new object[,]
                {
                    { 1, "jadtoon@umindanao.edu.ph", "Jetron Adtoon", "330001", 3, 1, "6EC682D8-03CC-4EBB-B48D-3D8DCBDD443D" },
                    { 2, "salagao@umindanao.edu.ph", "Stephen Paul Alagao", "330002", 3, 1, "19D57012-9A44-4B2B-BBAF-F9361EBF62F7" },
                    { 3, "hangelia@umindanao.edu.ph", "Hannah Leah Angelia", "330003", 3, 1, "CA0C4ABD-802D-4B0F-85CF-778E7EA4EF01" },
                    { 4, "rangelia@umindanao.edu.ph", "Randy Angelia", "330004", 3, 1, "4D919EA9-ADBA-420A-9B19-BF1878E178C6" },
                    { 5, "jgallenero@umindanao.edu.ph", "Jay Al Gallenero", "330005", 3, 1, "A4A8293F-AC1D-44AA-836F-D4C0A79FCFD9" },
                    { 6, "knepa@umindanao.edu.ph", "Kimberly Nepa-Muaña", "330006", 3, 1, "175A7233-93D9-4C74-870B-7C354E3035CC" },
                    { 7, "jordas@umindanao.edu.ph", "Jethro Joshua Ordas", "330007", 3, 1, "4018C0AF-6764-446E-99E0-B81FE80961E0" },
                    { 8, "ltubo@umindanao.edu.ph", "Lester Tubo", "330008", 3, 1, "53E836AA-802B-4432-B682-CD9F86691317" },
                    { 9, "juy@umindanao.edu.ph", "Julie Uy", "330009", 3, 1, "A71A3F07-BDB7-44A9-8128-62848CF38181" },
                    { 10, "mwata@umindanao.edu.ph", "Marianne Wata", "330010", 3, 1, "2B036F02-AC85-4511-A036-DA5B9238F157" },
                    { 11, "ccañesares@umindanao.edu.ph", "Charlito Cañesares", "310001", 1, 1, "1DE3802A-E9C2-4B04-80DB-B32A3A5F1624" },
                    { 12, "ccalunsag@umindanao.edu.ph", "Carl Justine Calunsag", "320001", 2, 1, "423965D1-0EF0-4CD9-931D-605CA7B38A3E" },
                    { 13, "doro@umindanao.edu.ph", "Dan David Aaron Oro", "340001", 4, 1, "18DA9DD0-CA87-4389-B12D-2B1A793F7A59" },
                    { 14, "emorales@umindanao.edu.ph", "Egi Joe Fran Morales", "350001", 5, 1, "AF1CA1A3-B937-45F0-9AE9-CBF355FE3F82" },
                    { 15, "ramon@umindanao.edu.ph", "Ramiro Emerson Amon", "360001", 6, 1, "55D0D298-ED9B-4B4D-9270-2019C0A5802B" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Email", "ProgramID", "SchoolYearID", "StudentName", "StudentUMID", "UsersID", "yearLevel" },
                values: new object[,]
                {
                    { 1, "c.balsomo.544358@umindanao.edu.ph", 1, 1, "Cheley Balsomo", "544358", "1CE43429-A555-45F8-8D14-F93C147247B5", 3 },
                    { 2, "h.basarte.550409@umindanao.edu.ph", 1, 1, "Harwyne Ace Basarte", "550409", "305AE16B-FBDB-435D-B97E-5A5EF3DC236D", 3 },
                    { 3, "c.destajo.546094@umindanao.edu.ph", 2, 1, "Christopher John Destajo", "546094", "EAD9B361-DF40-48F6-AC0F-4A89AFFA72D2", 3 },
                    { 4, "r.isid.545154@umindanao.edu.ph", 2, 1, "Riane Kaiser Isid", "545154", "C67B48B9-C09D-4A03-BB9F-A3E70D98EAFF", 3 },
                    { 5, "j.labsan.548631@umindanao.edu.ph", 3, 1, "Jeanelle Labsan", "548631", "DA470776-6AD4-42A3-9266-6DC67444D7B7", 3 },
                    { 6, "r.mateo.547357@umindanao.edu.ph", 3, 1, "Reygian Mateo", "547357", "9ECC5D8A-A6A9-46ED-89FC-BCD694F06CD7", 3 },
                    { 7, "e.musni.545208@umindanao.edu.ph", 4, 1, "Ellaine Musni", "545208", "3A42AB5E-DC55-4BA4-9264-57C460539DDD", 3 },
                    { 8, "n.orabi.535132@umindanao.edu.ph", 4, 1, "Nassim Ehab Orabi", "535132", "3FFC159F-6EF0-4D4E-8C95-3A75FA1600CE", 3 },
                    { 9, "r.setimo.550200@umindanao.edu.ph", 5, 1, "Rene Cedric Setimo", "550200", "0542B05F-A99D-43E3-AC02-D1724FD88E27", 3 },
                    { 10, "r.soylon.526044@umindanao.edu.ph", 6, 1, "Reggie Soylon", "526044", "B1FBEBAB-BDF2-473A-8AE4-E8CB036F32CE", 3 }
                });

            migrationBuilder.InsertData(
                table: "ConsultationRequest",
                columns: new[] { "ConsultationID", "Concern", "DateRequested", "DateSchedule", "DisapprovedReason", "EndedTime", "FacultyID", "ProgramName", "StartedTime", "Status", "StudentID", "SubjectCode" },
                values: new object[,]
                {
                    { 1, "Having trouble following discussions", new DateTime(2025, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new TimeOnly(16, 0, 0), 14, "ECE", new TimeOnly(15, 0, 0), 5, 9, "CEE103" },
                    { 2, "Follow-up on previous consultation", new DateTime(2025, 9, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Faculty unavailable", new TimeOnly(11, 0, 0), 10, "CpE", new TimeOnly(10, 0, 0), 3, 2, "CPE221L" },
                    { 3, "Concerns regarding my grades", new DateTime(2025, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new TimeOnly(12, 30, 0), 11, "ME", new TimeOnly(11, 30, 0), 1, 10, "CEE105" }
                });

            migrationBuilder.InsertData(
                table: "EnrolledCourse",
                columns: new[] { "EnrolledCourseID", "CourseCode", "CourseName", "FacultyID", "ProgramCourse", "SchoolYearID", "StudentID" },
                values: new object[,]
                {
                    { 1, "CEE103", "Engineering Calculus 2", 14, "ECE", 1, 9 },
                    { 2, "CEE102L", "Physics 1 for Engineers", 12, "CE", 1, 8 },
                    { 3, "CPE211L", "Data Structures and Algorithms", 10, "CpE", 1, 2 },
                    { 4, "DRAW102L", "Computer Aided Drafting", 13, "EE", 1, 4 },
                    { 5, "CEE105", "Engineering Data Analysis", 11, "ME", 1, 10 },
                    { 6, "CEE104", "Differential Equations", 15, "ChE", 2, 7 },
                    { 7, "CEE109", "Engineering Economics", 12, "CE", 2, 1 },
                    { 8, "CPE223L", "Software Design", 5, "CpE", 2, 5 },
                    { 9, "BEE212L", "Fundamentals of Electric Circuits", 13, "CpE", 1, 6 },
                    { 10, "CEE115", "Technopreneurship", 2, "CpE", 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "FacultySchedule",
                columns: new[] { "FacultyScheduleID", "Day", "FacultyID", "TimeEnd", "TimeStart" },
                values: new object[,]
                {
                    { 1, 1, 14, new TimeOnly(16, 0, 0), new TimeOnly(15, 0, 0) },
                    { 2, 3, 10, new TimeOnly(11, 0, 0), new TimeOnly(10, 0, 0) },
                    { 3, 5, 11, new TimeOnly(12, 30, 0), new TimeOnly(11, 30, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionLog_UsersId",
                table: "ActionLog",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Admin_UsersID",
                table: "Admin",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRequest_FacultyID",
                table: "ConsultationRequest",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_ConsultationRequest_StudentID",
                table: "ConsultationRequest",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourse_FacultyID",
                table: "EnrolledCourse",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourse_SchoolYearID",
                table: "EnrolledCourse",
                column: "SchoolYearID");

            migrationBuilder.CreateIndex(
                name: "IX_EnrolledCourse_StudentID",
                table: "EnrolledCourse",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_ProgramID",
                table: "Faculty",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_SchoolYearID",
                table: "Faculty",
                column: "SchoolYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Faculty_UsersID",
                table: "Faculty",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_FacultySchedule_FacultyID",
                table: "FacultySchedule",
                column: "FacultyID");

            migrationBuilder.CreateIndex(
                name: "IX_Program_DepartmentID",
                table: "Program",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_ProgramID",
                table: "Students",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_SchoolYearID",
                table: "Students",
                column: "SchoolYearID");

            migrationBuilder.CreateIndex(
                name: "IX_Students_UsersID",
                table: "Students",
                column: "UsersID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionLog");

            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bulletin");

            migrationBuilder.DropTable(
                name: "ConsultationRequest");

            migrationBuilder.DropTable(
                name: "EnrolledCourse");

            migrationBuilder.DropTable(
                name: "FacultySchedule");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Faculty");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "SchoolYear");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
