using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocVoiture.Migrations
{
    /// <inheritdoc />
    public partial class modifie_identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assurances_Voitures_VoitureId",
                table: "Assurances");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Clients_ClientId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Voitures_VoitureId",
                table: "Locations");

            migrationBuilder.AlterColumn<int>(
                name: "VoitureId",
                table: "Locations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Locations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "VoitureId",
                table: "Assurances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Assurances_Voitures_VoitureId",
                table: "Assurances",
                column: "VoitureId",
                principalTable: "Voitures",
                principalColumn: "IdVoiture");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Clients_ClientId",
                table: "Locations",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "IdClient");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Voitures_VoitureId",
                table: "Locations",
                column: "VoitureId",
                principalTable: "Voitures",
                principalColumn: "IdVoiture");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assurances_Voitures_VoitureId",
                table: "Assurances");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Clients_ClientId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Voitures_VoitureId",
                table: "Locations");

            migrationBuilder.AlterColumn<int>(
                name: "VoitureId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClientId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "VoitureId",
                table: "Assurances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Assurances_Voitures_VoitureId",
                table: "Assurances",
                column: "VoitureId",
                principalTable: "Voitures",
                principalColumn: "IdVoiture",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Clients_ClientId",
                table: "Locations",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "IdClient",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Voitures_VoitureId",
                table: "Locations",
                column: "VoitureId",
                principalTable: "Voitures",
                principalColumn: "IdVoiture",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
