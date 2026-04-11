using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class MessageIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "message_id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "message_id",
                table: "users");
        }
    }
}
