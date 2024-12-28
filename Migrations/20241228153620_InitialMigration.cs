using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TylorShop.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DashboardData",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SynchronizeTitle = table.Column<bool>(type: "bit", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashboardData", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "FileData",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    size = table.Column<int>(type: "int", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(260)", maxLength: 260, nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileData", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "ModelDifference",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContextId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Version = table.Column<int>(type: "int", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDifference", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "ReportDataV2",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ObjectTypeName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    Content = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ParametersObjectTypeName = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    IsInplaceReport = table.Column<bool>(type: "bit", nullable: true),
                    PredefinedReportType = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDataV2", x => x.Oid);
                });

            migrationBuilder.CreateTable(
                name: "XPObjectType",
                columns: table => new
                {
                    OID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    AssemblyName = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XPObjectType", x => x.OID);
                });

            migrationBuilder.CreateTable(
                name: "ModelDifferenceAspect",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Xml = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModelDifferenceAspect", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_ModelDifferenceAspect_Owner",
                        column: x => x.Owner,
                        principalTable: "ModelDifference",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyRole",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsAdministrative = table.Column<bool>(type: "bit", nullable: true),
                    CanEditModel = table.Column<bool>(type: "bit", nullable: true),
                    PermissionPolicy = table.Column<int>(type: "int", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true),
                    ObjectType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyRole", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyRole_ObjectType",
                        column: x => x.ObjectType,
                        principalTable: "XPObjectType",
                        principalColumn: "OID");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyUser",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StoredPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangePasswordOnFirstLogon = table.Column<bool>(type: "bit", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true),
                    ObjectType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyUser", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyUser_ObjectType",
                        column: x => x.ObjectType,
                        principalTable: "XPObjectType",
                        principalColumn: "OID");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyNavigationPermissionsObject",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NavigateState = table.Column<int>(type: "int", nullable: true),
                    Role = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyNavigationPermissionsObject", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyNavigationPermissionsObject_Role",
                        column: x => x.Role,
                        principalTable: "PermissionPolicyRole",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyTypePermissionsObject",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TargetType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadState = table.Column<int>(type: "int", nullable: true),
                    WriteState = table.Column<int>(type: "int", nullable: true),
                    CreateState = table.Column<int>(type: "int", nullable: true),
                    DeleteState = table.Column<int>(type: "int", nullable: true),
                    NavigateState = table.Column<int>(type: "int", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyTypePermissionsObject", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyTypePermissionsObject_Role",
                        column: x => x.Role,
                        principalTable: "PermissionPolicyRole",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeMaster",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PermanentAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HireDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeMaster", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_EmployeeMaster_Oid",
                        column: x => x.Oid,
                        principalTable: "PermissionPolicyUser",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyUserUsers_PermissionPolicyRoleRoles",
                columns: table => new
                {
                    OID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Roles = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Users = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyUserUsers_PermissionPolicyRoleRoles", x => x.OID);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyUserUsers_PermissionPolicyRoleRoles_Roles",
                        column: x => x.Roles,
                        principalTable: "PermissionPolicyRole",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_PermissionPolicyUserUsers_PermissionPolicyRoleRoles_Users",
                        column: x => x.Users,
                        principalTable: "PermissionPolicyUser",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyMemberPermissionsObject",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Members = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadState = table.Column<int>(type: "int", nullable: true),
                    WriteState = table.Column<int>(type: "int", nullable: true),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TypePermissionObject = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyMemberPermissionsObject", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyMemberPermissionsObject_TypePermissionObject",
                        column: x => x.TypePermissionObject,
                        principalTable: "PermissionPolicyTypePermissionsObject",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "PermissionPolicyObjectPermissionsObject",
                columns: table => new
                {
                    Oid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Criteria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadState = table.Column<int>(type: "int", nullable: true),
                    WriteState = table.Column<int>(type: "int", nullable: true),
                    DeleteState = table.Column<int>(type: "int", nullable: true),
                    NavigateState = table.Column<int>(type: "int", nullable: true),
                    TypePermissionObject = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionPolicyObjectPermissionsObject", x => x.Oid);
                    table.ForeignKey(
                        name: "FK_PermissionPolicyObjectPermissionsObject_TypePermissionObject",
                        column: x => x.TypePermissionObject,
                        principalTable: "PermissionPolicyTypePermissionsObject",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "Accounting",
                columns: table => new
                {
                    OID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    AccountingType = table.Column<int>(type: "int", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounting", x => x.OID);
                    table.ForeignKey(
                        name: "FK_Accounting_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_Accounting_Owner",
                        column: x => x.Owner,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_Accounting_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "CustomerInfo",
                columns: table => new
                {
                    OID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Age = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Lomba = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Body = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Pet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Put = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Hat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gola = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LuzHata = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerInfo", x => x.OID);
                    table.ForeignKey(
                        name: "FK_CustomerInfo_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_CustomerInfo_Owner",
                        column: x => x.Owner,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_CustomerInfo_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "CustomSetup",
                columns: table => new
                {
                    OID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Setup = table.Column<int>(type: "int", nullable: true),
                    ShowPrintPreview = table.Column<bool>(type: "bit", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomSetup", x => x.OID);
                    table.ForeignKey(
                        name: "FK_CustomSetup_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_CustomSetup_Owner",
                        column: x => x.Owner,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_CustomSetup_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "Denial",
                columns: table => new
                {
                    OID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ClientName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ExpireDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Denial", x => x.OID);
                    table.ForeignKey(
                        name: "FK_Denial_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_Denial_Owner",
                        column: x => x.Owner,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_Denial_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "PrimativeDataCenter",
                columns: table => new
                {
                    OID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    ActiovationDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DanialString = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    DanialKString = table.Column<string>(type: "varchar(256)", unicode: false, maxLength: 256, nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimativeDataCenter", x => x.OID);
                    table.ForeignKey(
                        name: "FK_PrimativeDataCenter_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_PrimativeDataCenter_Owner",
                        column: x => x.Owner,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_PrimativeDataCenter_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "OrderTaking",
                columns: table => new
                {
                    OID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Customer = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DelevaryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscriptionPant = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscriptionKamiz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EkChata = table.Column<int>(type: "int", nullable: true),
                    EkCharaJubba = table.Column<int>(type: "int", nullable: true),
                    Kabli = table.Column<int>(type: "int", nullable: true),
                    Serwani = table.Column<int>(type: "int", nullable: true),
                    Fotua = table.Column<int>(type: "int", nullable: true),
                    JubbaKalidar = table.Column<int>(type: "int", nullable: true),
                    Shart = table.Column<int>(type: "int", nullable: true),
                    Borka = table.Column<int>(type: "int", nullable: true),
                    Koti = table.Column<int>(type: "int", nullable: true),
                    Kalider = table.Column<int>(type: "int", nullable: true),
                    Aligori = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Lomba = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Body = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Pet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Put = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Hat = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gola = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    LuzHata = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Kolar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Plet = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Hata = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Nic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NocShohoFara = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NicThekeFara = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PocketThekeBondo = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Pocket = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Paipen = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Selwar = table.Column<int>(type: "int", nullable: true),
                    Cosh = table.Column<int>(type: "int", nullable: true),
                    Curidar = table.Column<int>(type: "int", nullable: true),
                    Naro = table.Column<int>(type: "int", nullable: true),
                    Pant = table.Column<int>(type: "int", nullable: true),
                    PantPocket = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CouraRabar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CikonRabar = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MobilePocket = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    IsReady = table.Column<bool>(type: "bit", nullable: true),
                    IsDelevered = table.Column<bool>(type: "bit", nullable: true),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: true),
                    Discount = table.Column<double>(type: "float", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTaking", x => x.OID);
                    table.ForeignKey(
                        name: "FK_OrderTaking_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_OrderTaking_Customer",
                        column: x => x.Customer,
                        principalTable: "CustomerInfo",
                        principalColumn: "OID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderTaking_Owner",
                        column: x => x.Owner,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_OrderTaking_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateTable(
                name: "OrderTransactions",
                columns: table => new
                {
                    OID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Owner = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    TransactionType = table.Column<int>(type: "int", nullable: true),
                    OptimisticLockField = table.Column<int>(type: "int", nullable: true),
                    GCRecord = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTransactions", x => x.OID);
                    table.ForeignKey(
                        name: "FK_OrderTransactions_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_OrderTransactions_Order",
                        column: x => x.Order,
                        principalTable: "OrderTaking",
                        principalColumn: "OID");
                    table.ForeignKey(
                        name: "FK_OrderTransactions_Owner",
                        column: x => x.Owner,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                    table.ForeignKey(
                        name: "FK_OrderTransactions_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "EmployeeMaster",
                        principalColumn: "Oid");
                });

            migrationBuilder.CreateIndex(
                name: "iCreatedBy_Accounting",
                table: "Accounting",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_Accounting",
                table: "Accounting",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iOwner_Accounting",
                table: "Accounting",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "iUpdatedBy_Accounting",
                table: "Accounting",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "iCreatedBy_CustomerInfo",
                table: "CustomerInfo",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_CustomerInfo",
                table: "CustomerInfo",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iOwner_CustomerInfo",
                table: "CustomerInfo",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "iUpdatedBy_CustomerInfo",
                table: "CustomerInfo",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "iCreatedBy_CustomSetup",
                table: "CustomSetup",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_CustomSetup",
                table: "CustomSetup",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iOwner_CustomSetup",
                table: "CustomSetup",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "iUpdatedBy_CustomSetup",
                table: "CustomSetup",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_DashboardData",
                table: "DashboardData",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iCreatedBy_Denial",
                table: "Denial",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_Denial",
                table: "Denial",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iOwner_Denial",
                table: "Denial",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "iUpdatedBy_Denial",
                table: "Denial",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_FileData",
                table: "FileData",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_ModelDifference",
                table: "ModelDifference",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_ModelDifferenceAspect",
                table: "ModelDifferenceAspect",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iOwner_ModelDifferenceAspect",
                table: "ModelDifferenceAspect",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "iCreatedBy_OrderTaking",
                table: "OrderTaking",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "iCustomer_OrderTaking",
                table: "OrderTaking",
                column: "Customer");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_OrderTaking",
                table: "OrderTaking",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iOwner_OrderTaking",
                table: "OrderTaking",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "iUpdatedBy_OrderTaking",
                table: "OrderTaking",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "iCreatedBy_OrderTransactions",
                table: "OrderTransactions",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_OrderTransactions",
                table: "OrderTransactions",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iOrder_OrderTransactions",
                table: "OrderTransactions",
                column: "Order");

            migrationBuilder.CreateIndex(
                name: "iOwner_OrderTransactions",
                table: "OrderTransactions",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "iUpdatedBy_OrderTransactions",
                table: "OrderTransactions",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_PermissionPolicyMemberPermissionsObject",
                table: "PermissionPolicyMemberPermissionsObject",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iTypePermissionObject_PermissionPolicyMemberPermissionsObject",
                table: "PermissionPolicyMemberPermissionsObject",
                column: "TypePermissionObject");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_PermissionPolicyNavigationPermissionsObject",
                table: "PermissionPolicyNavigationPermissionsObject",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iRole_PermissionPolicyNavigationPermissionsObject",
                table: "PermissionPolicyNavigationPermissionsObject",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_PermissionPolicyObjectPermissionsObject",
                table: "PermissionPolicyObjectPermissionsObject",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iTypePermissionObject_PermissionPolicyObjectPermissionsObject",
                table: "PermissionPolicyObjectPermissionsObject",
                column: "TypePermissionObject");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_PermissionPolicyRole",
                table: "PermissionPolicyRole",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iObjectType_PermissionPolicyRole",
                table: "PermissionPolicyRole",
                column: "ObjectType");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_PermissionPolicyTypePermissionsObject",
                table: "PermissionPolicyTypePermissionsObject",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iRole_PermissionPolicyTypePermissionsObject",
                table: "PermissionPolicyTypePermissionsObject",
                column: "Role");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_PermissionPolicyUser",
                table: "PermissionPolicyUser",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iObjectType_PermissionPolicyUser",
                table: "PermissionPolicyUser",
                column: "ObjectType");

            migrationBuilder.CreateIndex(
                name: "iRoles_PermissionPolicyUserUsers_PermissionPolicyRoleRoles",
                table: "PermissionPolicyUserUsers_PermissionPolicyRoleRoles",
                column: "Roles");

            migrationBuilder.CreateIndex(
                name: "iRolesUsers_PermissionPolicyUserUsers_PermissionPolicyRoleRoles",
                table: "PermissionPolicyUserUsers_PermissionPolicyRoleRoles",
                columns: new[] { "Roles", "Users" },
                unique: true,
                filter: "[Roles] IS NOT NULL AND [Users] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "iUsers_PermissionPolicyUserUsers_PermissionPolicyRoleRoles",
                table: "PermissionPolicyUserUsers_PermissionPolicyRoleRoles",
                column: "Users");

            migrationBuilder.CreateIndex(
                name: "iCreatedBy_PrimativeDataCenter",
                table: "PrimativeDataCenter",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_PrimativeDataCenter",
                table: "PrimativeDataCenter",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iOwner_PrimativeDataCenter",
                table: "PrimativeDataCenter",
                column: "Owner");

            migrationBuilder.CreateIndex(
                name: "iUpdatedBy_PrimativeDataCenter",
                table: "PrimativeDataCenter",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "iGCRecord_ReportDataV2",
                table: "ReportDataV2",
                column: "GCRecord");

            migrationBuilder.CreateIndex(
                name: "iTypeName_XPObjectType",
                table: "XPObjectType",
                column: "TypeName",
                unique: true,
                filter: "[TypeName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounting");

            migrationBuilder.DropTable(
                name: "CustomSetup");

            migrationBuilder.DropTable(
                name: "DashboardData");

            migrationBuilder.DropTable(
                name: "Denial");

            migrationBuilder.DropTable(
                name: "FileData");

            migrationBuilder.DropTable(
                name: "ModelDifferenceAspect");

            migrationBuilder.DropTable(
                name: "OrderTransactions");

            migrationBuilder.DropTable(
                name: "PermissionPolicyMemberPermissionsObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyNavigationPermissionsObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyObjectPermissionsObject");

            migrationBuilder.DropTable(
                name: "PermissionPolicyUserUsers_PermissionPolicyRoleRoles");

            migrationBuilder.DropTable(
                name: "PrimativeDataCenter");

            migrationBuilder.DropTable(
                name: "ReportDataV2");

            migrationBuilder.DropTable(
                name: "ModelDifference");

            migrationBuilder.DropTable(
                name: "OrderTaking");

            migrationBuilder.DropTable(
                name: "PermissionPolicyTypePermissionsObject");

            migrationBuilder.DropTable(
                name: "CustomerInfo");

            migrationBuilder.DropTable(
                name: "PermissionPolicyRole");

            migrationBuilder.DropTable(
                name: "EmployeeMaster");

            migrationBuilder.DropTable(
                name: "PermissionPolicyUser");

            migrationBuilder.DropTable(
                name: "XPObjectType");
        }
    }
}
