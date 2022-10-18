using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataLayer.Migrations
{
    public partial class uniquekeyaddedfordrivermapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Location",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 419, DateTimeKind.Local).AddTicks(6038));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 416, DateTimeKind.Local).AddTicks(6787));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 418, DateTimeKind.Local).AddTicks(3330));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 418, DateTimeKind.Local).AddTicks(3640));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 418, DateTimeKind.Local).AddTicks(3723));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "Contact",
                keyColumn: "ID",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 418, DateTimeKind.Local).AddTicks(3870));

            migrationBuilder.UpdateData(
                schema: "Admin",
                table: "UserInfo",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 418, DateTimeKind.Local).AddTicks(8160));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 418, DateTimeKind.Local).AddTicks(9566));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 418, DateTimeKind.Local).AddTicks(9581));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 418, DateTimeKind.Local).AddTicks(9587));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 4L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 418, DateTimeKind.Local).AddTicks(9595));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "ContactType",
                keyColumn: "ID",
                keyValue: 5L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 418, DateTimeKind.Local).AddTicks(9599));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 1L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 419, DateTimeKind.Local).AddTicks(1156));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 2L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 419, DateTimeKind.Local).AddTicks(1167));

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CustomerType",
                keyColumn: "ID",
                keyValue: 3L,
                column: "CreatedDate",
                value: new DateTime(2022, 3, 4, 11, 17, 45, 419, DateTimeKind.Local).AddTicks(1171));

            migrationBuilder.CreateIndex(
                name: "IX_StoreGroupStoreMapping_StoreGroupId_StoreId",
                schema: "Mapping",
                table: "StoreGroupStoreMapping",
                columns: new[] { "StoreGroupId", "StoreId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StoreGroupDriverMapping_GroupeName",
                schema: "Mapping",
                table: "StoreGroupDriverMapping",
                column: "GroupeName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StoreGroupStoreMapping_StoreGroupId_StoreId",
                schema: "Mapping",
                table: "StoreGroupStoreMapping");

            migrationBuilder.DropIndex(
                name: "IX_StoreGroupDriverMapping_GroupeName",
                schema: "Mapping",
                table: "StoreGroupDriverMapping");

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
    }
}
