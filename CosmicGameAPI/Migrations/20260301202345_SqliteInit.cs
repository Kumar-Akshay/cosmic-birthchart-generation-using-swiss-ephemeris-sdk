using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CosmicGameAPI.Migrations
{
    /// <inheritdoc />
    public partial class SqliteInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BhavaPlanets",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ChartHolderId = table.Column<int>(type: "INTEGER", nullable: false),
                    Bhavalst = table.Column<string>(type: "TEXT", nullable: true),
                    Palenetlst = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BhavaPlanets", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ChartHolders",
                columns: table => new
                {
                    ChartHolderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ChildName = table.Column<string>(type: "TEXT", nullable: true),
                    FatherName = table.Column<string>(type: "TEXT", nullable: true),
                    MotherName = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    BirthPlace = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    State = table.Column<string>(type: "TEXT", nullable: true),
                    Country = table.Column<string>(type: "TEXT", nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", nullable: true),
                    DOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TOB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeZone = table.Column<string>(type: "TEXT", nullable: true),
                    Ayanamasa = table.Column<string>(type: "TEXT", nullable: true),
                    HouseSystem = table.Column<string>(type: "TEXT", nullable: true),
                    AyanamasaPolicy = table.Column<string>(type: "TEXT", nullable: true),
                    LatLocator = table.Column<string>(type: "TEXT", nullable: true),
                    LngLocator = table.Column<string>(type: "TEXT", nullable: true),
                    Latitude = table.Column<string>(type: "TEXT", nullable: true),
                    Longitude = table.Column<string>(type: "TEXT", nullable: true),
                    ChartType = table.Column<int>(type: "INTEGER", nullable: false),
                    BirthTimeRectified = table.Column<bool>(type: "INTEGER", nullable: false),
                    RectifiedTOB = table.Column<TimeSpan>(type: "TEXT", nullable: true),
                    Contact = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChartHolders", x => x.ChartHolderId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CountryName = table.Column<string>(type: "TEXT", nullable: true),
                    ActualTimeZone = table.Column<string>(type: "TEXT", nullable: true),
                    NameOfTimeZone = table.Column<string>(type: "TEXT", nullable: true),
                    TotalTimeZone = table.Column<int>(type: "INTEGER", nullable: false),
                    CountOfTimeZone = table.Column<int>(type: "INTEGER", nullable: false),
                    AreasCovered = table.Column<string>(type: "TEXT", nullable: true),
                    YearFrom = table.Column<string>(type: "TEXT", nullable: true),
                    IsDST = table.Column<decimal>(type: "TEXT", nullable: false),
                    DSTFromTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DSTToTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TimeZoneValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrentAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Country = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsActive = table.Column<decimal>(type: "TEXT", nullable: false),
                    TimeZone = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    LatLocator = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    LngLocator = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    Longitude = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Latitude = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentAddresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ErrorLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ErrorLogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "u_Lev4_S4SL_Registers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LineNo = table.Column<double>(type: "REAL", nullable: true),
                    S1SLCount = table.Column<double>(type: "REAL", nullable: true),
                    S2SLCount = table.Column<double>(type: "REAL", nullable: true),
                    S3SLCount = table.Column<double>(type: "REAL", nullable: true),
                    S4SLCount = table.Column<double>(type: "REAL", nullable: true),
                    Ext_Line = table.Column<string>(type: "TEXT", nullable: true),
                    KC_INDEX = table.Column<double>(type: "REAL", nullable: true),
                    KC_Name = table.Column<string>(type: "TEXT", nullable: true),
                    KC_Rasi_Lord = table.Column<string>(type: "TEXT", nullable: true),
                    KC_Rasi_Lord_SPL = table.Column<string>(type: "TEXT", nullable: true),
                    StarCount = table.Column<double>(type: "REAL", nullable: true),
                    StarName = table.Column<string>(type: "TEXT", nullable: true),
                    StarLord = table.Column<string>(type: "TEXT", nullable: true),
                    VimsoPeriod = table.Column<double>(type: "REAL", nullable: true),
                    S1SL = table.Column<string>(type: "TEXT", nullable: true),
                    S2SL = table.Column<string>(type: "TEXT", nullable: true),
                    S3SL = table.Column<string>(type: "TEXT", nullable: true),
                    S4SL = table.Column<string>(type: "TEXT", nullable: true),
                    S4SL_ArcDist = table.Column<double>(type: "REAL", nullable: true),
                    DMS = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_u_Lev4_S4SL_Registers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserLoginInfos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LoginType = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    IpAddress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsLogin = table.Column<decimal>(type: "TEXT", nullable: false),
                    Browser = table.Column<string>(type: "TEXT", nullable: true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Token = table.Column<string>(type: "TEXT", nullable: true),
                    LastLoginDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLoginInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    Password = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(type: "TEXT", maxLength: 15, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 30, nullable: true),
                    IsActive = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsAllowMultipelLogin = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsApproved = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsDelete = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "VimsoMasterRegisters",
                columns: table => new
                {
                    LineNo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rasi_id = table.Column<int>(type: "INTEGER", nullable: false),
                    Rasi = table.Column<string>(type: "TEXT", nullable: true),
                    Rasi_L = table.Column<string>(type: "TEXT", nullable: true),
                    Star_id = table.Column<int>(type: "INTEGER", nullable: false),
                    StarName = table.Column<string>(type: "TEXT", nullable: true),
                    Vimso_pd = table.Column<int>(type: "INTEGER", nullable: false),
                    Di_Gp = table.Column<int>(type: "INTEGER", nullable: false),
                    StarLord = table.Column<string>(type: "TEXT", nullable: true),
                    Pu_Gp = table.Column<int>(type: "INTEGER", nullable: false),
                    S1SL = table.Column<string>(type: "TEXT", nullable: true),
                    An_Gp = table.Column<int>(type: "INTEGER", nullable: false),
                    S2SL = table.Column<string>(type: "TEXT", nullable: true),
                    So_Gp = table.Column<int>(type: "INTEGER", nullable: false),
                    S3SL = table.Column<string>(type: "TEXT", nullable: true),
                    S4SL = table.Column<string>(type: "TEXT", nullable: true),
                    S4SL_ArcDist = table.Column<double>(type: "REAL", nullable: false),
                    Moving_Distance = table.Column<double>(type: "REAL", nullable: false),
                    DMS = table.Column<string>(type: "TEXT", nullable: true),
                    Pre_S4SL_ArcDist = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VimsoMasterRegisters", x => x.LineNo);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BhavaPlanets");

            migrationBuilder.DropTable(
                name: "ChartHolders");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "CurrentAddresses");

            migrationBuilder.DropTable(
                name: "ErrorLogs");

            migrationBuilder.DropTable(
                name: "u_Lev4_S4SL_Registers");

            migrationBuilder.DropTable(
                name: "UserLoginInfos");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "VimsoMasterRegisters");
        }
    }
}
