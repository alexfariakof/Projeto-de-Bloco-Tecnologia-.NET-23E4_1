using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PixCharge.Infrastructure.Migrations_MySqlServer.Migrations
{
    public partial class ChargeMap_Domain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Charge",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    CustomerId = table.Column<Guid>(type: "char(36)", nullable: true),
                    Value = table.Column<long>(type: "bigint", nullable: false),
                    Identifier = table.Column<string>(type: "longtext", nullable: true),
                    CorrelationID = table.Column<string>(type: "longtext", nullable: true),
                    PaymentLinkID = table.Column<string>(type: "longtext", nullable: true),
                    TransactionID = table.Column<string>(type: "longtext", nullable: true),
                    Status = table.Column<string>(type: "longtext", nullable: true),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    ValueWithDiscount = table.Column<int>(type: "int", nullable: false),
                    ExpiresDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Type = table.Column<string>(type: "longtext", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    BrCode = table.Column<string>(type: "longtext", nullable: true),
                    ExpiresIn = table.Column<int>(type: "int", nullable: false),
                    PixKey = table.Column<string>(type: "longtext", nullable: true),
                    PaymentLinkUrl = table.Column<string>(type: "longtext", nullable: true),
                    QrCodeImage = table.Column<string>(type: "longtext", nullable: true),
                    GlobalID = table.Column<string>(type: "longtext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Charge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Charge_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdditionalInfo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Key = table.Column<string>(type: "longtext", nullable: true),
                    Value = table.Column<string>(type: "longtext", nullable: true),
                    ChargeId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalInfo_Charge_ChargeId",
                        column: x => x.ChargeId,
                        principalTable: "Charge",
                        principalColumn: "Id");
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfo_ChargeId",
                table: "AdditionalInfo",
                column: "ChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_Charge_CustomerId",
                table: "Charge",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalInfo");

            migrationBuilder.DropTable(
                name: "Charge");
        }
    }
}
