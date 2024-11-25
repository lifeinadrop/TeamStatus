using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamStatusData.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "teamstatus");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "teamstatus",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "teamstatus",
                table: "Users",
                columns: new[] { "id", "name", "status", "title" },
                values: new object[,]
                {
                    { 1L, "McKenzie Powell", 0, "ISM Manager" },
                    { 2L, "Sakura Crandall", 4, "ISM" },
                    { 3L, "Brittany Mercedes", 0, "ISM" },
                    { 4L, "Ryan Vidlak", 0, "ISM" },
                    { 5L, "Grace le Bleu", 0, "ISM" },
                    { 6L, "Dan Walls", 5, "ISM" },
                    { 7L, "Tim O'Malley", 1, "Sales Manager III" },
                    { 8L, "Daniel Clogston", 1, "Sales Manager III" },
                    { 9L, "Sam Mowrer", 3, "Pretend ISM" },
                    { 10L, "Kingsley Adragna", 2, "ISM" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users",
                schema: "teamstatus");
        }
    }
}
