using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace NAMIS.Migrations
{
    public partial class initialMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("SET default_storage_engine=INNODB");
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(250)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(250)", nullable: false),
                    StationName = table.Column<string>(type: "varchar(250)", nullable: false),
                    RegisteredDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Department = table.Column<string>(type: "varchar(150)", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    LastUpdate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Unit = table.Column<string>(type: "varchar(150)", nullable: true),
                    LastLogin = table.Column<DateTime>(type: "datetime", nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(250)", nullable: true),
                    StaffName = table.Column<string>(type: "varchar(700)", nullable: true),
                    Title = table.Column<string>(type: "varchar(20)", nullable: false),
                    UserID = table.Column<string>(type: "varchar(50)", nullable: true),
                    RoleID = table.Column<string>(type: "varchar(50)", nullable: true),
                    mda = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "biodata",
                columns: table => new
                {
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Surname = table.Column<string>(type: "varchar(500)", nullable: false),
                    MiddleName = table.Column<string>(type: "varchar(500)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(500)", nullable: false),
                    Sex = table.Column<string>(type: "varchar(10)", nullable: false),
                    Decoration = table.Column<string>(type: "varchar(10)", nullable: false),
                    Natinality = table.Column<string>(type: "varchar(50)", nullable: false),
                    DateOfFirstAppointment = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateOfFirstArrival = table.Column<DateTime>(type: "datetime", nullable: false),
                    LGAOrigin = table.Column<string>(type: "varchar(150)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "varchar(50)", nullable: false),
                    CheckBy = table.Column<string>(type: "varchar(500)", nullable: true),
                    Proof = table.Column<string>(type: "varchar(50)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "varchar(50)", nullable: true),
                    Time = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    HomeAddress = table.Column<string>(type: "varchar(5000)", nullable: false),
                    Department = table.Column<string>(type: "varchar(100)", nullable: false),
                    GeographicalLocation = table.Column<string>(type: "varchar(50)", nullable: false),
                    SubstansiveAppointment = table.Column<string>(type: "varchar(50)", nullable: false),
                    DateOfAppointment = table.Column<string>(type: "text", nullable: true),
                    TermsOfEngagement = table.Column<string>(type: "varchar(50)", nullable: false),
                    CurrentAppointment = table.Column<string>(type: "varchar(150)", nullable: false),
                    StateOfOrigin = table.Column<string>(type: "varchar(50)", nullable: false),
                    DateOfCurrentAppointment = table.Column<DateTime>(type: "datetime", nullable: false),
                    StationName = table.Column<string>(type: "varchar(50)", nullable: false),
                    Carder = table.Column<string>(type: "varchar(150)", nullable: false),
                    EdNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    HodNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    UnitNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    HighestQualification = table.Column<string>(type: "varchar(50)", nullable: false),
                    GradeLevel = table.Column<string>(type: "varchar(50)", nullable: false),
                    Step = table.Column<string>(type: "varchar(10)", nullable: false),
                    TrainingStatus = table.Column<string>(type: "varchar(50)", nullable: true),
                    QualificationInView = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProStatus = table.Column<string>(type: "varchar(20)", nullable: true),
                    RStatus = table.Column<string>(type: "varchar(20)", nullable: true),
                    ProYr = table.Column<string>(type: "varchar(20)", nullable: true),
                    RYr = table.Column<string>(type: "varchar(20)", nullable: true),
                    AppointmentStatus = table.Column<string>(type: "varchar(20)", nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ConfirmationYr = table.Column<string>(type: "varchar(20)", nullable: true),
                    DateOfRetirement = table.Column<DateTime>(type: "datetime", nullable: false),
                    IPPISNO = table.Column<string>(type: "varchar(50)", nullable: true),
                    DateOfPromotion = table.Column<DateTime>(type: "datetime", nullable: false),
                    NHISNO = table.Column<string>(type: "varchar(50)", nullable: true),
                    PhoneNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    EmailID = table.Column<string>(type: "varchar(50)", nullable: true),
                    NHFNO = table.Column<string>(type: "varchar(50)", nullable: true),
                    RMode = table.Column<string>(type: "varchar(50)", nullable: true),
                    PFA = table.Column<string>(type: "varchar(100)", nullable: true),
                    PinNo = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biodata", x => x.SprpNo);
                });

            migrationBuilder.CreateTable(
                name: "biodataViewModel",
                columns: table => new
                {
                    SprpNo = table.Column<string>(type: "varchar(767)", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_biodataViewModel", x => x.SprpNo);
                });

            migrationBuilder.CreateTable(
                name: "Box",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Subject = table.Column<string>(type: "varchar(200)", nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true),
                    Controllers = table.Column<string>(type: "varchar(150)", nullable: true),
                    Actions = table.Column<string>(type: "varchar(150)", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dy = table.Column<string>(type: "varchar(500)", nullable: true),
                    Mnt = table.Column<string>(type: "varchar(20)", nullable: true),
                    Yr = table.Column<string>(type: "varchar(20)", nullable: true),
                    ReceiverID = table.Column<string>(type: "varchar(100)", nullable: true),
                    Attachement = table.Column<string>(type: "varchar(200)", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "varchar(100)", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "varchar(100)", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "varchar(100)", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "varchar(100)", nullable: true),
                    Status1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status3 = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status4 = table.Column<string>(type: "varchar(50)", nullable: true),
                    IdNo = table.Column<string>(type: "varchar(150)", nullable: true),
                    UserID = table.Column<string>(type: "varchar(150)", nullable: true),
                    UAction = table.Column<string>(type: "varchar(150)", nullable: true),
                    UController = table.Column<string>(type: "varchar(150)", nullable: true),
                    UserStatus = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Box", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CountryMaster",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Natinality = table.Column<string>(type: "text", nullable: false),
                    CountryCode = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "createschedule",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ScheduledName = table.Column<string>(type: "varchar(200)", nullable: false),
                    Department = table.Column<string>(type: "varchar(150)", nullable: false),
                    Unit = table.Column<string>(type: "varchar(150)", nullable: false),
                    ForWho = table.Column<string>(type: "varchar(500)", nullable: true),
                    Controllers = table.Column<string>(type: "varchar(50)", nullable: true),
                    Actions = table.Column<string>(type: "varchar(50)", nullable: true),
                    Description = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_createschedule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DailyMotorVehicleWorkBook",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VehicleNo = table.Column<string>(type: "varchar(50)", nullable: false),
                    TankCapacity = table.Column<string>(type: "varchar(150)", nullable: false),
                    Make = table.Column<string>(type: "varchar(150)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "varchar(50)", nullable: true),
                    TimeIn = table.Column<string>(type: "varchar(50)", nullable: false),
                    TimeOut = table.Column<string>(type: "varchar(50)", nullable: false),
                    SpeedometerOut = table.Column<string>(type: "varchar(50)", nullable: false),
                    Frm = table.Column<string>(type: "varchar(50)", nullable: false),
                    Tos = table.Column<string>(type: "varchar(50)", nullable: false),
                    SpeedometerReadsIn = table.Column<string>(type: "varchar(50)", nullable: false),
                    TotalMilesKmRun = table.Column<string>(type: "varchar(50)", nullable: false),
                    PetrolOilReceived = table.Column<string>(type: "varchar(50)", nullable: false),
                    AuthorityforJourney = table.Column<string>(type: "varchar(550)", nullable: false),
                    UserSign = table.Column<string>(type: "varchar(250)", nullable: false),
                    DriverName = table.Column<string>(type: "varchar(300)", nullable: false),
                    UserID = table.Column<string>(type: "varchar(50)", nullable: true),
                    StationName = table.Column<string>(type: "varchar(150)", nullable: true),
                    ReceiverID = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "varchar(50)", nullable: true),
                    DailyID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    Yr = table.Column<string>(type: "varchar(50)", nullable: true),
                    Mnt = table.Column<string>(type: "varchar(50)", nullable: true),
                    Day = table.Column<string>(type: "varchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyMotorVehicleWorkBook", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    DeptID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Department = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.DeptID);
                });

            migrationBuilder.CreateTable(
                name: "designation",
                columns: table => new
                {
                    DesignationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Decoration = table.Column<string>(type: "varchar(150)", nullable: false),
                    DeptID = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cadre = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_designation", x => x.DesignationID);
                });

            migrationBuilder.CreateTable(
                name: "dpq",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Dpq = table.Column<string>(type: "varchar(150)", nullable: false),
                    CheckedBy = table.Column<string>(type: "varchar(300)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    SprpNo = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    EdNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    HodNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    UnitNote = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dpq", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileDestination",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DestinationName = table.Column<string>(type: "varchar(250)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileDestination", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "itstudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    SprpNo = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<string>(type: "text", nullable: true),
                    SDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SDates = table.Column<string>(type: "text", nullable: true),
                    EDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EDates = table.Column<string>(type: "text", nullable: true),
                    NoOfDays = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    QualificationInView = table.Column<string>(type: "text", nullable: false),
                    ReceiverID = table.Column<string>(type: "text", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "text", nullable: true),
                    ConId = table.Column<string>(type: "text", nullable: true),
                    TrainingDescription = table.Column<string>(type: "text", nullable: false),
                    Yr = table.Column<string>(type: "text", nullable: true),
                    Mnt = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<string>(type: "text", nullable: true),
                    EmailID = table.Column<string>(type: "text", nullable: false),
                    PhoneNo = table.Column<string>(type: "text", nullable: false),
                    School = table.Column<string>(type: "text", nullable: false),
                    Contact = table.Column<string>(type: "text", nullable: false),
                    HighestQualification = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: false),
                    StationName = table.Column<string>(type: "text", nullable: false),
                    RefNo = table.Column<string>(type: "text", nullable: true),
                    Authorise = table.Column<string>(type: "text", nullable: true),
                    Authorisedby = table.Column<string>(type: "text", nullable: true),
                    SignFor = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Recipient = table.Column<string>(type: "text", nullable: true),
                    LStatus = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itstudent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Leaves",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    SprpNo = table.Column<string>(type: "text", nullable: true),
                    Sex = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true),
                    LeaveType = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Yr = table.Column<string>(type: "text", nullable: true),
                    Mnt = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Addresse = table.Column<string>(type: "text", nullable: true),
                    Salutation = table.Column<string>(type: "text", nullable: true),
                    NoOfDays = table.Column<string>(type: "text", nullable: true),
                    EDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    ResumeDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    GradeLevel = table.Column<string>(type: "text", nullable: true),
                    Step = table.Column<string>(type: "text", nullable: true),
                    StationName = table.Column<string>(type: "text", nullable: true),
                    ReceiverID = table.Column<string>(type: "text", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "text", nullable: true),
                    BoxId = table.Column<string>(type: "text", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    Remark1 = table.Column<string>(type: "text", nullable: true),
                    Remark2 = table.Column<string>(type: "text", nullable: true),
                    Remark3 = table.Column<string>(type: "text", nullable: true),
                    Remark4 = table.Column<string>(type: "text", nullable: true),
                    RefNo = table.Column<string>(type: "text", nullable: true),
                    Authorise = table.Column<string>(type: "text", nullable: true),
                    Authorisedby = table.Column<string>(type: "text", nullable: true),
                    SignFor = table.Column<string>(type: "text", nullable: true),
                    LStatus = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leaves", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoadUserPage",
                columns: table => new
                {
                    PageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PageName = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoadUserPage", x => x.PageID);
                });

            migrationBuilder.CreateTable(
                name: "locals",
                columns: table => new
                {
                    local_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    state_id = table.Column<int>(type: "int", nullable: false),
                    LGAOrigin = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locals", x => x.local_id);
                });

            migrationBuilder.CreateTable(
                name: "Memo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(type: "varchar(5000)", nullable: false),
                    Address = table.Column<string>(type: "varchar(500)", nullable: false),
                    ReportTitle = table.Column<string>(type: "varchar(250)", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ConId = table.Column<string>(type: "varchar(50)", nullable: true),
                    StationName = table.Column<string>(type: "varchar(150)", nullable: true),
                    UserID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Remark = table.Column<string>(type: "varchar(500)", nullable: true),
                    RefNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Recipient = table.Column<string>(type: "varchar(350)", nullable: false),
                    Nspri = table.Column<string>(type: "varchar(200)", nullable: true),
                    MemoTitle = table.Column<string>(type: "varchar(200)", nullable: true),
                    Date = table.Column<string>(type: "text", nullable: true),
                    Dates = table.Column<string>(type: "varchar(50)", nullable: true),
                    Authorise = table.Column<string>(type: "varchar(250)", nullable: true),
                    SignFor = table.Column<string>(type: "varchar(250)", nullable: true),
                    Copi = table.Column<string>(type: "varchar(250)", nullable: true),
                    Authorisedby = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinuteOfMeeting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Contents = table.Column<string>(type: "text", nullable: false),
                    MinuteNo = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    StationName = table.Column<string>(type: "text", nullable: true),
                    ReceiverID = table.Column<string>(type: "text", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "text", nullable: true),
                    MinuteID = table.Column<string>(type: "text", nullable: true),
                    BoxID = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Yr = table.Column<string>(type: "text", nullable: true),
                    Mnt = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<string>(type: "text", nullable: true),
                    MinuteTitle = table.Column<string>(type: "text", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinuteOfMeeting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MinuteRegister",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    MinuteTitle = table.Column<string>(type: "text", nullable: false),
                    Attendance = table.Column<string>(type: "text", nullable: false),
                    MinuteNo = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinuteRegister", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reportupload",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ReportFile = table.Column<string>(type: "text", nullable: true),
                    RId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportupload", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reportUploadModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ReportTitle = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    ReceiverID = table.Column<string>(type: "text", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "text", nullable: true),
                    ConId = table.Column<string>(type: "text", nullable: true),
                    RefNo = table.Column<string>(type: "text", nullable: false),
                    Recipient = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportUploadModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "reportwriting",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    ReportTitle = table.Column<string>(type: "text", nullable: false),
                    ReportFile = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    ReceiverID = table.Column<string>(type: "text", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "text", nullable: true),
                    ConId = table.Column<string>(type: "text", nullable: true),
                    StationName = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    RefNo = table.Column<string>(type: "text", nullable: true),
                    Recipient = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Authorise = table.Column<string>(type: "text", nullable: true),
                    SignFor = table.Column<string>(type: "text", nullable: true),
                    Copi = table.Column<string>(type: "text", nullable: true),
                    Authorisedby = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reportwriting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "scheduled",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StaffName = table.Column<string>(type: "text", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: true),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    Schedule = table.Column<string>(type: "text", nullable: false),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    AllocatedBy = table.Column<string>(type: "text", nullable: true),
                    ScheduledType = table.Column<string>(type: "text", nullable: false),
                    Expire = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Role = table.Column<string>(type: "text", nullable: true),
                    SectionName = table.Column<string>(type: "text", nullable: true),
                    Controllers = table.Column<string>(type: "text", nullable: true),
                    Actions = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SectionRole = table.Column<string>(type: "text", nullable: true),
                    AllocatedUserID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scheduled", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "sections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Department = table.Column<string>(type: "text", nullable: false),
                    UnitName = table.Column<string>(type: "text", nullable: false),
                    SectionName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "signatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SignFile = table.Column<string>(type: "text", nullable: false),
                    UserID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_signatures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "states",
                columns: table => new
                {
                    state_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StateOfOrigin = table.Column<string>(type: "text", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_states", x => x.state_id);
                });

            migrationBuilder.CreateTable(
                name: "station",
                columns: table => new
                {
                    StationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    StationName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_station", x => x.StationID);
                });

            migrationBuilder.CreateTable(
                name: "TopMenus",
                columns: table => new
                {
                    menuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    menuName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopMenus", x => x.menuId);
                });

            migrationBuilder.CreateTable(
                name: "unit",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UnitName = table.Column<string>(type: "text", nullable: false),
                    Department = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_unit", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleRecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VehicleNo = table.Column<string>(type: "text", nullable: false),
                    TankCapacity = table.Column<string>(type: "text", nullable: false),
                    Make = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleRecord", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Visitor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    VisitorName = table.Column<string>(type: "text", nullable: false),
                    PhoneNo = table.Column<string>(type: "text", nullable: false),
                    EmailID = table.Column<string>(type: "text", nullable: false),
                    PurposeOfVisit = table.Column<string>(type: "text", nullable: false),
                    WhoToVisit = table.Column<string>(type: "text", nullable: false),
                    DidKnow = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    TimeOfVisit = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    VisitID = table.Column<string>(type: "text", nullable: true),
                    StationName = table.Column<string>(type: "text", nullable: true),
                    ReceiverID = table.Column<string>(type: "text", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ProviderKey = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    RoleId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    LoginProvider = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Name = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "bydeaths",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateOfDeath = table.Column<DateTime>(type: "datetime", nullable: false),
                    GratuityPaidToEstate = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    WindowsPensionPaid = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    OrphansPensionPaid = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    EdNote = table.Column<string>(type: "varchar(5000)", nullable: true),
                    HodNote = table.Column<string>(type: "varchar(5000)", nullable: true),
                    UnitNote = table.Column<string>(type: "varchar(5000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bydeaths", x => x.ID);
                    table.ForeignKey(
                        name: "FK_bydeaths_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "byresignationorinvalidating",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateTerminated = table.Column<DateTime>(type: "datetime", nullable: false),
                    PensionOrContarct = table.Column<string>(type: "text", nullable: false),
                    PensionOf = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    GrantuityOf = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    ContractGratuity = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    EdNote = table.Column<string>(type: "varchar(2000)", nullable: true),
                    HodNote = table.Column<string>(type: "varchar(2000)", nullable: true),
                    UnitNote = table.Column<string>(type: "varchar(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_byresignationorinvalidating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_byresignationorinvalidating_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "bytransfers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateOfTransfer = table.Column<DateTime>(type: "datetime", nullable: false),
                    PensionOrContarct = table.Column<string>(type: "text", nullable: true),
                    AggregateServiceInNigeriaYrs = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AggregateServiceInNigeriaMos = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AggregateServiceInNigeriaDays = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AggregateSalaryInNigeria = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "varchar(50)", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    EdNote = table.Column<string>(type: "varchar(2000)", nullable: true),
                    HodNote = table.Column<string>(type: "varchar(2000)", nullable: true),
                    UnitNote = table.Column<string>(type: "varchar(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bytransfers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bytransfers_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CareerProgression",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AttachFile = table.Column<string>(type: "varchar(250)", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: false),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "varchar(50)", nullable: true),
                    Yr = table.Column<string>(type: "varchar(50)", nullable: true),
                    Mnt = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserID = table.Column<string>(type: "varchar(50)", nullable: true),
                    StationName = table.Column<string>(type: "varchar(150)", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    CareerId = table.Column<string>(type: "varchar(50)", nullable: true),
                    Surname = table.Column<string>(type: "varchar(250)", nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(250)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(250)", nullable: true),
                    DateOfFirstAppointment = table.Column<DateTime>(type: "datetime", nullable: false),
                    CurrentAppointment = table.Column<string>(type: "text", nullable: true),
                    DateofCurrentAppointment = table.Column<DateTime>(type: "datetime", nullable: false),
                    GradeLevel = table.Column<string>(type: "varchar(50)", nullable: true),
                    Step = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProposeRank = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProposeGrade = table.Column<string>(type: "varchar(50)", nullable: true),
                    ProposeStep = table.Column<string>(type: "varchar(50)", nullable: true),
                    Body = table.Column<string>(type: "varchar(5000)", nullable: true),
                    ReceiverID = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "varchar(50)", nullable: true),
                    Remark = table.Column<string>(type: "varchar(500)", nullable: true),
                    Remark1 = table.Column<string>(type: "varchar(500)", nullable: true),
                    Remark2 = table.Column<string>(type: "varchar(500)", nullable: true),
                    Remark3 = table.Column<string>(type: "varchar(500)", nullable: true),
                    Remark4 = table.Column<string>(type: "varchar(500)", nullable: true),
                    Day = table.Column<string>(type: "varchar(50)", nullable: true),
                    Department = table.Column<string>(type: "varchar(50)", nullable: true),
                    RefNo = table.Column<string>(type: "varchar(100)", nullable: true),
                    Authorise = table.Column<string>(type: "varchar(500)", nullable: true),
                    Authorisedby = table.Column<string>(type: "varchar(500)", nullable: true),
                    SignFor = table.Column<string>(type: "varchar(500)", nullable: true),
                    Address = table.Column<string>(type: "varchar(500)", nullable: true),
                    Recipient = table.Column<string>(type: "varchar(500)", nullable: true),
                    LStatus = table.Column<string>(type: "varchar(50)", nullable: true),
                    Title = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CareerProgression", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CareerProgression_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Confirmationofappointment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "varchar(200)", nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(200)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(200)", nullable: true),
                    CurrentAppointment = table.Column<string>(type: "varchar(250)", nullable: true),
                    Department = table.Column<string>(type: "varchar(150)", nullable: true),
                    DateOfFirstAppointment = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateDue = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateF = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateD = table.Column<DateTime>(type: "datetime", nullable: false),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    GradeLevel = table.Column<string>(type: "varchar(100)", nullable: true),
                    StationName = table.Column<string>(type: "varchar(150)", nullable: true),
                    Remark = table.Column<string>(type: "varchar(500)", nullable: true),
                    Dates = table.Column<string>(type: "varchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    Yr = table.Column<string>(type: "varchar(50)", nullable: true),
                    Mnt = table.Column<string>(type: "varchar(50)", nullable: true),
                    Day = table.Column<string>(type: "varchar(50)", nullable: true),
                    YrC = table.Column<string>(type: "varchar(50)", nullable: true),
                    Sex = table.Column<string>(type: "varchar(20)", nullable: true),
                    ReceiverID = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "varchar(50)", nullable: true),
                    ConId = table.Column<string>(type: "varchar(50)", nullable: true),
                    Remark1 = table.Column<string>(type: "varchar(500)", nullable: true),
                    Remark2 = table.Column<string>(type: "varchar(500)", nullable: true),
                    Remark3 = table.Column<string>(type: "varchar(500)", nullable: true),
                    Remark4 = table.Column<string>(type: "varchar(500)", nullable: true),
                    UserID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Body = table.Column<string>(type: "varchar(5000)", nullable: true),
                    RefNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Authorise = table.Column<string>(type: "varchar(500)", nullable: true),
                    Authorisedby = table.Column<string>(type: "varchar(500)", nullable: true),
                    SignFor = table.Column<string>(type: "varchar(150)", nullable: true),
                    Address = table.Column<string>(type: "varchar(500)", nullable: true),
                    Recipient = table.Column<string>(type: "varchar(200)", nullable: true),
                    LStatus = table.Column<string>(type: "varchar(50)", nullable: true),
                    Title = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Confirmationofappointment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Confirmationofappointment_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dpps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Psemployer = table.Column<string>(type: "varchar(250)", nullable: false),
                    FrmDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    FilePageRef = table.Column<string>(type: "varchar(150)", nullable: false),
                    Checkedby = table.Column<string>(type: "varchar(300)", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    EdNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    HodNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    UnitNote = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dpps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dpps_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "dsinforce",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ArmOfService = table.Column<string>(type: "varchar(250)", nullable: false),
                    ServiceNo = table.Column<string>(type: "varchar(50)", nullable: false),
                    ReasonForLeave = table.Column<string>(type: "varchar(500)", nullable: false),
                    LastUnit = table.Column<string>(type: "varchar(150)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    EdNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    HodNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    UnitNote = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dsinforce", x => x.ID);
                    table.ForeignKey(
                        name: "FK_dsinforce_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TypeOfSchool = table.Column<string>(type: "varchar(250)", nullable: false),
                    FrmDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CheckedBy = table.Column<string>(type: "varchar(500)", nullable: true),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    EdNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    HodNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    UnitNote = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_educations_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Language = table.Column<string>(type: "varchar(150)", nullable: false),
                    Spoken = table.Column<string>(type: "varchar(150)", nullable: false),
                    Written = table.Column<string>(type: "varchar(150)", nullable: true),
                    ExamQualified = table.Column<string>(type: "varchar(150)", nullable: false),
                    CheckedBy = table.Column<string>(type: "varchar(300)", nullable: true),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    EdNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    HodNote = table.Column<string>(type: "varchar(500)", nullable: true),
                    UnitNote = table.Column<string>(type: "varchar(500)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.ID);
                    table.ForeignKey(
                        name: "FK_languages_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "marragehistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MaritalStatus = table.Column<string>(type: "text", nullable: false),
                    DateOfMarriage = table.Column<DateTime>(type: "datetime", nullable: false),
                    NameOfWife = table.Column<string>(type: "text", nullable: true),
                    WifeDateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true),
                    HodNote = table.Column<string>(type: "text", nullable: true),
                    UnitNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marragehistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_marragehistory_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "monthlyreturn",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    CurrentAppointment = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true),
                    DateOfCurrentAppointment = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateDue = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateF = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateD = table.Column<DateTime>(type: "datetime", nullable: false),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    GradeLevel = table.Column<string>(type: "text", nullable: true),
                    StationName = table.Column<string>(type: "text", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Yr = table.Column<string>(type: "text", nullable: true),
                    Mnt = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<string>(type: "text", nullable: true),
                    YrC = table.Column<string>(type: "text", nullable: true),
                    Sex = table.Column<string>(type: "text", nullable: true),
                    ReceiverID = table.Column<string>(type: "text", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "text", nullable: true),
                    ConId = table.Column<string>(type: "text", nullable: true),
                    Remark1 = table.Column<string>(type: "text", nullable: true),
                    Remark2 = table.Column<string>(type: "text", nullable: true),
                    Remark3 = table.Column<string>(type: "text", nullable: true),
                    Remark4 = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    PDepartment = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    HighestQualification = table.Column<string>(type: "text", nullable: true),
                    PhoneNo = table.Column<string>(type: "text", nullable: true),
                    EmailID = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monthlyreturn", x => x.Id);
                    table.ForeignKey(
                        name: "FK_monthlyreturn_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "nextofkin",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Relationship = table.Column<string>(type: "text", nullable: false),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true),
                    HodNote = table.Column<string>(type: "text", nullable: true),
                    UnitNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nextofkin", x => x.ID);
                    table.ForeignKey(
                        name: "FK_nextofkin_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "particularofchildren",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    Sex = table.Column<string>(type: "text", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    CheckedBy = table.Column<string>(type: "text", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<string>(type: "text", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true),
                    HodNote = table.Column<string>(type: "text", nullable: true),
                    UnitNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_particularofchildren", x => x.Id);
                    table.ForeignKey(
                        name: "FK_particularofchildren_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonelFile",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    FistName = table.Column<string>(type: "text", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<string>(type: "text", nullable: true),
                    ExpDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ExpDates = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    DestinationName = table.Column<string>(type: "text", nullable: true),
                    ReceiverID = table.Column<string>(type: "text", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "text", nullable: true),
                    ConId = table.Column<string>(type: "text", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    Yr = table.Column<string>(type: "text", nullable: true),
                    Mnt = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<string>(type: "text", nullable: true),
                    StationName = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonelFile", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PersonelFile_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recordofemolument",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateOfEntery = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalaryScale = table.Column<string>(type: "text", nullable: false),
                    BasicSalaryPA = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    InducementPayPA = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    DatePaidFrm = table.Column<DateTime>(type: "datetime", nullable: false),
                    IncriminisDateM = table.Column<string>(type: "text", nullable: false),
                    IncriminisDateYr = table.Column<string>(type: "text", nullable: false),
                    Authority = table.Column<string>(type: "text", nullable: false),
                    Signature = table.Column<string>(type: "text", nullable: false),
                    NameAndStamp = table.Column<string>(type: "text", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true),
                    HodNote = table.Column<string>(type: "text", nullable: true),
                    UnitNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recordofemolument", x => x.ID);
                    table.ForeignKey(
                        name: "FK_recordofemolument_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recordofservice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateOfEntery = table.Column<DateTime>(type: "datetime", nullable: false),
                    Detail = table.Column<string>(type: "text", nullable: false),
                    Signature = table.Column<string>(type: "text", nullable: false),
                    CheckedByAndStamp = table.Column<string>(type: "text", nullable: true),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true),
                    HodNote = table.Column<string>(type: "text", nullable: true),
                    UnitNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recordofservice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_recordofservice_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "recordofsickleaves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    TypeOfLeave = table.Column<string>(type: "text", nullable: false),
                    FrmDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    NoOfDays = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    FilePageNo = table.Column<string>(type: "text", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true),
                    HodNote = table.Column<string>(type: "text", nullable: true),
                    UnitNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recordofsickleaves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recordofsickleaves_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "register",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    UserID = table.Column<string>(type: "varchar(50)", nullable: true),
                    Surname = table.Column<string>(type: "varchar(200)", nullable: true),
                    MiddleName = table.Column<string>(type: "varchar(200)", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(200)", nullable: true),
                    Status = table.Column<string>(type: "varchar(50)", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime", nullable: false),
                    DOFA = table.Column<DateTime>(type: "datetime", nullable: false),
                    DOR = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_register", x => x.ID);
                    table.ForeignKey(
                        name: "FK_register_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "retirementbiodata",
                columns: table => new
                {
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Sex = table.Column<string>(type: "text", nullable: true),
                    Decoration = table.Column<string>(type: "text", nullable: true),
                    Natinality = table.Column<string>(type: "text", nullable: true),
                    DateOfFirstAppointment = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateOfFirstArrival = table.Column<DateTime>(type: "datetime", nullable: false),
                    LGAOrigin = table.Column<string>(type: "text", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "text", nullable: true),
                    CheckBy = table.Column<string>(type: "text", nullable: true),
                    Proof = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    HomeAddress = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true),
                    GeographicalLocation = table.Column<string>(type: "text", nullable: true),
                    SubstansiveAppointment = table.Column<string>(type: "text", nullable: true),
                    DateOfAppointment = table.Column<string>(type: "text", nullable: true),
                    TermsOfEngagement = table.Column<string>(type: "text", nullable: true),
                    CurrentAppointment = table.Column<string>(type: "text", nullable: true),
                    StateOfOrigin = table.Column<string>(type: "text", nullable: true),
                    DateOfCurrentAppointment = table.Column<DateTime>(type: "datetime", nullable: false),
                    StationName = table.Column<string>(type: "text", nullable: true),
                    Carder = table.Column<string>(type: "text", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true),
                    HodNote = table.Column<string>(type: "text", nullable: true),
                    UnitNote = table.Column<string>(type: "text", nullable: true),
                    HighestQualification = table.Column<string>(type: "text", nullable: true),
                    GradeLevel = table.Column<string>(type: "text", nullable: true),
                    Step = table.Column<string>(type: "text", nullable: true),
                    TrainingStatus = table.Column<string>(type: "text", nullable: true),
                    QualificationInView = table.Column<string>(type: "text", nullable: true),
                    ProStatus = table.Column<string>(type: "text", nullable: true),
                    RStatus = table.Column<string>(type: "text", nullable: true),
                    ProYr = table.Column<string>(type: "text", nullable: true),
                    RYr = table.Column<string>(type: "text", nullable: true),
                    AppointmentStatus = table.Column<string>(type: "text", nullable: true),
                    ConfirmationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ConfirmationYr = table.Column<string>(type: "text", nullable: true),
                    DateOfRetirement = table.Column<DateTime>(type: "datetime", nullable: false),
                    IPPISNO = table.Column<string>(type: "text", nullable: true),
                    DateOfPromotion = table.Column<DateTime>(type: "datetime", nullable: false),
                    NHISNO = table.Column<string>(type: "text", nullable: true),
                    PhoneNo = table.Column<string>(type: "text", nullable: true),
                    EmailID = table.Column<string>(type: "text", nullable: true),
                    NHFNO = table.Column<string>(type: "text", nullable: true),
                    RId = table.Column<string>(type: "text", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ReceiverID = table.Column<string>(type: "text", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "text", nullable: true),
                    ConId = table.Column<string>(type: "text", nullable: true),
                    RMode = table.Column<string>(type: "text", nullable: true),
                    PFA = table.Column<string>(type: "text", nullable: true),
                    PinNo = table.Column<string>(type: "text", nullable: true),
                    RefNo = table.Column<string>(type: "text", nullable: true),
                    Authorise = table.Column<string>(type: "text", nullable: true),
                    Authorisedby = table.Column<string>(type: "text", nullable: true),
                    SignFor = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Recipient = table.Column<string>(type: "text", nullable: true),
                    LStatus = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_retirementbiodata", x => x.SprpNo);
                    table.ForeignKey(
                        name: "FK_retirementbiodata_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rofcandcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Summary = table.Column<string>(type: "text", nullable: false),
                    CompiledBy = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true),
                    HodNote = table.Column<string>(type: "text", nullable: true),
                    UnitNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rofcandcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rofcandcs_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "rofgpm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateOfPayment = table.Column<DateTime>(type: "datetime", nullable: false),
                    FrmDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Yrs = table.Column<string>(type: "text", nullable: false),
                    Mos = table.Column<string>(type: "text", nullable: false),
                    Days = table.Column<string>(type: "text", nullable: false),
                    RatePerAnum = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    AmountPaid = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FilePageRef = table.Column<string>(type: "text", nullable: false),
                    CheckedBy = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true),
                    HodNote = table.Column<string>(type: "text", nullable: true),
                    UnitNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rofgpm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_rofgpm_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "schoolcertificatehelds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    schoolcertificateheld = table.Column<string>(type: "text", nullable: false),
                    CheckedBy = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true),
                    HodNote = table.Column<string>(type: "text", nullable: true),
                    UnitNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_schoolcertificatehelds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_schoolcertificatehelds_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffPosting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    CurrentAppointment = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true),
                    DateOfFirstAppointment = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateDue = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateF = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateD = table.Column<DateTime>(type: "datetime", nullable: false),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    GradeLevel = table.Column<string>(type: "text", nullable: true),
                    StationName = table.Column<string>(type: "text", nullable: true),
                    Remark = table.Column<string>(type: "text", nullable: true),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    Yr = table.Column<string>(type: "text", nullable: true),
                    Mnt = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<string>(type: "text", nullable: true),
                    YrC = table.Column<string>(type: "text", nullable: true),
                    Sex = table.Column<string>(type: "text", nullable: true),
                    ReceiverID = table.Column<string>(type: "text", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "text", nullable: true),
                    ConId = table.Column<string>(type: "text", nullable: true),
                    Remark1 = table.Column<string>(type: "text", nullable: true),
                    Remark2 = table.Column<string>(type: "text", nullable: true),
                    Remark3 = table.Column<string>(type: "text", nullable: true),
                    Remark4 = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    PDepartment = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    HighestQualification = table.Column<string>(type: "text", nullable: true),
                    RefNo = table.Column<string>(type: "text", nullable: true),
                    Authorise = table.Column<string>(type: "text", nullable: true),
                    Authorisedby = table.Column<string>(type: "text", nullable: true),
                    SignFor = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Recipient = table.Column<string>(type: "text", nullable: true),
                    LStatus = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffPosting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffPosting_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "totalpreviousservice",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Yrs = table.Column<string>(type: "text", nullable: false),
                    Mos = table.Column<string>(type: "text", nullable: false),
                    Days = table.Column<string>(type: "text", nullable: false),
                    TotalAmountPay = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true),
                    HodNote = table.Column<string>(type: "text", nullable: true),
                    UnitNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_totalpreviousservice", x => x.ID);
                    table.ForeignKey(
                        name: "FK_totalpreviousservice_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tourandleaverecord",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    DateStarted = table.Column<DateTime>(type: "datetime", nullable: false),
                    GazetteNoticeNo = table.Column<string>(type: "text", nullable: false),
                    LengthOfTourForAge = table.Column<string>(type: "text", nullable: false),
                    DateDueForLeave = table.Column<DateTime>(type: "datetime", nullable: false),
                    DateDepartedOnLeave = table.Column<DateTime>(type: "datetime", nullable: false),
                    GazetteNoticeNumber = table.Column<string>(type: "text", nullable: false),
                    DateExtentionGranted = table.Column<DateTime>(type: "datetime", nullable: false),
                    SalaryRuleForExtention = table.Column<string>(type: "text", nullable: false),
                    DateResumedDuty = table.Column<DateTime>(type: "datetime", nullable: false),
                    PassageBySeaOrAirToUk = table.Column<string>(type: "text", nullable: false),
                    PassageBySeaOrAirFrmUk = table.Column<string>(type: "text", nullable: false),
                    ResidentMonths = table.Column<string>(type: "text", nullable: false),
                    ResidentDays = table.Column<string>(type: "text", nullable: false),
                    LeaveMonths = table.Column<string>(type: "text", nullable: false),
                    LeaveDays = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    EdNote = table.Column<string>(type: "text", nullable: true),
                    HodNote = table.Column<string>(type: "text", nullable: true),
                    UnitNote = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tourandleaverecord", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tourandleaverecord_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingAndStudy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    SprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    bioSprpNo = table.Column<string>(type: "varchar(50)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Dates = table.Column<string>(type: "text", nullable: true),
                    Time = table.Column<string>(type: "text", nullable: true),
                    SDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    SDates = table.Column<string>(type: "text", nullable: true),
                    EDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EDates = table.Column<string>(type: "text", nullable: true),
                    NoOfDays = table.Column<string>(type: "text", nullable: true),
                    UserID = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: true),
                    QualificationInView = table.Column<string>(type: "text", nullable: true),
                    ReceiverID = table.Column<string>(type: "text", nullable: true),
                    ReceiverID1 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID2 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID3 = table.Column<string>(type: "text", nullable: true),
                    ReceiverID4 = table.Column<string>(type: "text", nullable: true),
                    ConId = table.Column<string>(type: "text", nullable: true),
                    TrainingDescription = table.Column<string>(type: "text", nullable: true),
                    Yr = table.Column<string>(type: "text", nullable: true),
                    Mnt = table.Column<string>(type: "text", nullable: true),
                    Day = table.Column<string>(type: "text", nullable: true),
                    StationName = table.Column<string>(type: "text", nullable: true),
                    Department = table.Column<string>(type: "text", nullable: true),
                    GradeLevel = table.Column<string>(type: "text", nullable: true),
                    Step = table.Column<string>(type: "text", nullable: true),
                    HighestQualification = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: true),
                    RefNo = table.Column<string>(type: "text", nullable: true),
                    Authorise = table.Column<string>(type: "text", nullable: true),
                    Authorisedby = table.Column<string>(type: "text", nullable: true),
                    SignFor = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Recipient = table.Column<string>(type: "text", nullable: true),
                    LStatus = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingAndStudy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingAndStudy_biodata_bioSprpNo",
                        column: x => x.bioSprpNo,
                        principalTable: "biodata",
                        principalColumn: "SprpNo",
                        onDelete: ReferentialAction.Restrict);
                });

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
                name: "IX_bydeaths_bioSprpNo",
                table: "bydeaths",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_byresignationorinvalidating_bioSprpNo",
                table: "byresignationorinvalidating",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_bytransfers_bioSprpNo",
                table: "bytransfers",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_CareerProgression_bioSprpNo",
                table: "CareerProgression",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_Confirmationofappointment_bioSprpNo",
                table: "Confirmationofappointment",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_dpps_bioSprpNo",
                table: "dpps",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_dsinforce_bioSprpNo",
                table: "dsinforce",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_educations_bioSprpNo",
                table: "educations",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_languages_bioSprpNo",
                table: "languages",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_marragehistory_bioSprpNo",
                table: "marragehistory",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_monthlyreturn_bioSprpNo",
                table: "monthlyreturn",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_nextofkin_bioSprpNo",
                table: "nextofkin",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_particularofchildren_bioSprpNo",
                table: "particularofchildren",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_PersonelFile_bioSprpNo",
                table: "PersonelFile",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_recordofemolument_bioSprpNo",
                table: "recordofemolument",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_recordofservice_bioSprpNo",
                table: "recordofservice",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_recordofsickleaves_bioSprpNo",
                table: "recordofsickleaves",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_register_bioSprpNo",
                table: "register",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_retirementbiodata_bioSprpNo",
                table: "retirementbiodata",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_rofcandcs_bioSprpNo",
                table: "rofcandcs",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_rofgpm_bioSprpNo",
                table: "rofgpm",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_schoolcertificatehelds_bioSprpNo",
                table: "schoolcertificatehelds",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_StaffPosting_bioSprpNo",
                table: "StaffPosting",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_totalpreviousservice_bioSprpNo",
                table: "totalpreviousservice",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_tourandleaverecord_bioSprpNo",
                table: "tourandleaverecord",
                column: "bioSprpNo");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingAndStudy_bioSprpNo",
                table: "TrainingAndStudy",
                column: "bioSprpNo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "biodataViewModel");

            migrationBuilder.DropTable(
                name: "Box");

            migrationBuilder.DropTable(
                name: "bydeaths");

            migrationBuilder.DropTable(
                name: "byresignationorinvalidating");

            migrationBuilder.DropTable(
                name: "bytransfers");

            migrationBuilder.DropTable(
                name: "CareerProgression");

            migrationBuilder.DropTable(
                name: "Confirmationofappointment");

            migrationBuilder.DropTable(
                name: "CountryMaster");

            migrationBuilder.DropTable(
                name: "createschedule");

            migrationBuilder.DropTable(
                name: "DailyMotorVehicleWorkBook");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "designation");

            migrationBuilder.DropTable(
                name: "dpps");

            migrationBuilder.DropTable(
                name: "dpq");

            migrationBuilder.DropTable(
                name: "dsinforce");

            migrationBuilder.DropTable(
                name: "educations");

            migrationBuilder.DropTable(
                name: "FileDestination");

            migrationBuilder.DropTable(
                name: "itstudent");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "Leaves");

            migrationBuilder.DropTable(
                name: "LoadUserPage");

            migrationBuilder.DropTable(
                name: "locals");

            migrationBuilder.DropTable(
                name: "marragehistory");

            migrationBuilder.DropTable(
                name: "Memo");

            migrationBuilder.DropTable(
                name: "MinuteOfMeeting");

            migrationBuilder.DropTable(
                name: "MinuteRegister");

            migrationBuilder.DropTable(
                name: "monthlyreturn");

            migrationBuilder.DropTable(
                name: "nextofkin");

            migrationBuilder.DropTable(
                name: "particularofchildren");

            migrationBuilder.DropTable(
                name: "PersonelFile");

            migrationBuilder.DropTable(
                name: "recordofemolument");

            migrationBuilder.DropTable(
                name: "recordofservice");

            migrationBuilder.DropTable(
                name: "recordofsickleaves");

            migrationBuilder.DropTable(
                name: "register");

            migrationBuilder.DropTable(
                name: "reportupload");

            migrationBuilder.DropTable(
                name: "reportUploadModel");

            migrationBuilder.DropTable(
                name: "reportwriting");

            migrationBuilder.DropTable(
                name: "retirementbiodata");

            migrationBuilder.DropTable(
                name: "rofcandcs");

            migrationBuilder.DropTable(
                name: "rofgpm");

            migrationBuilder.DropTable(
                name: "scheduled");

            migrationBuilder.DropTable(
                name: "schoolcertificatehelds");

            migrationBuilder.DropTable(
                name: "sections");

            migrationBuilder.DropTable(
                name: "signatures");

            migrationBuilder.DropTable(
                name: "StaffPosting");

            migrationBuilder.DropTable(
                name: "states");

            migrationBuilder.DropTable(
                name: "station");

            migrationBuilder.DropTable(
                name: "TopMenus");

            migrationBuilder.DropTable(
                name: "totalpreviousservice");

            migrationBuilder.DropTable(
                name: "tourandleaverecord");

            migrationBuilder.DropTable(
                name: "TrainingAndStudy");

            migrationBuilder.DropTable(
                name: "unit");

            migrationBuilder.DropTable(
                name: "VehicleRecord");

            migrationBuilder.DropTable(
                name: "Visitor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "biodata");
        }
    }
}
