using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Task_project.Migrations
{
    /// <inheritdoc />
    public partial class SeedDoctorData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Doctors",
               columns: new[] { "Id", "Name", "Specialization", "Img" },
               values: new object[,]
               {
                { 1,"Dr. John Smith", "Cardiology", "doctor1.jpg" },
                { 2,"Dr. Sarah Johnson", "Pediatrics", "doctor2.jpg" },
                { 3,"Dr. Emily Davis",  "Dermatology", "doctor4.jpg" },
                { 4,"Dr. Michael Lee",  "Orthopedics", "doctor3.jpg" },
                { 5,"Dr. William Clark", "Neurology", "doctor5.jpg" }
               }
               );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("remove from Doctors");
        }
    }
}
