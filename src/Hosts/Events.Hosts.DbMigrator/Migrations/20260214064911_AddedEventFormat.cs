using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Events.Hosts.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class AddedEventFormat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FormatId",
                table: "Events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EventsFormats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventsFormats", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "EventsFormats",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Онлайн" },
                    { 2, "Офлайн" },
                    { 3, "Гибрид" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_FormatId",
                table: "Events",
                column: "FormatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_EventsFormats_FormatId",
                table: "Events",
                column: "FormatId",
                principalTable: "EventsFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_EventsFormats_FormatId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "EventsFormats");

            migrationBuilder.DropIndex(
                name: "IX_Events_FormatId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "FormatId",
                table: "Events");
        }
    }
}
