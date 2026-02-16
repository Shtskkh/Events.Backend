using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Hosts.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class AddedPlaceholderPreviewToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PlaceholderFilename",
                table: "Events",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlaceholderFilename",
                table: "Events");
        }
    }
}
