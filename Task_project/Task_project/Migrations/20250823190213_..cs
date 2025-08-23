using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_project.Migrations
{
    /// <inheritdoc />
    public partial class _ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Doctors_DoctorId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_Patient_PatientId",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patient",
                table: "Patient");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "reservations");

            migrationBuilder.RenameTable(
                name: "Patient",
                newName: "patients");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_PatientId",
                table: "reservations",
                newName: "IX_reservations_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_DoctorId",
                table: "reservations",
                newName: "IX_reservations_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservations",
                table: "reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_patients",
                table: "patients",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_Doctors_DoctorId",
                table: "reservations",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservations_patients_PatientId",
                table: "reservations",
                column: "PatientId",
                principalTable: "patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservations_Doctors_DoctorId",
                table: "reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_reservations_patients_PatientId",
                table: "reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservations",
                table: "reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_patients",
                table: "patients");

            migrationBuilder.RenameTable(
                name: "reservations",
                newName: "Reservation");

            migrationBuilder.RenameTable(
                name: "patients",
                newName: "Patient");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_PatientId",
                table: "Reservation",
                newName: "IX_Reservation_PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_reservations_DoctorId",
                table: "Reservation",
                newName: "IX_Reservation_DoctorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patient",
                table: "Patient",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Doctors_DoctorId",
                table: "Reservation",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_Patient_PatientId",
                table: "Reservation",
                column: "PatientId",
                principalTable: "Patient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
