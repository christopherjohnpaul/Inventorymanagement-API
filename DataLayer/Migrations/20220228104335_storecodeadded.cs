using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class storecodeadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "StoreInfo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "StoreInfo");

            migrationBuilder.UpdateData(
                table: "Location",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(6786));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 64, DateTimeKind.Local).AddTicks(1226));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 65, DateTimeKind.Local).AddTicks(6876));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 65, DateTimeKind.Local).AddTicks(7118));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 65, DateTimeKind.Local).AddTicks(7154));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 65, DateTimeKind.Local).AddTicks(7180));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "UserInfo",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 65, DateTimeKind.Local).AddTicks(9796));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(577));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(582));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(586));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(591));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(2681));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(2694));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2022, 2, 27, 19, 39, 45, 66, DateTimeKind.Local).AddTicks(2699));
        }
    }
}
