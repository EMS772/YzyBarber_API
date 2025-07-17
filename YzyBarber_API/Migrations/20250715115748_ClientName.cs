using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YzyBarber_API.Migrations
{
    /// <inheritdoc />
    public partial class ClientName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Clients",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Clients",
                newName: "Username");
        }
    }
}
