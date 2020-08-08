using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class renamedtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_CrustModel_CrustId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_SizeModel_SizeId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaToppingModel_Pizzas_PizzaId",
                table: "PizzaToppingModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaToppingModel_ToppingModel_ToppingId",
                table: "PizzaToppingModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PresetPizzas_CrustModel_CrustId",
                table: "PresetPizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_PresetPizzas_SizeModel_SizeId",
                table: "PresetPizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_PresetToppingModel_PresetPizzas_PresetPizzaId",
                table: "PresetToppingModel");

            migrationBuilder.DropForeignKey(
                name: "FK_PresetToppingModel_ToppingModel_ToppingId",
                table: "PresetToppingModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ToppingModel",
                table: "ToppingModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SizeModel",
                table: "SizeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PresetToppingModel",
                table: "PresetToppingModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaToppingModel",
                table: "PizzaToppingModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CrustModel",
                table: "CrustModel");

            migrationBuilder.RenameTable(
                name: "ToppingModel",
                newName: "Toppings");

            migrationBuilder.RenameTable(
                name: "SizeModel",
                newName: "Sizes");

            migrationBuilder.RenameTable(
                name: "PresetToppingModel",
                newName: "PresetToppings");

            migrationBuilder.RenameTable(
                name: "PizzaToppingModel",
                newName: "PizzaToppings");

            migrationBuilder.RenameTable(
                name: "CrustModel",
                newName: "Crusts");

            migrationBuilder.RenameIndex(
                name: "IX_PresetToppingModel_ToppingId",
                table: "PresetToppings",
                newName: "IX_PresetToppings_ToppingId");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaToppingModel_ToppingId",
                table: "PizzaToppings",
                newName: "IX_PizzaToppings_ToppingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PresetToppings",
                table: "PresetToppings",
                columns: new[] { "PresetPizzaId", "ToppingId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaToppings",
                table: "PizzaToppings",
                columns: new[] { "PizzaId", "ToppingId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Crusts",
                table: "Crusts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Crusts_CrustId",
                table: "Pizzas",
                column: "CrustId",
                principalTable: "Crusts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_Sizes_SizeId",
                table: "Pizzas",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaToppings_Pizzas_PizzaId",
                table: "PizzaToppings",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaToppings_Toppings_ToppingId",
                table: "PizzaToppings",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresetPizzas_Crusts_CrustId",
                table: "PresetPizzas",
                column: "CrustId",
                principalTable: "Crusts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PresetPizzas_Sizes_SizeId",
                table: "PresetPizzas",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PresetToppings_PresetPizzas_PresetPizzaId",
                table: "PresetToppings",
                column: "PresetPizzaId",
                principalTable: "PresetPizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresetToppings_Toppings_ToppingId",
                table: "PresetToppings",
                column: "ToppingId",
                principalTable: "Toppings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Crusts_CrustId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_Sizes_SizeId",
                table: "Pizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaToppings_Pizzas_PizzaId",
                table: "PizzaToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_PizzaToppings_Toppings_ToppingId",
                table: "PizzaToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_PresetPizzas_Crusts_CrustId",
                table: "PresetPizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_PresetPizzas_Sizes_SizeId",
                table: "PresetPizzas");

            migrationBuilder.DropForeignKey(
                name: "FK_PresetToppings_PresetPizzas_PresetPizzaId",
                table: "PresetToppings");

            migrationBuilder.DropForeignKey(
                name: "FK_PresetToppings_Toppings_ToppingId",
                table: "PresetToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sizes",
                table: "Sizes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PresetToppings",
                table: "PresetToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PizzaToppings",
                table: "PizzaToppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Crusts",
                table: "Crusts");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "ToppingModel");

            migrationBuilder.RenameTable(
                name: "Sizes",
                newName: "SizeModel");

            migrationBuilder.RenameTable(
                name: "PresetToppings",
                newName: "PresetToppingModel");

            migrationBuilder.RenameTable(
                name: "PizzaToppings",
                newName: "PizzaToppingModel");

            migrationBuilder.RenameTable(
                name: "Crusts",
                newName: "CrustModel");

            migrationBuilder.RenameIndex(
                name: "IX_PresetToppings_ToppingId",
                table: "PresetToppingModel",
                newName: "IX_PresetToppingModel_ToppingId");

            migrationBuilder.RenameIndex(
                name: "IX_PizzaToppings_ToppingId",
                table: "PizzaToppingModel",
                newName: "IX_PizzaToppingModel_ToppingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToppingModel",
                table: "ToppingModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SizeModel",
                table: "SizeModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PresetToppingModel",
                table: "PresetToppingModel",
                columns: new[] { "PresetPizzaId", "ToppingId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_PizzaToppingModel",
                table: "PizzaToppingModel",
                columns: new[] { "PizzaId", "ToppingId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_CrustModel",
                table: "CrustModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_CrustModel_CrustId",
                table: "Pizzas",
                column: "CrustId",
                principalTable: "CrustModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_SizeModel_SizeId",
                table: "Pizzas",
                column: "SizeId",
                principalTable: "SizeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaToppingModel_Pizzas_PizzaId",
                table: "PizzaToppingModel",
                column: "PizzaId",
                principalTable: "Pizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PizzaToppingModel_ToppingModel_ToppingId",
                table: "PizzaToppingModel",
                column: "ToppingId",
                principalTable: "ToppingModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresetPizzas_CrustModel_CrustId",
                table: "PresetPizzas",
                column: "CrustId",
                principalTable: "CrustModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PresetPizzas_SizeModel_SizeId",
                table: "PresetPizzas",
                column: "SizeId",
                principalTable: "SizeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PresetToppingModel_PresetPizzas_PresetPizzaId",
                table: "PresetToppingModel",
                column: "PresetPizzaId",
                principalTable: "PresetPizzas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresetToppingModel_ToppingModel_ToppingId",
                table: "PresetToppingModel",
                column: "ToppingId",
                principalTable: "ToppingModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
