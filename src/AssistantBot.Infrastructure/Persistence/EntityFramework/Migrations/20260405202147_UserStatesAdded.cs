using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssistantBot.Infrastructure.Persistence.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class UserStatesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "action_state",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "menu_state",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "action_state",
                table: "users");

            migrationBuilder.DropColumn(
                name: "menu_state",
                table: "users");
        }
    }
}
