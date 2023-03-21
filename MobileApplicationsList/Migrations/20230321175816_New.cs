using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MobileApplicationsList.Migrations
{
    /// <inheritdoc />
    public partial class New : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "applicationbase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_applicationbase", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "aplicationdetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Score = table.Column<double>(type: "double precision", nullable: false),
                    Ratings = table.Column<int>(type: "integer", nullable: false),
                    Size = table.Column<double>(type: "double precision", nullable: false),
                    ApplicationStoreUrl = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ApplicationBaseId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aplicationdetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_aplicationdetails_applicationbase_ApplicationBaseId",
                        column: x => x.ApplicationBaseId,
                        principalTable: "applicationbase",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_aplicationdetails_ApplicationBaseId",
                table: "aplicationdetails",
                column: "ApplicationBaseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "aplicationdetails");

            migrationBuilder.DropTable(
                name: "applicationbase");
        }
    }
}
