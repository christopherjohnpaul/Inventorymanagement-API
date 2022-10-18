using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class storegroupsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreDriverMapping",
                schema: "Mapping");

            migrationBuilder.CreateTable(
                name: "StoreGroupDriverMapping",
                schema: "Mapping",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DriverId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreGroupDriverMapping", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StoreGroupStoreMapping",
                schema: "Mapping",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreGroupId = table.Column<long>(type: "bigint", nullable: false),
                    StoreId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreGroupStoreMapping", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Location",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 647, DateTimeKind.Local).AddTicks(7539));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 644, DateTimeKind.Local).AddTicks(9378));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 646, DateTimeKind.Local).AddTicks(9350));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 646, DateTimeKind.Local).AddTicks(9614));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 646, DateTimeKind.Local).AddTicks(9674));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 646, DateTimeKind.Local).AddTicks(9711));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "UserInfo",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 647, DateTimeKind.Local).AddTicks(2620));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 647, DateTimeKind.Local).AddTicks(3605));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 647, DateTimeKind.Local).AddTicks(3615));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 647, DateTimeKind.Local).AddTicks(3619));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 647, DateTimeKind.Local).AddTicks(3622));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 647, DateTimeKind.Local).AddTicks(3625));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 647, DateTimeKind.Local).AddTicks(4731));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 647, DateTimeKind.Local).AddTicks(4741));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 3, 16, 36, 7, 647, DateTimeKind.Local).AddTicks(4745));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreGroupDriverMapping",
                schema: "Mapping");

            migrationBuilder.DropTable(
                name: "StoreGroupStoreMapping",
                schema: "Mapping");

            migrationBuilder.CreateTable(
                name: "StoreDriverMapping",
                schema: "Mapping",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedBy = table.Column<long>(type: "bigint", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StoreId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreDriverMapping", x => x.ID);
                });

            migrationBuilder.UpdateData(
                table: "Location",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 694, DateTimeKind.Local).AddTicks(4915));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 695, DateTimeKind.Local).AddTicks(9968));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(233));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(302));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(333));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "UserInfo",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(3822));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(3831));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(3835));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(3841));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(4818));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(4826));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 28, 16, 13, 34, 696, DateTimeKind.Local).AddTicks(4830));

            migrationBuilder.CreateIndex(
                name: "IX_StoreDriverMapping_StoreId_DriverId",
                schema: "Mapping",
                table: "StoreDriverMapping",
                columns: new[] { "StoreId", "DriverId" },
                unique: true);
        }
    }
}
