using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Examen.Infra.Migrations
{
    /// <inheritdoc />
    public partial class ones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateEmbouche = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "Vehicules",
                columns: table => new
                {
                    VehiculeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Couleur = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Kilometrage = table.Column<int>(type: "int", nullable: false),
                    PrixJour = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicules", x => x.VehiculeId);
                });

            migrationBuilder.CreateTable(
                name: "Locataires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdhesion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PointBonus = table.Column<int>(type: "int", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AgentId = table.Column<int>(type: "int", nullable: false),
                    TypeLocataire = table.Column<int>(type: "int", nullable: false),
                    Intitule = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locataires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locataires_Agents_AgentId",
                        column: x => x.AgentId,
                        principalTable: "Agents",
                        principalColumn: "AgentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocataireVehicule",
                columns: table => new
                {
                    locatairesId = table.Column<int>(type: "int", nullable: false),
                    vehiculesVehiculeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocataireVehicule", x => new { x.locatairesId, x.vehiculesVehiculeId });
                    table.ForeignKey(
                        name: "FK_LocataireVehicule_Locataires_locatairesId",
                        column: x => x.locatairesId,
                        principalTable: "Locataires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocataireVehicule_Vehicules_vehiculesVehiculeId",
                        column: x => x.vehiculesVehiculeId,
                        principalTable: "Vehicules",
                        principalColumn: "VehiculeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    DateReservation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VehiculeKey = table.Column<int>(type: "int", nullable: false),
                    LocataireKey = table.Column<int>(type: "int", nullable: false),
                    DureeJours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => new { x.LocataireKey, x.VehiculeKey, x.DateReservation });
                    table.ForeignKey(
                        name: "FK_Reservations_Locataires_LocataireKey",
                        column: x => x.LocataireKey,
                        principalTable: "Locataires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Vehicules_VehiculeKey",
                        column: x => x.VehiculeKey,
                        principalTable: "Vehicules",
                        principalColumn: "VehiculeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locataires_AgentId",
                table: "Locataires",
                column: "AgentId");

            migrationBuilder.CreateIndex(
                name: "IX_LocataireVehicule_vehiculesVehiculeId",
                table: "LocataireVehicule",
                column: "vehiculesVehiculeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_VehiculeKey",
                table: "Reservations",
                column: "VehiculeKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocataireVehicule");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Locataires");

            migrationBuilder.DropTable(
                name: "Vehicules");

            migrationBuilder.DropTable(
                name: "Agents");
        }
    }
}
