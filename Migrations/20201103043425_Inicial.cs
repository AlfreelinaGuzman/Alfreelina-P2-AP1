using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Alfreelina_P2_AP1.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    TiempoTotal = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoID);
                });

            migrationBuilder.CreateTable(
                name: "Tareas",
                columns: table => new
                {
                    TareaID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoTarea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tareas", x => x.TareaID);
                });

            migrationBuilder.CreateTable(
                name: "ProyectoDetalle",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProyectoID = table.Column<int>(nullable: false),
                    TareaID = table.Column<int>(nullable: false),
                    Requerimiento = table.Column<string>(nullable: true),
                    Tiempo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProyectoDetalle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProyectoDetalle_Proyectos_ProyectoID",
                        column: x => x.ProyectoID,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProyectoDetalle_Tareas_TareaID",
                        column: x => x.TareaID,
                        principalTable: "Tareas",
                        principalColumn: "TareaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaID", "TipoTarea" },
                values: new object[] { 1, "Diseño" });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaID", "TipoTarea" },
                values: new object[] { 2, "Prueba" });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaID", "TipoTarea" },
                values: new object[] { 3, "Analisis" });

            migrationBuilder.InsertData(
                table: "Tareas",
                columns: new[] { "TareaID", "TipoTarea" },
                values: new object[] { 4, "Programacion" });

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoDetalle_ProyectoID",
                table: "ProyectoDetalle",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_ProyectoDetalle_TareaID",
                table: "ProyectoDetalle",
                column: "TareaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProyectoDetalle");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "Tareas");
        }
    }
}
