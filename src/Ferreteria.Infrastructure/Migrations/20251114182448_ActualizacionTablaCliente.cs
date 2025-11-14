using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ferreteria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionTablaCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Customers",
                newName: "Document");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Document",
                table: "Customers",
                newName: "Address");
        }
    }
}
