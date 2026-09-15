using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle_Service_Log.Migrations
{
    /// <inheritdoc />
    public partial class SyncDatabaseColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceType",
                table: "ServiceLogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "ServiceLogs");
        }
    }
}
