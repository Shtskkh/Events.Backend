using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Hosts.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class RenameEventTypeToType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventsTypes_EventTypeId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "EventTypeId",
                table: "Events",
                newName: "TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_EventTypeId",
                table: "Events",
                newName: "IX_Events_TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventsTypes_TypeId",
                table: "Events",
                column: "TypeId",
                principalTable: "EventsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventsTypes_TypeId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "TypeId",
                table: "Events",
                newName: "EventTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_TypeId",
                table: "Events",
                newName: "IX_Events_EventTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventsTypes_EventTypeId",
                table: "Events",
                column: "EventTypeId",
                principalTable: "EventsTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
