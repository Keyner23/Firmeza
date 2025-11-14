using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ferreteria.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ActualizacionTablaCliente2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Usamos SQL directo y NO usamos AlterColumn de EF
            migrationBuilder.Sql("""
                                     ALTER TABLE "Customers"
                                     ALTER COLUMN "Document"
                                     TYPE integer
                                     USING "Document"::integer;
                                 """);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revertir a texto si fuese necesario
            migrationBuilder.Sql("""
                                     ALTER TABLE "Customers"
                                     ALTER COLUMN "Document"
                                     TYPE text
                                     USING "Document"::text;
                                 """);
        }
    }
}