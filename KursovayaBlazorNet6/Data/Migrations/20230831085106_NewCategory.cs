using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KursovayaBlazorNet6.Data.Migrations
{
    public partial class NewCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UslugiCategoryCategoryUslugiId",
                table: "Services",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "MedicCategoryCategoryMedicId",
                table: "Doctors",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "CategoryMedic",
                columns: table => new
                {
                    CategoryMedicId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryMedic", x => x.CategoryMedicId);
                });

            migrationBuilder.CreateTable(
                name: "CategoryUslugi",
                columns: table => new
                {
                    CategoryUslugiId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryUslugi", x => x.CategoryUslugiId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Services_UslugiCategoryCategoryUslugiId",
                table: "Services",
                column: "UslugiCategoryCategoryUslugiId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_MedicCategoryCategoryMedicId",
                table: "Doctors",
                column: "MedicCategoryCategoryMedicId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_CategoryMedic_MedicCategoryCategoryMedicId",
                table: "Doctors",
                column: "MedicCategoryCategoryMedicId",
                principalTable: "CategoryMedic",
                principalColumn: "CategoryMedicId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_CategoryUslugi_UslugiCategoryCategoryUslugiId",
                table: "Services",
                column: "UslugiCategoryCategoryUslugiId",
                principalTable: "CategoryUslugi",
                principalColumn: "CategoryUslugiId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_CategoryMedic_MedicCategoryCategoryMedicId",
                table: "Doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_CategoryUslugi_UslugiCategoryCategoryUslugiId",
                table: "Services");

            migrationBuilder.DropTable(
                name: "CategoryMedic");

            migrationBuilder.DropTable(
                name: "CategoryUslugi");

            migrationBuilder.DropIndex(
                name: "IX_Services_UslugiCategoryCategoryUslugiId",
                table: "Services");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_MedicCategoryCategoryMedicId",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "UslugiCategoryCategoryUslugiId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "MedicCategoryCategoryMedicId",
                table: "Doctors");
        }
    }
}
