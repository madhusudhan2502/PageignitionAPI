using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pagination.WebApi.Migrations
{
    public partial class BondMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contact",
                table: "Customers",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateTable(
                name: "BondAppDatas",
                columns: table => new
                {
                    BondApplicationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BondCompanyName = table.Column<string>(nullable: true),
                    BondType = table.Column<string>(nullable: true),
                    PostedDateTime = table.Column<DateTime>(nullable: false),
                    PaymentAuthorizedDate = table.Column<DateTime>(nullable: false),
                    PaymentCapturedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BondAppDatas", x => x.BondApplicationID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BondAppDatas");

            migrationBuilder.AlterColumn<long>(
                name: "Contact",
                table: "Customers",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
