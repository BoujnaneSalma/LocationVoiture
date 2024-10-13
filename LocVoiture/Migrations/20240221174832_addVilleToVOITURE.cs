using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocVoiture.Migrations
{
    /// <inheritdoc />
    public partial class addVilleToVOITURE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ville",
                table: "Assurances",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ville",
                table: "Assurances");
        }
    }
}
