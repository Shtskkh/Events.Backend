using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Hosts.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class AddedMaxParticipants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxParticipants",
                table: "Events",
                type: "integer",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxParticipants",
                table: "Events");
        }
    }
}
