using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Events.Hosts.DbMigrator.Migrations
{
    /// <inheritdoc />
    public partial class ChangedEventPreviewFilenameType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PreviewFilename",
                table: "Events",
                type: "text",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "PreviewFilename",
                table: "Events",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
