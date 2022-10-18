using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TIP_UNLAM_Backend.Data.Migrations
{
    public partial class Usuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Juegos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Ruta = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juegos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Dni = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Matricula = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Contrasena = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaAlta = table.Column<DateTime>(type: "datetime", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    TIpoUsuarioId = table.Column<int>(type: "int", nullable: false),
                    Mail = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Usuarios__TIpoUs__286302EC",
                        column: x => x.TIpoUsuarioId,
                        principalTable: "TipoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProgresosXUsuarioXJuego",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioPacienteId = table.Column<int>(type: "int", nullable: true),
                    UsuarioProfesionalId = table.Column<int>(type: "int", nullable: true),
                    JuegoId = table.Column<int>(type: "int", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    Finalizado = table.Column<bool>(type: "bit", nullable: false),
                    Aciertos = table.Column<int>(type: "int", nullable: false),
                    Desaciertos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgresosXUsuarioXJuego", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Progresos__Juego__38996AB5",
                        column: x => x.JuegoId,
                        principalTable: "Juegos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Progresos__Usuar__36B12243",
                        column: x => x.UsuarioPacienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Progresos__Usuar__37A5467C",
                        column: x => x.UsuarioProfesionalId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioXUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioPacienteId = table.Column<int>(type: "int", nullable: false),
                    UsuarioProfesionalId = table.Column<int>(type: "int", nullable: false),
                    FechaInicioRelacion = table.Column<DateTime>(type: "datetime", nullable: false),
                    FechaFinalizacionRelacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioXUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK__UsuarioXU__Usuar__2F10007B",
                        column: x => x.UsuarioPacienteId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__UsuarioXU__Usuar__300424B4",
                        column: x => x.UsuarioProfesionalId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProgresosXUsuarioXJuego_JuegoId",
                table: "ProgresosXUsuarioXJuego",
                column: "JuegoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgresosXUsuarioXJuego_UsuarioPacienteId",
                table: "ProgresosXUsuarioXJuego",
                column: "UsuarioPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgresosXUsuarioXJuego_UsuarioProfesionalId",
                table: "ProgresosXUsuarioXJuego",
                column: "UsuarioProfesionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_TIpoUsuarioId",
                table: "Usuarios",
                column: "TIpoUsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioXUsuario_UsuarioPacienteId",
                table: "UsuarioXUsuario",
                column: "UsuarioPacienteId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioXUsuario_UsuarioProfesionalId",
                table: "UsuarioXUsuario",
                column: "UsuarioProfesionalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProgresosXUsuarioXJuego");

            migrationBuilder.DropTable(
                name: "UsuarioXUsuario");

            migrationBuilder.DropTable(
                name: "Juegos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "TipoUsuario");
        }
    }
}
