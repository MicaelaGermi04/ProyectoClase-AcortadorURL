﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoClase_Practica.Migrations
{
    /// <inheritdoc />
    public partial class ArregloTablaCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Category",
                newName: "Id");
        }
    }
}