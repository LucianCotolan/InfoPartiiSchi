using Microsoft.EntityFrameworkCore.Migrations;

namespace InfoPartiiSchi.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Statiune",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true),
                    Judet = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statiune", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Partie",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(nullable: true),
                    Lungime = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    AltitudineMaxima = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    AltitudineMinima = table.Column<decimal>(type: "decimal(6, 2)", nullable: false),
                    Dificultate = table.Column<string>(nullable: true),
                    Video = table.Column<string>(nullable: true),
                    StatiuneID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partie", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Partie_Statiune_StatiuneID",
                        column: x => x.StatiuneID,
                        principalTable: "Statiune",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Partie_StatiuneID",
                table: "Partie",
                column: "StatiuneID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partie");

            migrationBuilder.DropTable(
                name: "Statiune");
        }
    }
}
