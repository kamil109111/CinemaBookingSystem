using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaBookingSystem.Migrations
{
    public partial class SeanceSeatManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Seances_SeanceId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_SeanceId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "SeanceId",
                table: "Seats");

            migrationBuilder.CreateTable(
                name: "Seance_Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeanceId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seance_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seance_Seats_Seances_SeanceId",
                        column: x => x.SeanceId,
                        principalTable: "Seances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seance_Seats_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Seance_Seats_SeanceId",
                table: "Seance_Seats",
                column: "SeanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Seance_Seats_SeatId",
                table: "Seance_Seats",
                column: "SeatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seance_Seats");

            migrationBuilder.AddColumn<int>(
                name: "SeanceId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_SeanceId",
                table: "Seats",
                column: "SeanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Seances_SeanceId",
                table: "Seats",
                column: "SeanceId",
                principalTable: "Seances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
