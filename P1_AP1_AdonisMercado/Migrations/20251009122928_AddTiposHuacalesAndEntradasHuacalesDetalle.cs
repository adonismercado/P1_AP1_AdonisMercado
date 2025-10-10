﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace P1_AP1_AdonisMercado.Migrations
{
    /// <inheritdoc />
    public partial class AddTiposHuacalesAndEntradasHuacalesDetalle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposHuacales",
                columns: table => new
                {
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    Existencia = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposHuacales", x => x.TipoId);
                });

            migrationBuilder.CreateTable(
                name: "EntradasHuacalesDetalles",
                columns: table => new
                {
                    DetalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdEntrada = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoId = table.Column<int>(type: "INTEGER", nullable: false),
                    Cantidad = table.Column<int>(type: "INTEGER", nullable: false),
                    Precio = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradasHuacalesDetalles", x => x.DetalleId);
                    table.ForeignKey(
                        name: "FK_EntradasHuacalesDetalles_EntradasHuacales_IdEntrada",
                        column: x => x.IdEntrada,
                        principalTable: "EntradasHuacales",
                        principalColumn: "IdEntrada",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EntradasHuacalesDetalles_TiposHuacales_TipoId",
                        column: x => x.TipoId,
                        principalTable: "TiposHuacales",
                        principalColumn: "TipoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TiposHuacales",
                columns: new[] { "TipoId", "Descripcion", "Existencia" },
                values: new object[,]
                {
                    { 1, "Huacal Verde Tamaño Pequeña", 0 },
                    { 2, "Huacal Verde Tamaño Mediana", 0 },
                    { 3, "Huacal Verde Tamaño Jumbo", 0 },
                    { 4, "Huacal Rojo Tamaño Pequeña", 0 },
                    { 5, "Huacalo Rojo Tamaño Mediana", 0 },
                    { 6, "Huacal Rojo Tamaño Jumbo", 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradasHuacalesDetalles_IdEntrada",
                table: "EntradasHuacalesDetalles",
                column: "IdEntrada");

            migrationBuilder.CreateIndex(
                name: "IX_EntradasHuacalesDetalles_TipoId",
                table: "EntradasHuacalesDetalles",
                column: "TipoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradasHuacalesDetalles");

            migrationBuilder.DropTable(
                name: "TiposHuacales");
        }
    }
}
