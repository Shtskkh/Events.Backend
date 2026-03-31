using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Hosts.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class AddedInventoryNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InventoryNumber",
                table: "Equipment",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_InventoryNumber",
                table: "Equipment",
                column: "InventoryNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Equipment_InventoryNumber",
                table: "Equipment");

            migrationBuilder.DropColumn(
                name: "InventoryNumber",
                table: "Equipment");
        }
    }
}
