using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocVoiture.Migrations
{
    /// <inheritdoc />
    public partial class zouj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresse",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Ville",
                table: "Assurances");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresse",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ville",
                table: "Assurances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
