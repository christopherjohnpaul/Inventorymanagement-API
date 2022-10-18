using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Mapping");

            migrationBuilder.EnsureSchema(
                name: "Admin");

            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Mapping",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryCustomer",
                schema: "Mapping",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CustomerMasterId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryCustomer", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProduct",
                schema: "Mapping",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    ArticleNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProduct", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CategoryStore",
                schema: "Mapping",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    StoreId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryStore", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "Admin",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    LocationId = table.Column<long>(type: "bigint", maxLength: 60, nullable: false),
                    ContactTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContactType",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerMaster",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CustomerTypeId = table.Column<long>(type: "bigint", nullable: false),
                    IndividualPrice = table.Column<bool>(type: "bit", nullable: false),
                    PriceLevel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMaster", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CustomerType",
                schema: "Lookup",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Excemptions",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTemplateId = table.Column<long>(type: "bigint", nullable: false),
                    MultiplyOders = table.Column<double>(type: "float", nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Excemptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Suburb = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressLine1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AddressLine2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderTemplateId = table.Column<long>(type: "bigint", nullable: false),
                    DriverId = table.Column<long>(type: "bigint", nullable: false),
                    IsOrderFinalized = table.Column<bool>(type: "bit", nullable: false),
                    IsSupplierMailSent = table.Column<bool>(type: "bit", nullable: false),
                    SupplierMailSentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRunGenarated = table.Column<bool>(type: "bit", nullable: false),
                    TimeOfDelivery = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                schema: "Mapping",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    SalesDay = table.Column<int>(type: "int", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<long>(type: "bigint", nullable: false),
                    TemplateId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderTemplate",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RegionId = table.Column<long>(type: "bigint", nullable: false),
                    DriverId = table.Column<long>(type: "bigint", nullable: false),
                    TimeOfDelivery = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    DeactivateExcemptions = table.Column<bool>(type: "bit", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTemplate", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "OrderTemplateProducts",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderTemplateId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<double>(type: "float", nullable: false),
                    SalesDay = table.Column<int>(type: "int", nullable: false),
                    SequenceNumber = table.Column<int>(type: "int", nullable: false),
                    StoreId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTemplateProducts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductCustomerUnitPrice",
                schema: "Mapping",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerMasterId = table.Column<long>(type: "bigint", nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    EffectiveFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveTillDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCustomerUnitPrice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductInformation",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    QuantityPerCrate = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInformation", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ProductSupplierUnitPrice",
                schema: "Mapping",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    SupplierId = table.Column<long>(type: "bigint", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    EffectiveFromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EffectiveTillDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSupplierUnitPrice", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "RunLevel",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RunNumber = table.Column<int>(type: "int", nullable: false),
                    DriverId = table.Column<long>(type: "bigint", nullable: false),
                    OrderProductId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunLevel", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StoreDriverMapping",
                schema: "Mapping",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriverId = table.Column<long>(type: "bigint", nullable: false),
                    StoreId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreDriverMapping", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StoreInfo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StoreProduct",
                schema: "Mapping",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProductId = table.Column<long>(type: "bigint", nullable: false),
                    StoreId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreProduct", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactId = table.Column<long>(type: "bigint", nullable: false),
                    GenerateOrderEmail = table.Column<bool>(type: "bit", nullable: false),
                    ApplyException = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserInfo",
                schema: "Admin",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactId = table.Column<long>(type: "bigint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsLoginEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInfo", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Location",
                columns: new[] { "ID", "AddressLine1", "AddressLine2", "CreatedBy", "CreatedDate", "IsActive", "Latitude", "Longitude", "ModifiedBy", "ModifiedDate", "PostalCode", "State", "Suburb" },
                values: new object[] { 1L, "Default", "Default", 0L, new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(6786), true, "Default", "default", null, null, "000000", "NSW", "Default" });

            migrationBuilder.InsertData(
                schema: "Admin",
                table: "Contact",
                columns: new[] { "ID", "ContactTypeId", "CreatedBy", "CreatedDate", "Email", "FirstName", "IsActive", "LastName", "LocationId", "MobileNumber", "ModifiedBy", "ModifiedDate" },
                values: new object[,]
                {
                    { 1L, 4L, 0L, new DateTime(2022, 2, 27, 19, 39, 45, 64, DateTimeKind.Local).AddTicks(1226), "admin.inventoryManagement@gmail.com", "Admin", true, "Admin", 1L, "0000000000", null, null },
                    { 2L, 1L, 0L, new DateTime(2022, 2, 27, 19, 39, 45, 65, DateTimeKind.Local).AddTicks(6876), "", "No Contact", true, "", 1L, "0000000000", null, null },
                    { 3L, 2L, 0L, new DateTime(2022, 2, 27, 19, 39, 45, 65, DateTimeKind.Local).AddTicks(7118), "", "No Contact", true, "", 1L, "0000000000", null, null },
                    { 4L, 3L, 0L, new DateTime(2022, 2, 27, 19, 39, 45, 65, DateTimeKind.Local).AddTicks(7154), "", "No Contact", true, "", 1L, "0000000000", null, null },
                    { 5L, 5L, 0L, new DateTime(2022, 2, 27, 19, 39, 45, 65, DateTimeKind.Local).AddTicks(7180), "", "No Contact", true, "", 1L, "0000000000", null, null }
                });

            migrationBuilder.InsertData(
                schema: "Admin",
                table: "UserInfo",
                columns: new[] { "ID", "ContactId", "CreatedBy", "CreatedDate", "IsActive", "IsLoginEnabled", "ModifiedBy", "ModifiedDate", "Password", "UserName" },
                values: new object[] { 1L, 1L, 0L, new DateTime(2022, 2, 27, 19, 39, 45, 65, DateTimeKind.Local).AddTicks(9796), true, true, null, null, "inventoryManagementps", "admin.inventoryManagement@gmail.com" });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "ContactType",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "IsActive", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(564), true, null, null, "Supplier" },
                    { 2L, 1L, new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(577), true, null, null, "Customer" },
                    { 3L, 1L, new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(582), true, null, null, "Driver" },
                    { 4L, 1L, new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(586), true, null, null, "Admin" },
                    { 5L, 1L, new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(591), true, null, null, "Store" }
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "CustomerType",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "IsActive", "ModifiedBy", "ModifiedDate", "Name" },
                values: new object[,]
                {
                    { 1L, 1L, new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(2681), true, null, null, "Individual" },
                    { 2L, 1L, new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(2694), true, null, null, "SuperMarket" },
                    { 3L, 1L, new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(2699), true, null, null, "CafeChain" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_Name",
                schema: "Mapping",
                table: "Category",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryCustomer_CategoryId_CustomerMasterId",
                schema: "Mapping",
                table: "CategoryCustomer",
                columns: new[] { "CategoryId", "CustomerMasterId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProduct_CategoryId_ProductId",
                schema: "Mapping",
                table: "CategoryProduct",
                columns: new[] { "CategoryId", "ProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryStore_CategoryId_StoreId",
                schema: "Mapping",
                table: "CategoryStore",
                columns: new[] { "CategoryId", "StoreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_FirstName_LastName_Email_MobileNumber_ContactTypeId",
                schema: "Admin",
                table: "Contact",
                columns: new[] { "FirstName", "LastName", "Email", "MobileNumber", "ContactTypeId" },
                unique: true,
                filter: "[LastName] IS NOT NULL AND [Email] IS NOT NULL AND [MobileNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId_TemplateId_ProductId_StoreId_SupplierId",
                schema: "Mapping",
                table: "OrderProducts",
                columns: new[] { "OrderId", "TemplateId", "ProductId", "StoreId", "SupplierId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderTemplateProducts_OrderTemplateId_ProductId_StoreId_SupplierId",
                table: "OrderTemplateProducts",
                columns: new[] { "OrderTemplateId", "ProductId", "StoreId", "SupplierId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInformation_Name",
                table: "ProductInformation",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductSupplierUnitPrice_SupplierId_ProductId_EffectiveFromDate_EffectiveTillDate",
                schema: "Mapping",
                table: "ProductSupplierUnitPrice",
                columns: new[] { "SupplierId", "ProductId", "EffectiveFromDate", "EffectiveTillDate" },
                unique: true,
                filter: "[EffectiveTillDate] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RunLevel_DriverId_OrderProductId",
                table: "RunLevel",
                columns: new[] { "DriverId", "OrderProductId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreDriverMapping_StoreId_DriverId",
                schema: "Mapping",
                table: "StoreDriverMapping",
                columns: new[] { "StoreId", "DriverId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_UserName",
                schema: "Admin",
                table: "UserInfo",
                column: "UserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category",
                schema: "Mapping");

            migrationBuilder.DropTable(
                name: "CategoryCustomer",
                schema: "Mapping");

            migrationBuilder.DropTable(
                name: "CategoryProduct",
                schema: "Mapping");

            migrationBuilder.DropTable(
                name: "CategoryStore",
                schema: "Mapping");

            migrationBuilder.DropTable(
                name: "Contact",
                schema: "Admin");

            migrationBuilder.DropTable(
                name: "ContactType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "CustomerMaster");

            migrationBuilder.DropTable(
                name: "CustomerType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Excemptions");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderProducts",
                schema: "Mapping");

            migrationBuilder.DropTable(
                name: "OrderTemplate");

            migrationBuilder.DropTable(
                name: "OrderTemplateProducts");

            migrationBuilder.DropTable(
                name: "ProductCustomerUnitPrice",
                schema: "Mapping");

            migrationBuilder.DropTable(
                name: "ProductInformation");

            migrationBuilder.DropTable(
                name: "ProductSupplierUnitPrice",
                schema: "Mapping");

            migrationBuilder.DropTable(
                name: "Region");

            migrationBuilder.DropTable(
                name: "RunLevel");

            migrationBuilder.DropTable(
                name: "StoreDriverMapping",
                schema: "Mapping");

            migrationBuilder.DropTable(
                name: "StoreInfo");

            migrationBuilder.DropTable(
                name: "StoreProduct",
                schema: "Mapping");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "UserInfo",
                schema: "Admin");
        }
    }
}
