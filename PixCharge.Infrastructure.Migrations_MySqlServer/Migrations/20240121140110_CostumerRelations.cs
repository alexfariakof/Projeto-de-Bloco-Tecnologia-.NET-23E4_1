using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PixCharge.Infrastructure.Migrations_MySqlServer.Migrations
{
    public partial class CostumerRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charge_Customer_CustomerId",
                table: "Charge");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Customer_Id",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Charge_CustomerId",
                table: "Charge");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Charge");

            migrationBuilder.AlterColumn<Guid>(
                name: "CorrelationId",
                table: "Transaction",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CorrelationID",
                table: "Customer",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CorrelationID",
                table: "Charge",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_CorrelationId",
                table: "Transaction",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_Charge_CorrelationID",
                table: "Charge",
                column: "CorrelationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Charge_Customer_CorrelationID",
                table: "Charge",
                column: "CorrelationID",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Customer_CorrelationId",
                table: "Transaction",
                column: "CorrelationId",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Charge_Customer_CorrelationID",
                table: "Charge");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_Customer_CorrelationId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Transaction_CorrelationId",
                table: "Transaction");

            migrationBuilder.DropIndex(
                name: "IX_Charge_CorrelationID",
                table: "Charge");

            migrationBuilder.AlterColumn<Guid>(
                name: "CorrelationId",
                table: "Transaction",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CorrelationID",
                table: "Customer",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CorrelationID",
                table: "Charge",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AddColumn<Guid>(
                name: "CustomerId",
                table: "Charge",
                type: "char(36)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Charge_CustomerId",
                table: "Charge",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Charge_Customer_CustomerId",
                table: "Charge",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_Customer_Id",
                table: "Transaction",
                column: "Id",
                principalTable: "Customer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
