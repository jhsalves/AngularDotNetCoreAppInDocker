using Microsoft.EntityFrameworkCore.Migrations;

namespace clients.Api.Migrations
{
    public partial class Fks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "ClientAddresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClientAddresses_ClientId",
                table: "ClientAddresses",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientAddresses_Clients_ClientId",
                table: "ClientAddresses",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientAddresses_Clients_ClientId",
                table: "ClientAddresses");

            migrationBuilder.DropIndex(
                name: "IX_ClientAddresses_ClientId",
                table: "ClientAddresses");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "ClientAddresses");
        }
    }
}
