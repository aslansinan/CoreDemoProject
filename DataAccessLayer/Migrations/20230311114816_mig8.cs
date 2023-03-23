using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notfications",
                columns: table => new
                {
                    NotficationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NotficationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotficationTypeSymbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotficationDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotficationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotficationStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notfications", x => x.NotficationId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notfications");
        }
    }
}
