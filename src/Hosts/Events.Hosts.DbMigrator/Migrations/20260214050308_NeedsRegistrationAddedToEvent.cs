using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Hosts.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class NeedsRegistrationAddedToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventsTypes_EventTypeId",
                table: "Events");

            migrationBuilder.AddColumn<bool>(
                name: "NeedsRegistration",
                table: "Events",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventsTypes_EventTypeId",
                table: "Events",
                column: "EventTypeId",
                principalTable: "EventsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventsTypes_EventTypeId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "NeedsRegistration",
                table: "Events");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventsTypes_EventTypeId",
                table: "Events",
                column: "EventTypeId",
                principalTable: "EventsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
