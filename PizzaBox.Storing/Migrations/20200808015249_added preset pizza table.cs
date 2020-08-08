using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class addedpresetpizzatable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PresetPizzas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CrustId = table.Column<int>(nullable: true),
                    SizeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresetPizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PresetPizzas_CrustModel_CrustId",
                        column: x => x.CrustId,
                        principalTable: "CrustModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PresetPizzas_SizeModel_SizeId",
                        column: x => x.SizeId,
                        principalTable: "SizeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PresetToppingModel",
                columns: table => new
                {
                    PresetPizzaId = table.Column<int>(nullable: false),
                    ToppingId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PresetToppingModel", x => new { x.PresetPizzaId, x.ToppingId });
                    table.ForeignKey(
                        name: "FK_PresetToppingModel_PresetPizzas_PresetPizzaId",
                        column: x => x.PresetPizzaId,
                        principalTable: "PresetPizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PresetToppingModel_ToppingModel_ToppingId",
                        column: x => x.ToppingId,
                        principalTable: "ToppingModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PresetPizzas_CrustId",
                table: "PresetPizzas",
                column: "CrustId");

            migrationBuilder.CreateIndex(
                name: "IX_PresetPizzas_SizeId",
                table: "PresetPizzas",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_PresetToppingModel_ToppingId",
                table: "PresetToppingModel",
                column: "ToppingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PresetToppingModel");

            migrationBuilder.DropTable(
                name: "PresetPizzas");
        }
    }
}
