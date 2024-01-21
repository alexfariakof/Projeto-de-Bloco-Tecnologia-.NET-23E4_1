using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PixCharge.Infrastructure.Migrations_MySqlServer.Migrations
{
    public partial class CostumerRelations_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CorrelationId",
                table: "Transaction",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CorrelationId",
                table: "Transaction",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");
        }
    }
}
