using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Hosts.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class AddedEventAnnouncement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Announcement",
                table: "Event",
                type: "character varying(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Announcement",
                table: "Event");
        }
    }
}
