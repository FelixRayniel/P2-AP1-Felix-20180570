using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P2_AP1_Felix_20180570.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proyectos",
                columns: table => new
                {
                    ProyectoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: true),
                    TiempoTotal = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyectos", x => x.ProyectoID);
                });

            migrationBuilder.CreateTable(
                name: "TiposTareas",
                columns: table => new
                {
                    TipoTareaID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoTarea = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposTareas", x => x.TipoTareaID);
                });

            migrationBuilder.CreateTable(
                name: "TareasDetalle",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoTareaID = table.Column<int>(type: "INTEGER", nullable: false),
                    Requerimiento = table.Column<string>(type: "TEXT", nullable: true),
                    Tiempo = table.Column<int>(type: "INTEGER", nullable: false),
                    ProyectoID = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TareasDetalle", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TareasDetalle_Proyectos_ProyectoID",
                        column: x => x.ProyectoID,
                        principalTable: "Proyectos",
                        principalColumn: "ProyectoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TareasDetalle_TiposTareas_TipoTareaID",
                        column: x => x.TipoTareaID,
                        principalTable: "TiposTareas",
                        principalColumn: "TipoTareaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TipoTareaID", "TipoTarea" },
                values: new object[] { 1, "Analisis" });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TipoTareaID", "TipoTarea" },
                values: new object[] { 2, "Diseño" });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TipoTareaID", "TipoTarea" },
                values: new object[] { 3, "Programacion" });

            migrationBuilder.InsertData(
                table: "TiposTareas",
                columns: new[] { "TipoTareaID", "TipoTarea" },
                values: new object[] { 4, "Prueba" });

            migrationBuilder.CreateIndex(
                name: "IX_TareasDetalle_ProyectoID",
                table: "TareasDetalle",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_TareasDetalle_TipoTareaID",
                table: "TareasDetalle",
                column: "TipoTareaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TareasDetalle");

            migrationBuilder.DropTable(
                name: "Proyectos");

            migrationBuilder.DropTable(
                name: "TiposTareas");
        }
    }
}
