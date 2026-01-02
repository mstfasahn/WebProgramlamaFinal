using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPF.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserLoggingAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EndpointId",
                table: "UserLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_EndpointId",
                table: "UserLogs",
                column: "EndpointId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLogs_Endpoints_EndpointId",
                table: "UserLogs",
                column: "EndpointId",
                principalTable: "Endpoints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLogs_Endpoints_EndpointId",
                table: "UserLogs");

            migrationBuilder.DropIndex(
                name: "IX_UserLogs_EndpointId",
                table: "UserLogs");

            migrationBuilder.DropColumn(
                name: "EndpointId",
                table: "UserLogs");
        }
    }
}
